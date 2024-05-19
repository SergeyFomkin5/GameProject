using UnityEngine;
using UnityEngine.UI;

public class HpBar : MonoBehaviour
{
    [SerializeField] public Image HpBarImage;
    [SerializeField] private float DamagePlayer=0.2f;
    public void PlayerDamageFromWater()
    {
       HpBarImage.fillAmount-=0.1f*Time.deltaTime;
    }
    void DeathPlayer()
    {
        if (HpBarImage.fillAmount == 0)
        {
            
        }
    }
}
