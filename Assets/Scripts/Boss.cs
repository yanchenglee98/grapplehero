using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy1
{
    public int enrageThreshold = 5;

    public Transform player;

    public bool isFlipped = false;

    public bool isInvulnerable = false;

    public void LookAtPlayer()
    {
        Vector3 flipped = transform.localScale;
        flipped.z *= -1f;

        if (transform.position.x > player.position.x && isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = false;
        }
        else if (transform.position.x < player.position.x && !isFlipped)
        {
            transform.localScale = flipped;
            transform.Rotate(0f, 180f, 0f);
            isFlipped = true;
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

        if (health <= enrageThreshold)
        {
            GetComponent<Animator>().SetBool("IsEnraged", true);
        }

        if (health <= 0)
        {
            Die();

        }
    }

    public override void Die()
    {

        GameObject bs = Instantiate(bloodstain, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(bs, bloodlifetime);
        camRipple.RippleEffect();
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().shake();
    }

}