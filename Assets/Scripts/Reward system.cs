using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rewardsystem : MonoBehaviour
{
    [SerializeField] TimeManager timemanger;
    [SerializeField] chances chanceManager;
    [SerializeField] GameObject lostpanel;
    [SerializeField] deathManager deathmanager;

    [SerializeField] Button chancerewardbutton;
    [SerializeField] Button timerewardbutton;

    public GameObject player;

    bool rewardused;


    const string TotalTimeKey = "TotalTimeTaken";
    const string totalcheancekey = "TotalChanceTaken";

    float totaltimetaken;
    int totalchancetaken;

    public void increasetime()
    {
        rewardused = true;
        timemanger.time += 15;
        lostpanel.SetActive(false);
        timerewardbutton.interactable = false;
        chancerewardbutton.interactable = false;
        deathmanager.continueafterreward();
        Time.timeScale = 1f;
    }

    public void increasechance()
    {
        rewardused = true;
        chanceManager.chance += 2;
        lostpanel.SetActive(false);
        timerewardbutton.interactable = false;
        chancerewardbutton.interactable = false;
        player.GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<Collider>().enabled = true;
        deathmanager.continueafterreward();
        Time.timeScale = 1f;

    }

    void Start()
     {    
       rewardused = false;

       timerewardbutton.interactable = false;
       chancerewardbutton.interactable = false;


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
        if (totaltimetaken >= 100 && !rewardused)
        {
            timerewardbutton.interactable = true;
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

        if (totalchancetaken >= 8 && !rewardused)
        {
            
            chancerewardbutton.interactable = true;
        }

    }
}
