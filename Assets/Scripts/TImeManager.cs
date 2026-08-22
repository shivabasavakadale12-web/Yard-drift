using TMPro;
using UnityEngine;

public class TImeManager : MonoBehaviour
{

    [SerializeField] TMP_Text timetext;
    [SerializeField] LevelData leveldata;

    float time;

     void Start()
    {
        time = leveldata.timeLimit;

        Debug.Log("LevelData reference: " + leveldata);
        Debug.Log("Level time: " + leveldata.timeLimit);
    }

    void Update()
    {
        time -= Time.deltaTime;
        timetext.text = Mathf.CeilToInt(time).ToString();
       Debug.Log(time);

        if (time <= 0 )
        {
            Debug.Log("game over mate!");
        }
    }
}
