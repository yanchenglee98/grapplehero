using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


public class FallingHazard : MonoBehaviour
{
    public bool canKnockDown = false;
    public bool hookCanTrigger = false;
    public CinemachineVirtualCamera VirtualCamera;

    public bool rockfallEvent = false;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            rb.isKinematic = false;
            if (canKnockDown)
            {
                rb.gravityScale = 4;

            }
            if (rockfallEvent)
            {
                AudioManager.instance.Play("Rockslide");
                Invoke("Rockfall", 0.5f);

                rockfallEvent = false;

            }
        }

        else if (hookCanTrigger && collision.tag == "Grappling Hook")
        {
            rb.isKinematic = false;
            if (canKnockDown)
            {
                rb.gravityScale = 4;

            }
            if (rockfallEvent)
            {
                AudioManager.instance.Play("Rockslide");
                Invoke("Rockfall", 0.5f);

                rockfallEvent = false;

            }
        }


    }

    void Rockfall()
    {
        VirtualCamera.GetComponent<SimpleCameraShakeInCinemachine>().shake();

    }
}
