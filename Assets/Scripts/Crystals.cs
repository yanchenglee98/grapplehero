using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Crystals : MonoBehaviour
{

    private PlayerMovement player;
    private throwhook throwHook;

    void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        throwHook = FindObjectOfType<throwhook>(); // find throwhook script
    }

    void Update()
    {
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            AudioManager.instance.Play("Collect");
            Destroy(gameObject);
            player.crystals++;
        }
         else if (other.tag == "Grappling Hook")
        {
            AudioManager.instance.Play("Collect");
            Destroy(gameObject);
            player.crystals++;
            //throwHook.resetRope();
        }
    }
}