using UnityEngine;

public class Triangle_pickup : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player picked up the triangle!");       
            Destroy(gameObject);
        }
    }
}
