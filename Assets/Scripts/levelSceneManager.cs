using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSceneManager : MonoBehaviour
{
    [SerializeField] GameObject[] levelbuttons;
    [SerializeField] GameObject[] lockedbuttons;
    const string startscene = "GameScene";
    const string HighestUnlockedLevelKey = "HighestUnlockedLevel";

    int currentlevelindex;

     void Start()
    {

        int highestunlockedlevel = PlayerPrefs.GetInt(HighestUnlockedLevelKey, 0);

        for (int i = 0; i < levelbuttons.Length; i++)
        {
            bool unlocked = i <= highestunlockedlevel;

            Button button = levelbuttons[i].GetComponent<Button>();

            button.interactable = unlocked;


            lockedbuttons[i].SetActive(!unlocked);
        }
    }
    public void SelectLevel(int levelIndex)
    {
        PlayerPrefs.SetInt("CurrentLevel",levelIndex);
        PlayerPrefs.Save();

        SceneManager.LoadScene(startscene);
        Debug.Log(levelIndex);
    }
}
