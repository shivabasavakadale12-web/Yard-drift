using UnityEngine;
using System.Collections;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
public class Debugcollision : MonoBehaviour
{
    [SerializeField] AudioSource pickupAudio;
    [SerializeField] AudioSource crashaudio;
    private void OnCollisionEnter(Collision other)
    {

        if (other.gameObject.CompareTag("Enemy"))
        {
            crashaudio.Play();
            chances.instance.playerhit(1);        
        }

        if (other.gameObject.CompareTag("pickups"))
        {
            pickupAudio.Play();
        }
    }
}
