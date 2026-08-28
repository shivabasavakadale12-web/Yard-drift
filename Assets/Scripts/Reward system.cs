using UnityEngine;

public class Rewardsystem : MonoBehaviour
{
   [SerializeField] TImeManager timemanger;
   [SerializeField] chances chancemanager;

    public void increasetime()
    {
        timemanger.time += 10; 
    }

    public void increasechance()
    {
        chancemanager.chance += 2;
    }
}
