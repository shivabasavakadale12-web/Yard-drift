using UnityEngine;

public class scaleplayer : MonoBehaviour
{
  [SerializeField] float scaleobject = 5f;
     void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("pickups"))
        {
            playerlevelup();
        }   
    }
        void playerlevelup()
        {
            transform.localScale = new Vector3(transform.localScale.x + scaleobject, transform.localScale.y + scaleobject, 2.39f);
        }
}
