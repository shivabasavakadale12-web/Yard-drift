using UnityEngine;

public class Rewardsystem : MonoBehaviour
{
   [SerializeField] TimeManager timemanger;
   [SerializeField] chances chancemanager;
   [SerializeField] GameObject timereward;

    const string TotalTimeKey = "TotalTimeTaken";

    float totaltimetaken;

    void Awake()
    {
        timereward.SetActive(false);
    }
    public void increasetime()
    {
        timemanger.time += 15; 
    }

    public void increasechance()
    {
        chancemanager.chance += 2;
    }

     void Start()
     {      
      totaltimetaken = PlayerPrefs.GetFloat(TotalTimeKey, 0f);
     }

    public void SaveLevelTime()
    {
        totaltimetaken += timemanger.timetaken;

        PlayerPrefs.SetFloat(TotalTimeKey, totaltimetaken);
        PlayerPrefs.Save();
        Debug.Log("total time taken is: " + totaltimetaken);
    }

    public void checktimereward()
    {
        totaltimetaken = PlayerPrefs.GetFloat(TotalTimeKey, 0f);

        if (totaltimetaken >= 100)
        {
            timereward.SetActive(true);
        }
    }
}
