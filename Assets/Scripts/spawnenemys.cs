using UnityEngine;
using System.Collections;
public class spawnenemys : MonoBehaviour
{
    [SerializeField] GameObject[] enemys;
    [SerializeField] Transform[] spawns;
 
    float timetospawn = 3f;
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
            Instantiate(enemys[randomenemy], spawns[randomspawn].position, Quaternion.identity);
            yield return new WaitForSeconds(timetospawn);
        }
    }

}
