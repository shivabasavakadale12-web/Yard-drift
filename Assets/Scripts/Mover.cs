using UnityEngine;

public class Mover : MonoBehaviour
{
   float speed;
   Vector3 vector3;

   [SerializeField] float randomspeed1 = 100f;
   [SerializeField] float randomspeed2 = 200f;


    Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        float randomspeed = Random.Range(randomspeed1, randomspeed2);
        float angle = Random.Range(0f, 360f);
        speed = randomspeed;

        vector3 = Quaternion.Euler(0, angle, 0) * Vector3.forward;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = vector3 * speed;
    }
}
