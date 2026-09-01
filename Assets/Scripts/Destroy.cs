using System.Collections;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    [SerializeField] GameObject particleeffect;
    const string playerTag = "Player";

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(playerTag))
        {
            Instantiate(particleeffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        else
        {
            Destroy(gameObject);
        }
    }

}
