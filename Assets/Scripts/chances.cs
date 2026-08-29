using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class chances : MonoBehaviour
{
    [SerializeField] TMP_Text chanceText;
    [SerializeField] TMP_Text obstaclehitText;
    [SerializeField] TMP_Text finalobstaclehits;
    [SerializeField] Levelmanager levelmanager;
    [SerializeField] deathManager deathmanager;

    public GameObject Player;

   public int chance;
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

        finalobstaclehits.text = obstaclehitText.text;

        if (playerhitobstacle == chance)
        {
            Player.GetComponent<MeshRenderer>().enabled = false;
            Invoke("playerdeath", 3f);

        }
    }

    public void playerdeath()
    {
      deathmanager.deadthseq();
    }
}
