using UnityEngine;
using UnityEngine.SceneManagement;

public class WinManager : MonoBehaviour
{
    const string home = "Main menu";
    const string levelpage = "levels scene";

    public void homebutton()
    {
        SceneManager.LoadScene(home);
    }

    public void levelpagebutton()
    {
        SceneManager.LoadScene(levelpage);
    }

    public void quitbutton()
    {
        Application.Quit();
    }
}
