using UnityEngine;
using System.Collections;
using System;

public class throwhook : MonoBehaviour // can think of this script as the "weapon"
{

    public GameObject hook;


    public bool ropeActive;

    public GameObject curHook;

    public float ropeLength = 7f;

    public LayerMask grappleMask;

    public float boostForce = 1000f;

    public float airBoostForce = 1000f;

    public float offset;

    private CharacterController2D cc;

    public Rigidbody2D m_Rigidbody2D;

    public bool canJump;

    // Use this for initialization
    void Start()
    {
        //audioManager = FindObjectOfType<AudioManager>();
        cc = gameObject.GetComponent<CharacterController2D>();
    }

    // Update is called once per frame
    void Update()
    {
        boostForce = airBoostForce;
        if (cc.m_Grounded && ropeActive) // hook out, grounded
        {
            canJump = false;
        } else
        {
            canJump = true;
        }

        if (Input.GetMouseButtonDown(0))
        {
            
            Vector2 destiny = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            if (!ropeActive)
            {

               // RaycastHit2D hit = Physics2D.Raycast(destiny, Vector2.zero);
                RaycastHit2D hit = Physics2D.Raycast(transform.position, destiny - (Vector2)transform.position, ropeLength, grappleMask); // shoot raycast from player to destiny of length ropeLength
                //Debug.Log(hit.collider != null ? hit.collider.transform.tag: "nothing");
                if (hit.collider != null && hit.collider.transform.tag != "Ungrappable")
                {
                    AudioManager.instance.Play("HookHit");
                    //curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.identity);
                    Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
                    float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
                    curHook = (GameObject)Instantiate(hook, transform.position, Quaternion.Euler(0f, 0f, rotZ + offset));            
                    curHook.GetComponent<RopeScript>().destiny = hit.point;

                    ropeActive = true;

                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            if (ropeActive) // && cc.m_Grounded == false)
            {
                if (!canJump)
                {
                    boostForce += 250f; // slightly higher boostforce when player is grounded
                }

                // gameObject.GetComponent<Rigidbody2D>().AddForce(gameObject.GetComponent<Rigidbody2D>().velocity * 400); // use this for super boost
                gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0f, boostForce)); // boost player upwards when rope is withdrawn
                gameObject.GetComponentInChildren<TrailRenderer>().enabled = false; // disable green trial
                gameObject.transform.Find("Boost Trail").gameObject.SetActive(true);  // enable boost trial

                Invoke("revertTrail", 0.7f); // change trail renderer back to original

            }

            //delete rope

            resetRope();



        }
       
        if (Input.GetButtonDown("Jump")) // alternative method to unhook which does not have boost
        {
            if (ropeActive)
            {
                resetRope();
            }
        }

    }

    void revertTrail()
    {
        gameObject.GetComponentInChildren<TrailRenderer>().enabled = true;
        gameObject.transform.Find("Boost Trail").gameObject.SetActive(false);
    }

    public void resetRope()
    {
        Destroy(curHook);
        ropeActive = false;
    }

}