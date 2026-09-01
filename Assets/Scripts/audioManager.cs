using UnityEngine;

public class audioManager : MonoBehaviour
{
    [SerializeField] AudioSource level1to4;
    [SerializeField] AudioSource level5to8;
    [SerializeField] AudioSource level9n10;

    public void playLevelMusic(int level)
    {
        level1to4.Stop();
        level5to8.Stop();
        level9n10.Stop();


        if (level >= 1 && level <= 4)
        {
            level1to4.Play();
            level5to8.Stop();
            level9n10.Stop();
        }
        else if (level >= 5 && level <= 8)
        {
            level1to4.Stop();
            level5to8.Play();
            level9n10.Stop();
        }
        else if (level >= 9 && level <= 10)
        {
            level1to4.Stop();
            level5to8.Stop();
            level9n10.Play();
        }
    }
}
