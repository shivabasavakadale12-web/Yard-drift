using System.Collections;
using UnityEngine;
public class spawnenemys : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] Transform[] spawns;
 
    float timetospawn;
    void Start()
    {
      StartCoroutine(spawnEnemy());
    }
    
    IEnumerator spawnEnemy()
{
    while (true)
    {
        int randomenemy = Random.Range(0, enemys.Length);
    int randomspawn = Random.Range(0, spawns.Length);

    BoxCollider zone = spawns[randomspawn].GetComponent<BoxCollider>();

    float xposition = Random.Range(zone.bounds.min.x, zone.bounds.max.x);
     float zposition = Random.Range(zone.bounds.min.z, zone.bounds.max.z);

     Vector3 spawnPosition = new Vector3(xposition, spawns[randomspawn].position.y, zposition);
     Instantiate(enemys[randomenemy], spawnPosition, Quaternion.identity);

    float randomtime = Random.Range(1f, 3f);
    yield return new WaitForSeconds(randomtime);
}
}
}
