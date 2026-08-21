using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chances : MonoBehaviour
{
    [SerializeField] TMP_Text chanceText;
    [SerializeField] TMP_Text obstaclehitText;

    public GameObject Player;

    int chance = 5;
    int playerhitobstacle = 0;


    const string gamescene = "GameScene";

    public static chances instance;

     void Awake()
    {
       chanceText.text = chance.ToString("00");
        instance = this;
    }

    public void playerhit(int amount)
    {
        playerhitobstacle += amount;
        obstaclehitText.text = playerhitobstacle.ToString("00");

        if (playerhitobstacle == chance)
        {
            Player.GetComponent<MeshRenderer>().enabled = false;
            Invoke("playerdeath", 3f);

        }
    }

     void playerdeath()
    {
        SceneManager.LoadScene(gamescene);
        Debug.Log("Game Over");
    }
}
