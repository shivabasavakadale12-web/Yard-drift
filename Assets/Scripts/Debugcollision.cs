using UnityEngine;

public class Debugcollision : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("fuck yeah collision is working, ig issue with size or smtg idk yet :(");
    }
}
