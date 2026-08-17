using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    enum State { Chasing, Falling }
    State currentState = State.Chasing;

    [SerializeField] float acceleration = 10f;
    [SerializeField] float maxSpeed = 20f;
    [SerializeField] float baselinedistance = 20f;

    float lastframeDistance;

    GameObject player;
    Rigidbody rb;

    bool hasBeenClose = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb = GetComponent<Rigidbody>();
        rb.useGravity = false;
        lastframeDistance = Vector3.Distance(transform.position, player.transform.position);
    }

    void FixedUpdate()
    {
        if (currentState == State.Chasing)
        {
            float currentDistance = Vector3.Distance(transform.position, player.transform.position);
            rb.linearVelocity = Vector3.MoveTowards(rb.linearVelocity, (player.transform.position - transform.position).normalized * maxSpeed,
                                                    acceleration * Time.fixedDeltaTime);

          if(currentDistance < baselinedistance)
            {
                hasBeenClose = false;
            }

            if (currentDistance > lastframeDistance && !hasBeenClose)
            {
                currentState = State.Falling;
                rb.useGravity = true;
            }
            lastframeDistance = currentDistance;
          
        }

    }
}
