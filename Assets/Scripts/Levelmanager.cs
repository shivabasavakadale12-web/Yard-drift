using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class Levelmanager : MonoBehaviour
{
    [SerializeField] TMP_Text leveltext;
    [SerializeField] LevelData[] levels;

    int currentlevelIndex = 0;

     void Start()
    {
        leveltext.text = levels[currentlevelIndex].levelNumber.ToString();
    }

}
