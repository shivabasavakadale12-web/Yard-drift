using UnityEngine;

public class EnemyAi : MonoBehaviour
{
   [SerializeField] float speed = 5f;

    float random1 = 0f;
    float random2 = 5f;
    float offsetx;
    float offsetZ;

    GameObject player;
    Rigidbody rb;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        offsetx = Random.Range(random1, random2);
        offsetZ = Random.Range(random1, random2);
    }

    void FixedUpdate()
    {
        Vector3 targetPosition = new Vector3(player.transform.position.x + offsetx * speed,
                     player.transform.position.y, player.transform.position.z + offsetZ * speed);
        Vector3 newposition = Vector3.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        rb.MovePosition(newposition);
    }

}
