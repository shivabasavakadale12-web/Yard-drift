using TMPro;
using UnityEngine;

public class Levelmanager : MonoBehaviour
{

    [SerializeField] TMP_Text timetext;
    float time = 60;
   

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
