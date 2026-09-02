using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] ParticleSystem playerboost;
    [SerializeField] float turnspeed = 100f;
    [SerializeField] float maxTurnAngle = 80f;
    Vector2 movement;
    Vector3 currentVelocity;
    Rigidbody rb;
    Quaternion startRotation;
    float currenzangle;
    float acceleration = 80f;
    float deceleration = 30f;
    float maxSpeed = 200f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        startRotation = transform.rotation;
    }


    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();

        if (context.performed)
        {
            playerboost.Play();
        }

        if (context.canceled)
        {
            playerboost.Stop();
        }
    }

    public void FixedUpdate()
    {
        currenzangle += movement.x * turnspeed * Time.fixedDeltaTime;

        currenzangle = Mathf.Clamp(currenzangle, -maxTurnAngle, maxTurnAngle);

        Quaternion Targetrotation = startRotation * Quaternion.Euler(0f, 0f, -currenzangle);

        transform.rotation = Quaternion.Lerp(transform.rotation, Targetrotation, 10f * Time.fixedDeltaTime);

        Vector3 inputdirection = new Vector3(movement.x, 0, movement.y);
        Vector3 targetVelocity = inputdirection * maxSpeed;

         float rate = inputdirection.magnitude > 0.1f ? acceleration : deceleration;
          currentVelocity = Vector3.MoveTowards(currentVelocity, targetVelocity, rate * Time.fixedDeltaTime);
      
     rb.linearVelocity = currentVelocity;
    }
}
