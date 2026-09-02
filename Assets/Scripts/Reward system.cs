using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Rewardsystem : MonoBehaviour
{
    [SerializeField] TimeManager timemanger;
    [SerializeField] chances chanceManager;
    [SerializeField] GameObject lostpanel;
    [SerializeField] deathManager deathmanager;
    [SerializeField] Button chancerewardbutton;
    [SerializeField] Button timerewardbutton;
    [SerializeField] GameObject timerewardtext;
    [SerializeField] GameObject chancerewardtext;
    [SerializeField] GameObject timerewardavaible;
    [SerializeField] GameObject chancerewardavaible;

    public GameObject player;

    bool rewardused;


    const string TotalTimeKey = "TotalTimeTaken";
    const string totalcheancekey = "TotalChanceTaken";

    float totaltimetaken;
    int totalchancetaken;

    public void increasetime()
    {
        timerewardtext.SetActive(true);
        rewardused = true;
        timemanger.time += 15;
        lostpanel.SetActive(false);
        timerewardbutton.interactable = false;
        chancerewardbutton.interactable = false;
        deathmanager.continueafterreward();
        Time.timeScale = 1f;
        Invoke("destroytimetext", 2f);
    }

    void destroytimetext()
    {
        timerewardtext.SetActive(false);
    }

    public void increasechance()
    {
        chancerewardtext.SetActive(true);
        rewardused = true;
        chanceManager.chance += 2;
        lostpanel.SetActive(false);
        timerewardbutton.interactable = false;
        chancerewardbutton.interactable = false;
        player.GetComponent<MeshRenderer>().enabled = true;
        player.GetComponent<Collider>().enabled = true;
        deathmanager.continueafterreward();
        Time.timeScale = 1f;
        Invoke("destroychancetext", 2f); 
    }
    void destroychancetext()
    {
        chancerewardtext.SetActive(false);
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
        if (totaltimetaken >= 100 && !rewardused)
        {
            timerewardavaible.SetActive(true);
            timerewardbutton.interactable = true;
            Invoke("offtimeavaibletxt", 1f);
        }
    }

    void offtimeavaibletxt()
    {
        timerewardavaible.SetActive(false);
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

            chancerewardavaible.SetActive(true);
            chancerewardbutton.interactable = true;
            Invoke("offchanceavaibletext", 1.2f);
        }

    }

    void offchanceavaibletext()
    {
        chancerewardavaible.SetActive(false);
    }
}
