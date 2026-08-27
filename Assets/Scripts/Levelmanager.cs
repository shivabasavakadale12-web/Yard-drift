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
        Debug.Log("SAVED LEVEL INDEX = " + currentlevelIndex);

        leveltext.text = CurrentLevelData.levelNumber.ToString("00");
    }

    public void nextlevel()
    {
        currentleveltext.text = leveltext.text;
        winpanel.SetActive(false);
        currentlevelIndex++;
        PlayerPrefs.SetInt("CurrentLevel", currentlevelIndex);
        PlayerPrefs.Save();

        if (currentlevelIndex >= levels.Length)
        {
            currentlevelIndex = 0;
            PlayerPrefs.SetInt("CurrentLevel", currentlevelIndex);
            PlayerPrefs.Save();
            // won whole game logic and then its done 
        }
        SceneManager.LoadScene(currentscene);
        
    }

    public void restartgame()
    {
        winpanel.SetActive(false);
        SceneManager.LoadScene(currentscene);
    }
}
