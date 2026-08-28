using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TImeManager : MonoBehaviour
{

    [SerializeField] TMP_Text timetext;
    [SerializeField] TMP_Text timeconsumedtext;
    [SerializeField] Levelmanager levelmanager;

    public float time;

    public float timeconsumed;

    const string currentscene = "GameScene";

     void Start()
    {
        time = levelmanager.CurrentLevelData.timeLimit;
        timeconsumed = time;
    }


    void Update()
    {
        time -= Time.deltaTime;
        timetext.text = Mathf.CeilToInt(time).ToString();
    
        timeconsumedtext.text = Mathf.CeilToInt(time).ToString();

        if (time <= 0 )
        {
           
            SceneManager.LoadScene(currentscene);
            Debug.Log("game over mate!");
        }
    }
}
