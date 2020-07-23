using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy1
{
    public int enrageThreshold = 10;

    public Transform player;

    public bool isFlipped = false;

    public bool isInvulnerable = false;

    public Animator animator;

    private void Start()
    {
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        healthBar.SetMaxHealth(health);
        animator = GetComponent<Animator>();
    }

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;

        }
        else if (transform.position.x < player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
    }

    public override void TakeDamage(int damage)
    {
        if (isInvulnerable)
        {
            return;
        }

        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().smallshake(); 
        health -= damage;
        healthBar.SetHealth(health);

        if (health != enrageThreshold)
        {
            animator.SetTrigger("Damage");
        }
        if (health <= enrageThreshold)
        {
            animator.SetBool("IsEnraged", true);
        }
        if (health <= 0)
        {
            Die();

        }
    }

    public override void Die()
    {
        animator.Play("BanditEnragedDeath");
        GameObject bs = Instantiate(bloodstain, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        transform.gameObject.tag = "Background"; // prevent player from dying if they touch the death animation
        Destroy(gameObject, 1f); // delay destroying of enemy to allow animation to play
        Destroy(bs, bloodlifetime);
        camRipple.RippleEffect();
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().shake();
    }

}