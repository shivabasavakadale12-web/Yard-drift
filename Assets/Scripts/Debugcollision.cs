using UnityEngine;
using System.Collections;
using Unity.VectorGraphics;
using UnityEngine.SceneManagement;
public class Debugcollision : MonoBehaviour
{

    const string gamescene = "GameScene";

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            //  StartCoroutine(startdeadrotine() );
        }

    }

    IEnumerator startdeadrotine()
    {
        GetComponent<MeshRenderer>().enabled = false;
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(gamescene);
    }


}
