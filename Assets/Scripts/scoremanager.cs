using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class scoremanager : MonoBehaviour
{
    [SerializeField] TMP_Text scoretext;
    [SerializeField] TMP_Text targettext;
    [SerializeField] GameObject winpanel;
    [SerializeField] GameObject Winalllevelpanel;
    [SerializeField] Levelmanager levelmanager;
    [SerializeField] TimeManager timemanager;

    [SerializeField] Rewardsystem rewardsystem;

    public static scoremanager instance;

    int score;
    int target;

    private void Awake()
    {
        winpanel.SetActive(false);
        Winalllevelpanel.SetActive(false);
        Time.timeScale = 1f;
        instance = this;
    }

     void Start()
    {
       target = levelmanager.CurrentLevelData.targetTriangles; 
       targettext.text = target.ToString("00");
    }

    public void AddScore(int amount)
    {
       
        score += amount;
        scoretext.text = score.ToString("00");

        if (score == target)
        {
            WinSequence();
        }
    }

    public void WinSequence()
    {
     rewardsystem.SaveLevelTime();
     rewardsystem.savelevelchance();

        if (levelmanager.CurrentLevelData == levelmanager.lastleveldata)
        {
            winpanel.SetActive(false);
            Winalllevelpanel.SetActive(true);
        }

        else
        {
          winpanel.SetActive(true);
        }

     Time.timeScale = 0f;   
    }
}
