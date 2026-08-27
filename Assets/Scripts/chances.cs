using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chances : MonoBehaviour
{
    [SerializeField] TMP_Text chanceText;
    [SerializeField] TMP_Text obstaclehitText;
    [SerializeField] Levelmanager levelmanager;

    public GameObject Player;

    int chance;
    int playerhitobstacle = 0;


    const string gamescene = "GameScene";

    public static chances instance;

     void Awake()
    {
        instance = this;
    }

     void Start()
    {
      chance = levelmanager.CurrentLevelData.maxHits;    
      chanceText.text = chance.ToString("00");
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
