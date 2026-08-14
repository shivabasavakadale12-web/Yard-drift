using UnityEngine;

public class EnemyAi : MonoBehaviour
{
   [SerializeField] float speed = 5f;

    float random1 = 0f;
    float random2 = 5f;
    float offsetx;
    float offsety;

    GameObject player;

    void Start()
    {
         player = GameObject.FindGameObjectWithTag("Player");
        offsetx = Random.Range(random1, random2);
        offsety = Random.Range(random1, random2);
    }

    void Update()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x + offsetx, player.transform.position.y + offsety, 0f);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed) * Time.deltaTime;
    }

}
