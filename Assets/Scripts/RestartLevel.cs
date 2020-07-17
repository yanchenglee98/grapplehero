using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartLevel : MonoBehaviour
{

    public LevelLoader lvlloader;
    // Start is called before the first frame update
    void Start()
    {
        lvlloader = FindObjectOfType<LevelLoader>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void RestartGame()
    {
        lvlloader.LoadCurrentLevel();
        // SceneManager.LoadScene()
    }

/*    public void RestartLvl()
    {
        SceneManager.LoadScene("Tutorial");
    }*/
}
