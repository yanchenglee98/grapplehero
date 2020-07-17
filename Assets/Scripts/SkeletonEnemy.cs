using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SkeletonEnemy : Enemy1
{
    public Animator animator;

    private void Start()
    {
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        healthBar.SetMaxHealth(health);
    }

    public override void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().smallshake();

        if (health <= 0)
        {
            animator.Play("Skeleton_Death");
            Die();
        } else
        {
            animator.Play("Skeleton_Damage");
        }
    }

    public override void Die()
    {
        AudioManager.instance.Play("SkeletonDeath");

        Instantiate(deathEffect, transform.position, Quaternion.identity);
        transform.gameObject.tag = "Background"; // prevent player from dying if they touch the death animation
        Destroy(gameObject, 1f); // delay destroying of enemy to allow animation to play
        camRipple.RippleEffect();
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().shake();

    }


}