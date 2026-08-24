using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour
{

    [SerializeField] GameObject[] obstaclesandpickups;
    [SerializeField] Transform[] Spawners;
    [SerializeField] LevelData leveldata;

    float timer;

    Quaternion rotation;

     void Start()
     {
        timer = leveldata.spawnInterval;
        StartCoroutine(PickupspawnRoutine());
     }

    IEnumerator PickupspawnRoutine()
    {
        while (true)
        {
            int randomspawn = Random.Range(0, Spawners.Length);
            float randomchance = Random.Range(0f, 100f);

            int randompickupsNobstacles;

            if (randomchance < leveldata.triangleSpawnChance)
            {
                randompickupsNobstacles = 2;
            }

            else
            {
                randompickupsNobstacles = Random.Range(0, 2);
            }


            if (randompickupsNobstacles == 2)
            {
                rotation = Quaternion.Euler(90f, 0f, 0f);
            }

            else
            {
                rotation = Quaternion.identity;
            }


            BoxCollider zone = Spawners[randomspawn].GetComponent<BoxCollider>();

            float xposition = Random.Range(-120f, 120f);
            float zposition = Random.Range(zone.bounds.min.z, zone.bounds.max.z);

            Vector3 SpawnPosition = new Vector3(xposition, Spawners[randomspawn].position.y, zposition);
            Instantiate(obstaclesandpickups[randompickupsNobstacles], SpawnPosition, rotation);
            yield return new WaitForSeconds(timer);
        }
    }
}