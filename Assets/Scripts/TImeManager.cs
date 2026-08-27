using TMPro;
using UnityEngine;

public class TImeManager : MonoBehaviour
{

    [SerializeField] TMP_Text timetext;
    [SerializeField] Levelmanager levelmanager;

    float time;

     void Start()
    {
        time = levelmanager.CurrentLevelData.timeLimit;
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
