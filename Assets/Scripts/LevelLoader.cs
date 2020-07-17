using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;

    public GameObject UIElements;

    public float transitionTime = 1f;

    // Update is called once per frame
    void Update()
    {
        // can be used for various game conditions such as collecting a certain number of crystals
    }

    public void LoadNextLevel()
    {
        UIElements.SetActive(false);// disable UI elements while transitioning between scenes
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
    }

    public void LoadCurrentLevel()
    {
        UIElements.SetActive(false);// disable UI elements while transitioning between scenes
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex));
    }

    public void Load(int levelIndex)
    {
        StartCoroutine(LoadLevel(levelIndex));
    }

    IEnumerator LoadLevel(int levelIndex)
    {


        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);
    }
}
