using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DoorCheck : MonoBehaviour
{

    private PlayerMovement player;

    private AudioSource audiosource;

    // Start is called before the first frame update
    void Start()
    {
        audiosource = GetComponent<AudioSource>();
        player = FindObjectOfType<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
            if (player.keys > 0)
            {
                AudioManager.instance.Play("doorUnlock");

                audiosource.Play();
                player.keys--;
                gameObject.GetComponentInParent<LockedDoor>().opened = true;
            }



    }
}
