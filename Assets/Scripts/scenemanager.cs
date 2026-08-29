using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    const string gamescene = "GameScene";
    const string levelscene = "levels scene";

    public void playbutton()
    {
        SceneManager.LoadScene(gamescene);
    }

    public void levelscenebutton()
    {
        SceneManager.LoadScene(levelscene);
    }    

    public void quitbutton()
    {
        Application.Quit();
    }
}
