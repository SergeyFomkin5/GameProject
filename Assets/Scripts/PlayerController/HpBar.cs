using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image HpBarImage;
    [SerializeField] private float DamagePlayer = 0.2f;
    [SerializeField] private Timer timer;

    public void PlayerDamageFromWater()
    {
       HpBarImage.fillAmount-=0.1f*Time.deltaTime;
    }
    private void Update()
    {
        DeathPlayer();
    }
    void DeathPlayer()
    {
        if (HpBarImage.fillAmount <= 0)
        {
            timer.counteTimerWave = 3;
            Debug.Log(timer.counteTimerWave);
        }
    }
}
