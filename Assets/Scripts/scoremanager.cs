using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class scoremanager : MonoBehaviour
{
    [SerializeField] TMP_Text scoretext;
    [SerializeField] TMP_Text targettext;
    [SerializeField] GameObject winpanel;
    [SerializeField] LevelData leveldata;

    public static scoremanager instance;

    int score;
    int target;

    private void Awake()
    {
        winpanel.SetActive(false);
        Time.timeScale = 1f;
        target = leveldata.targetTriangles;
        instance = this;
        targettext.text = target.ToString("00");
    }

    private void Update()
    {
        WinSequence();
    }

    public void AddScore(int amount)
    {
        score += amount;
        scoretext.text = score.ToString("00");
    }

    public void WinSequence()
    {
        if (score == target)
        {
            winpanel.SetActive(true);
            Debug.Log("You Win!");
            Time.timeScale = 0f;
        }
    }
}
