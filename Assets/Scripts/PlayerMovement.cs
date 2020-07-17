using System.Collections;
using System.Collections.Generic;
//using UnityEditorInternal.VersionControl;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public float horizontalMove = 0f;
    public float runSpeed = 40f;
    public float airSpeed = 60f;
    public float groundSpeed = 40f;
    public bool jump = false;
    public bool crouch = false;
    public Animator animator;
    public int crystals;
    public int keys;
    public int goldCoins;
    public throwhook hook;


    // Start is called before the first frame update
    void Start()
    {
        //audioManager = FindObjectOfType<AudioManager>();

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && hook.canJump)
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }
        
        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
        runSpeed = groundSpeed;
    }
    void FixedUpdate()
    {

        if (!controller.m_Grounded)
        {
            runSpeed = airSpeed;
        }

        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
        
    }
}
