using UnityEngine;
using System.Collections;
public class Triangle_pickup : MonoBehaviour
{
    [SerializeField] GameObject particleeffect;

    int score = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
           Destroy(gameObject);
        }
        else if (other.gameObject.CompareTag("Player"))
        
        {
            Instantiate(particleeffect, transform.position, Quaternion.identity);
            StartCoroutine(playercollidedRoutine());
            Destroy(gameObject);
        }

    }

    IEnumerator playercollidedRoutine()
    {
        while (true)
        {
            scoremanager.instance.AddScore(score);  
            yield break;
        }
    }
    
}
