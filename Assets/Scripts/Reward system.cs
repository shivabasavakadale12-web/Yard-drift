using UnityEngine;

public class Rewardsystem : MonoBehaviour
{
   [SerializeField] TimeManager timemanger;
   [SerializeField] chances chancemanager;

    const string TotalTimeKey = "TotalTimeTaken";

    float totaltimetaken;
    public void increasetime()
    {
        timemanger.time += 10; 
    }

    public void increasechance()
    {
        chancemanager.chance += 2;
    }

     void Start()
     {      
      totaltimetaken = PlayerPrefs.GetFloat(TotalTimeKey, totaltimetaken);
     }

    public void SaveLevelTime()
    {
        totaltimetaken += timemanger.timetaken;

        PlayerPrefs.SetFloat(TotalTimeKey, totaltimetaken);
        PlayerPrefs.Save();
    }
}
