using UnityEngine;
using TMPro;

public class Levelmanager : MonoBehaviour
{
    [SerializeField] TMP_Text leveltext;
    [SerializeField] LevelData[] levels;

    int currentlevelIndex = 0;

    public LevelData CurrentLevelData => levels[currentlevelIndex];

     void Start()
    {
        leveltext.text = CurrentLevelData.levelNumber.ToString();
    }

}
