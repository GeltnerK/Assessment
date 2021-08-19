using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animation anim;
    public Animator playerAnimatorController;

    // Start is called before the first frame update
    void Start()
    {
        playerAnimatorController = GetComponent<Animator>();
        anim = GetComponent<Animation>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            playerAnimatorController.SetBool("Up",true);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            playerAnimatorController.SetBool("Down",true);
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            playerAnimatorController.SetBool("Left",true);
        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            playerAnimatorController.SetBool("Right",true);
        }

        else
        {
            anim.Stop();
        }

    }
}
