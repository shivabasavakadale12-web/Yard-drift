using UnityEngine;
using System.Collections;
public class PICKUPS : MonoBehaviour
{

    [SerializeField] GameObject triaglesPrefab;
    [SerializeField] Transform[] Spawners;

    float timer = 1.5f;

     void Start()
    {
        StartCoroutine(PickupspawnRoutine() );
    }

    IEnumerator PickupspawnRoutine()
    {
        while (true)
        {
            int randomspawn = Random.Range(0, Spawners.Length);


            BoxCollider zone = Spawners[randomspawn].GetComponent<BoxCollider>();

            float xposition = Random.Range(-120f, 120f);
            float zposition = Random.Range(zone.bounds.min.z, zone.bounds.max.z);

            Vector3 SpawnPosition = new Vector3(xposition, Spawners[randomspawn].position.y, zposition);
            Instantiate(triaglesPrefab, SpawnPosition, Quaternion.Euler(90f, 0f, 0f));
            yield return new WaitForSeconds(timer);
        }
    }
}
