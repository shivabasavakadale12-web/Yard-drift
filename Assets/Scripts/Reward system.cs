using UnityEngine;
using UnityEngine.SceneManagement;

public class Rewardsystem : MonoBehaviour
{
    [SerializeField] TimeManager timemanger;
    [SerializeField] chances chanceManager;
    [SerializeField] chances chancemanager;
    [SerializeField] GameObject timereward;
    [SerializeField] GameObject chancereward;
    [SerializeField] GameObject lostpanel;
    [SerializeField] deathManager deathmanager;

    public GameObject player;

    bool istimerewardused;
    bool ischancerewardused;

    const string TotalTimeKey = "TotalTimeTaken";
    const string totalcheancekey = "TotalChanceTaken";

    float totaltimetaken;
    int totalchancetaken;

    void Awake()
    {
        timereward.SetActive(false);
        chancereward.SetActive(false);
    }

    public void increasetime()
    {
        istimerewardused = true;
        timemanger.time += 15;
        lostpanel.SetActive(false);
        deathmanager.continueafterreward();
        Time.timeScale = 1f;
    }

    public void increasechance()
    {
        ischancerewardused = true;
        chancemanager.chance += 2;
        lostpanel.SetActive(false);
        deathmanager.continueafterreward();
        player.GetComponent<MeshRenderer>().enabled = true;
        Time.timeScale = 1f;
    }

    void Start()
     {    
       ischancerewardused = false;
       istimerewardused = false;
       totaltimetaken = PlayerPrefs.GetFloat(TotalTimeKey, 0f);
       totalchancetaken = PlayerPrefs.GetInt(totalcheancekey, 0);
    }

    public void SaveLevelTime()
    {
        totaltimetaken += timemanger.timetaken;

        PlayerPrefs.SetFloat(TotalTimeKey, totaltimetaken);
        PlayerPrefs.Save();

    }

    public void checktimereward()
    {
        totaltimetaken = PlayerPrefs.GetFloat(TotalTimeKey, 0f);
        Debug.Log("chance taken = " + totalchancetaken);
        if (totaltimetaken >= 100 && !istimerewardused)
        {
            timereward.SetActive(true);
        }
    }

    public void savelevelchance()
    {
        totalchancetaken += chanceManager.chancetaken;

        PlayerPrefs.SetInt(totalcheancekey, totalchancetaken);
        PlayerPrefs.Save();
    }

    public void checkchancereward()
    {
        totalchancetaken = PlayerPrefs.GetInt(totalcheancekey, 0);

        if (totalchancetaken >= 8 && !ischancerewardused)
        {
            chancereward.SetActive(true);
        }

    }
}
