using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Enemy1 : MonoBehaviour
{
    public int health = 2;
    public GameObject deathEffect;
    public GameObject bloodstain;
    public float knockbackFromWep = 2500f;
    public float bloodlifetime = 10f;

    public CinemachineVirtualCamera VirtualCamera;
    protected RipplePostProcessor camRipple;

    public HealthBar healthBar;

    private void Start()
    {
        camRipple = Camera.main.GetComponent<RipplePostProcessor>();
        healthBar.SetMaxHealth(health);
    }
    public virtual void TakeDamage(int damage)
    {
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().smallshake();
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Hazards")
        {
            TakeDamage(10);
        }
    }

    public virtual void Die()
    {
        AudioManager.instance.Play("Splatter");

        GameObject bs = Instantiate(bloodstain, transform.position, Quaternion.identity);
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
        Destroy(bs, bloodlifetime);
        camRipple.RippleEffect();
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().shake();
    }


}
