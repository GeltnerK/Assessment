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

    public float moveSpeed; //Player's speed
    public bool isWalking;

    private Animator anim;
    private float x, y;

    public AudioSource myAudioSourse;
    public AudioClip coinPickup;
    public AudioClip deathNoise; // Audio Clips
    public AudioClip backgroundMusic;

    public Sprite deadSprite; //Reference to dead sprite

    public List<string> highScores = new List<string>(); //Reference to HighScores

    public Rigidbody2D rb; //Reference to rigidbody

    private GameManager myGameManager; //A reference to the GameManager in the scene.

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
        if (collision.transform.GetComponent<Vehicle>() != null)
        {
            KillPlayer();
        }
    }

    void KillPlayer()
    {
        playerIsAlive = false;
        playerCanMove = false;
    }
}
