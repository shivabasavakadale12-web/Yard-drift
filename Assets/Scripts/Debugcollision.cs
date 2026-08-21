using UnityEngine;
using System.Collections;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
public class Debugcollision : MonoBehaviour
{


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            chances.instance.playerhit(1);
           
        }

    }
}
