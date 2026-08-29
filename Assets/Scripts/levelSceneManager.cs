using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class levelSceneManager : MonoBehaviour
{
    [SerializeField] GameObject[] levelbuttons;
    const string startscene = "GameScene";

    int currentlevelindex;

     void Start()
    {
        int highestunlockedlevel = PlayerPrefs.GetInt("highestunlockedlevel", 0);

        for (int i = 0; i < levelbuttons.Length; i++)
        {
            levelbuttons[i].GetComponent<Button>().interactable = i <= highestunlockedlevel;
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
