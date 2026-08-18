using UnityEngine;
using System.Collections;
public class Triangle_pickup : MonoBehaviour
{

    int score = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(playercollidedRoutine() );
           Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

    }

    IEnumerator playercollidedRoutine()
    {
        while (true)
        {
            scoremanager.instance.AddScore(score);  
            Debug.Log("Player picked up the triangle! Total score: " + score);
            yield break;
        }
    }
    
}
