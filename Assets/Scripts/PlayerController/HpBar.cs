using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] private Image HpBarImage;
    [SerializeField] private float DamagePlayer=0.2f;
    [SerializeField] private Timer Timer;
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
        if (HpBarImage.fillAmount == 0)
        {
            Timer.counteTimerWave=3;
        }
    }
}
