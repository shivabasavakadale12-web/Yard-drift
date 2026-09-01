using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Levelmanager : MonoBehaviour
{
    [SerializeField] GameObject winpanel;
    [SerializeField] TMP_Text leveltext;
    [SerializeField] TMP_Text currentleveltext;
    [SerializeField] LevelData[] levels;
    [SerializeField] audioManager audiomanager;

    int currentlevelIndex = 0;

    const string currentscene = "GameScene";
    const string HighestUnlockedLevelKey = "HighestUnlockedLevel";


    public LevelData CurrentLevelData => levels[currentlevelIndex];
    public LevelData lastleveldata => levels[levels.Length - 1];

    void Start()
    {
        currentlevelIndex = PlayerPrefs.GetInt("CurrentLevel", 0);
        leveltext.text = CurrentLevelData.levelNumber.ToString("00");
        currentleveltext.text = leveltext.text;

        audiomanager.playLevelMusic(CurrentLevelData.levelNumber);
    }

    public void nextlevel()
    {
        winpanel.SetActive(false);


        if (currentlevelIndex == levels.Length - 1) return;
    
        currentlevelIndex++;

        PlayerPrefs.SetInt("CurrentLevel", currentlevelIndex);

          int highestUnlockedLevel =
            PlayerPrefs.GetInt(HighestUnlockedLevelKey, 0);

        if (currentlevelIndex > highestUnlockedLevel)
        {
            PlayerPrefs.SetInt(HighestUnlockedLevelKey, currentlevelIndex);
        }
        PlayerPrefs.Save();

        SceneManager.LoadScene(currentscene);
    }

    public void restartgame()
    {
        winpanel.SetActive(false);
        SceneManager.LoadScene(currentscene);
    }
}
