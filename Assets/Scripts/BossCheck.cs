using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class BossCheck : MonoBehaviour
{

    private PlayerMovement player;

    private AudioSource audiosource;

    public Boss boss;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerMovement>();
        boss = FindObjectOfType<Boss>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (boss == null)
        {
            AudioManager.instance.Play("doorUnlock");

            audiosource.Play();
            gameObject.GetComponentInParent<LockedDoor>().opened = true;
        }



    }
}