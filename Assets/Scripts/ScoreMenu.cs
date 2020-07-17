using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreMenu : MonoBehaviour
{

    public TextMeshProUGUI Tutorial;
    public TextMeshProUGUI Level1;
    public TextMeshProUGUI Level2;


    // Start is called before the first frame update
    void Start()
    {
        Tutorial.SetText("Tutorial: " + PlayerPrefs.GetInt("TutorialCrystals", 0).ToString());
        Level1.SetText("Level 1: " + PlayerPrefs.GetInt("Level1Crystals", 0).ToString());
        Level2.SetText("Level 2: " + PlayerPrefs.GetInt("Level2Crystals", 0).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Tutorial.SetText("Tutorial: " + PlayerPrefs.GetInt("TutorialCrystals", 0).ToString());
        Level1.SetText("Level 1: " + PlayerPrefs.GetInt("Level1Crystals", 0).ToString());
        Level2.SetText("Level 2: " + PlayerPrefs.GetInt("Level2Crystals", 0).ToString());
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
