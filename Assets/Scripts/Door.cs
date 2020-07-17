using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Door : MonoBehaviour
{
    private PlayerMovement player;

    public LevelLoader lvlloader;

    // Start is called before the first frame update
    void Start()
    {
        lvlloader = FindObjectOfType<LevelLoader>();
        player = FindObjectOfType<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
                lvlloader.LoadNextLevel();

        }



        /*        if (SceneManager.GetActiveScene().buildIndex >= 2)
                {
                    if (player.keys > 0)
                    {
                        player.keys--;
                        lvlloader.LoadNextLevel();
                    }
                }
                else
                {*/
       // lvlloader.LoadNextLevel();
       // }


    }
}
