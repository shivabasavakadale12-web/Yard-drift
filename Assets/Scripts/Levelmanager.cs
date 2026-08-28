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

    public void Awake()
    {
        currentlevelIndex = PlayerPrefs.GetInt("CurrentLevel", 0);
    }

    void Start()
    {
        currentlevelIndex = PlayerPrefs.GetInt("CurrentLevel", 0);
        leveltext.text = CurrentLevelData.levelNumber.ToString("00");
        currentleveltext.text = leveltext.text;
    }

    public void nextlevel()
    {
        winpanel.SetActive(false);
        currentlevelIndex++;
        PlayerPrefs.SetInt("CurrentLevel", currentlevelIndex);
        PlayerPrefs.Save();

        if (currentlevelIndex >= levels.Length)
        {
            currentlevelIndex = 0;
            PlayerPrefs.SetInt("CurrentLevel", currentlevelIndex);
            PlayerPrefs.Save();
     
        }
        SceneManager.LoadScene(currentscene);
        
    }

    public void restartgame()
    {
        winpanel.SetActive(false);
        SceneManager.LoadScene(currentscene);
    }
}
