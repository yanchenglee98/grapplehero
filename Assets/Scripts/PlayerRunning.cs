using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : PlayerMovement
{
    public int moveAxis = 0;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = moveAxis * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump") && hook.canJump)
        {
            animator.SetBool("IsJumping", true);
            jump = true;
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }
}
