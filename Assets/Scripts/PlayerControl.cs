using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    Vector2 movement;
    Vector3 currentVelocity;
    Rigidbody rb;

    float acceleration = 40f;
    float deceleration = 5f;
    float maxSpeed = 100f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    public void Update()
    {
        Vector3 inputdirection = new Vector3(movement.x, 0, movement.y);
        Vector3 targetVelocity = inputdirection * maxSpeed;

         float rate = inputdirection.magnitude > 0.1f ? acceleration : deceleration;
          currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, rate * Time.deltaTime);
      
       rb.MovePosition(rb.position + currentVelocity * Time.deltaTime);
    }
}
