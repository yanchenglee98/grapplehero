using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LockedDoor : MonoBehaviour
{
    private PlayerMovement player;

    public LevelLoader lvlloader;

    public Animator animator;

    public bool opened = false;

    private AudioSource audiosource;


    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();

        lvlloader = FindObjectOfType<LevelLoader>();
        player = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (opened)
        {
            //animator.SetBool("Opened", true);
            animator.Play("doorOpen");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (opened)
            {
                lvlloader.LoadNextLevel();
            }
            else
            {
                audiosource.Play();
            }
        }


       
    }
}
