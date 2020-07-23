using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreMenu : MonoBehaviour
{

    public TextMeshProUGUI Tutorial;
    public TextMeshProUGUI Level1;
    public TextMeshProUGUI Level2;
    public TextMeshProUGUI Level3;
    public TextMeshProUGUI Level4;
    public TextMeshProUGUI Escape;

    // Start is called before the first frame update
    void Start()
    {
        Tutorial.SetText("Tutorial: " + PlayerPrefs.GetInt("TutorialCrystals", 0).ToString());
        Level1.SetText("Level 1: " + PlayerPrefs.GetInt("Level1Crystals", 0).ToString());
        Level2.SetText("Level 2: " + PlayerPrefs.GetInt("Level2Crystals", 0).ToString());
        Level3.SetText("Level 3: " + PlayerPrefs.GetInt("Level3Crystals", 0).ToString());
        Level4.SetText("Level 4: " + PlayerPrefs.GetInt("Level4Crystals", 0).ToString());
        Escape.SetText("Escape: " + PlayerPrefs.GetInt("EscapeCrystals", 0).ToString());
    }

    // Update is called once per frame
    void Update()
    {
        Tutorial.SetText("Tutorial: " + PlayerPrefs.GetInt("TutorialCrystals", 0).ToString());
        Level1.SetText("Level 1: " + PlayerPrefs.GetInt("Level1Crystals", 0).ToString());
        Level2.SetText("Level 2: " + PlayerPrefs.GetInt("Level2Crystals", 0).ToString());
        Level3.SetText("Level 3: " + PlayerPrefs.GetInt("Level3Crystals", 0).ToString());
        Level4.SetText("Level 4: " + PlayerPrefs.GetInt("Level4Crystals", 0).ToString());
        Escape.SetText("Escape: " + PlayerPrefs.GetInt("EscapeCrystals", 0).ToString());
    }

    public void Reset()
    {
        PlayerPrefs.DeleteAll();
    }
}
