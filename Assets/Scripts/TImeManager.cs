using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour
{

    [SerializeField] TMP_Text timetext;
    [SerializeField] TMP_Text timeconsumedtext;
    [SerializeField] Levelmanager levelmanager;
    [SerializeField] GameObject lostpanel;

    public float time;

    public float timetaken => levelmanager.CurrentLevelData.timeLimit - time;

    const string currentscene = "GameScene";

     void Start()
    {
        time = levelmanager.CurrentLevelData.timeLimit;
     }


    void Update()
    {
        time -= Time.deltaTime;
        timetext.text = Mathf.CeilToInt(time).ToString();
        timeconsumedtext.text = timetaken.ToString("00");

        if (time <= 0 )
        {
           
            lostpanel.SetActive(true);
        }
    }
}
