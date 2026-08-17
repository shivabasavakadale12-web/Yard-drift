using UnityEngine;
using System.Collections;
public class PICKUPS : MonoBehaviour
{

    [SerializeField] GameObject triaglesPrefab;
    [SerializeField] Transform[] Spawners;

    float timer = 2.2f;

    float countspawn;

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

            float xposition = Random.Range(zone.bounds.min.x, zone.bounds.max.x);
            float zposition = Random.Range(zone.bounds.min.z, zone.bounds.max.z);

            Vector3 SpawnPosition = new Vector3(xposition, Spawners[randomspawn].position.y, zposition);
            Instantiate(triaglesPrefab, SpawnPosition, Quaternion.Euler(90f, 0f, 0f));
            countspawn++;
            Debug.Log(countspawn);
            yield return new WaitForSeconds(timer);
        }
    }
}
