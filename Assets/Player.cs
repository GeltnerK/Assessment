using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShortcutManagement;
using UnityEngine;

/// <summary>
/// This script must be used as the core Player script for managing the player character in the game.
/// </summary>
public class Player : MonoBehaviour
{
    public string playerName = ""; //The players name for the purpose of storing the high score
   
    public int playerTotalLives; //Players total possible lives.
    public int playerLivesRemaining; //PLayers actual lives remaining.
   
    public bool playerIsAlive = true; //Is the player currently alive?
    public bool playerCanMove = false; //Can the player currently move?

    public bool isInWater = false; // is the player in the wazter?
    public bool isOnPlatform = false; //is the player on a platform?

    public float moveSpeed = 3; //Player's speed
    public bool isWalking;

    private Animator anim;
    private float x, y;

    public AudioSource myAudioSourse;
    public AudioClip coinPickup;
    public AudioClip deathNoise;
    public AudioClip drownNoise;// Audio Clips
    public AudioClip backgroundMusic;

    public Sprite deadSprite; //Reference to dead sprite
    public Sprite winSprite; //reference to winning sprite

    public List<string> highScores = new List<string>(); //reference to high score

    public Rigidbody2D rb; //Reference to rigidbody

    private GameManager myGameManager; //A reference to the GameManager in the scene.

    private 

    // Start is called before the first frame update
    void Start()
    {
        myGameManager = GameObject.Find("GameManager").GetComponent<GameManager>();

        playerLivesRemaining = 3;
        playerTotalLives = 3;

        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerIsAlive == true)
        {
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            if (x != 0 || y != 0)
            {
                if (!isWalking)
                {
                    isWalking = true;
                    anim.SetBool("isWalking", isWalking);
                }

                Move();
            }
            else
            {
                if (isWalking)
                {
                    isWalking = false;
                    anim.SetBool("isWalking", isWalking);
                }
            }
        }
    }

    void LateUpdate()
    {
        if(playerIsAlive == true)
        {
            if (isInWater == true && isOnPlatform == false)
                {
                    KillPlayer();
                }
        }

        
    }

    private void Move()
    {
        if (playerIsAlive == true)
        {


            anim.SetFloat("x", x);
            anim.SetFloat("y", y);

            transform.Translate(x * Time.deltaTime * moveSpeed, y * Time.deltaTime * moveSpeed, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (playerIsAlive == true)
        {

        
            if(collision.transform.GetComponent<Vehicle>() != null)
            {
                KillPlayer();
                print("hit");
            }
            else if (collision.transform.GetComponent<Platform>() != null)
            {
                transform.SetParent(collision.transform);
                isOnPlatform = true;
            }
            else if (collision.transform.tag == "Coin")
            {
                playerCanMove = false;

            }
            else if (collision.transform.tag == "Water")
             {
                isInWater = true;
                GetComponent<AudioSource>().PlayOneShot(drownNoise);

            }
        }
    }

        

    void OnTriggerExit2D(Collider2D collision)
    {
        if (playerIsAlive == true)
        {
            if (collision.transform.GetComponent<Platform>() != null)
            {
                transform.SetParent(null);
                isOnPlatform = false;
            }
            else if (collision.transform.tag == "Water")
            {
                isInWater = false;
            }
        }
    }

    void KillPlayer()
    {
        playerIsAlive = false;
        playerCanMove = false;
        isWalking = false;
        


        if (playerIsAlive != true)
        {
            UIManager.GameOver(false);
        }

    }

    void Coin()
    {

    }
}

