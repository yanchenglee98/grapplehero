using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingRock : MonoBehaviour
{
    public Rigidbody2D rb;
    private throwhook throwHook;
    public bool fell;
    public bool breaks = false;
    public bool setMassAfterfall = true;
    public float timeb4Fall = 0.4f;
    //public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        throwHook = FindObjectOfType<throwhook>(); // find throwhook script
        fell = false;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (!fell)
        {
            if (other.collider.CompareTag("Player") || other.collider.tag == "Grappling Hook")
            {
                //animator.Play("FallingTile");

                //rb.gravityScale = 2;
                //throwHook.resetRope();
                AudioManager.instance.Play("Crumble");
                if (breaks)
                {
                    Invoke("setGrav", timeb4Fall);
                    gameObject.tag = "Can Interact";
                    fell = true;
                    Invoke("destroyself", timeb4Fall);
                } else
                {
                    Invoke("setGrav", timeb4Fall);
                    gameObject.tag = "Can Interact";
                    fell = true;
                }

            }
        }

    }
    void setGrav()
    {
        rb.gravityScale = 4;
        if (setMassAfterfall)
        {
            rb.mass = 3;

        }

    }

    void destroyself()
    {
        Destroy(gameObject);
    }
}
