using UnityEngine;

public class scoremanager : MonoBehaviour
{

 public static scoremanager instance;

    int score;

    private void Awake()
    {
        instance = this;
    }

    public void AddScore(int amount)
    {
        score += amount;

        Debug.Log("Score: " + score);
    }
}
