using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : PlayerMovement
{
    public int moveAxis = 0;
    public int max = 1;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = moveAxis * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (max > 0)
            {
                max -= 1;
                moveAxis = -1;
                StartCoroutine("MoveRight");
            }
        }

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

    public IEnumerator MoveRight()
    {
        yield return new WaitForSeconds(0.5f);
        moveAxis = 1;
        max = 1;
    }
}
