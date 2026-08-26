using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    [SerializeField] GameObject winpanel;
    [SerializeField] TMP_Text leveltext;
    [SerializeField] TMP_Text currentleveltext;
    [SerializeField] LevelData[] levels;

    int currentlevelIndex = 0;

    const string currentscene = "GameScene";

    public LevelData CurrentLevelData => levels[currentlevelIndex];

     void Start()
    {
        currentlevelIndex = PlayerPrefs.GetInt("CurrentLevel", 0);
        leveltext.text = CurrentLevelData.levelNumber.ToString("00");
    }

    public void nextlevel()
    {
        currentleveltext.text = CurrentLevelData.levelNumber.ToString("00");
        winpanel.SetActive(false);
        currentlevelIndex++;
        PlayerPrefs.SetInt("CurrentLevel", currentlevelIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene(currentscene);
    }
}
