using UnityEngine;

public class deathManager : MonoBehaviour
{
    [SerializeField] GameObject lostpanel;
    [SerializeField] Rewardsystem rewardsystem;

    public bool isdead {  get; private set; }

    private void Awake()
    {
        lostpanel.SetActive(false);
    }

    public void deadthseq()
    {
        if (isdead) return;

        isdead = true;

        lostpanel.SetActive(true);

        rewardsystem.checktimereward();

        Time.timeScale = 0f;
    }
}
