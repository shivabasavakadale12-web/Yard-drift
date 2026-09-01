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

        rewardsystem.savelevelchance();
        rewardsystem.SaveLevelTime();

        rewardsystem.checktimereward();
        rewardsystem.checkchancereward();

        Time.timeScale = 0f;
    }

    public void continueafterreward()
    {
        isdead = false;
    }
}