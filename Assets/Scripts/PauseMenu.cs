using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            } else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        AudioManager.instance.Play("Select");
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // set game speed to normal
        GameIsPaused = false;
    }

    public void Pause()
    {
        AudioManager.instance.Play("Select");
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // set game speed to 0
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        AudioManager.instance.Play("Select");
        Time.timeScale = 1f; // set game speed to normal
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        AudioManager.instance.Play("Select");
        Debug.Log("QUIT");
        Application.Quit();
    }

    public void Restart()
    {
        AudioManager.instance.Play("Select");
        Time.timeScale = 1f; // set game speed to normal
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
