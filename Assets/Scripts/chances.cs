using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class chances : MonoBehaviour
{
    [SerializeField] TMP_Text chanceText;
    [SerializeField] TMP_Text obstaclehitText;
    [SerializeField] TMP_Text finalobstaclehits;
    [SerializeField] Levelmanager levelmanager;
    [SerializeField] deathManager deathmanager;
    [SerializeField] AudioClip playerdeathsound;
    [SerializeField] float delay = 1f;

    public GameObject Player;
   public int chance;
   public int chancetaken => levelmanager.CurrentLevelData.maxHits - chance;

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
        chance -= amount;

        obstaclehitText.text = playerhitobstacle.ToString("00");
        finalobstaclehits.text = obstaclehitText.text;
        chanceText.text = chance.ToString("00");

        if (chance <= 0)
        {
            AudioSource.PlayClipAtPoint(playerdeathsound, Camera.main.transform.position);
            Player.GetComponent<MeshRenderer>().enabled = false;
            Player.GetComponent<Collider>().enabled = false;
           StartCoroutine(playerdeath());

        }
    }

    public IEnumerator playerdeath()
    {
        yield return new WaitForSeconds(delay);
      deathmanager.deadthseq();
    }
}
