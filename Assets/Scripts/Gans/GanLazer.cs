using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GanLazer : MonoBehaviour
{
    [SerializeField] Image GanShopBar;
    [SerializeField] bool ActiveGan=true;

    [SerializeField] public int counter = 0;
    [SerializeField] private Transform TargetMin;
    [SerializeField] private Transform TargetMax;
    [SerializeField] private Transform EndGan;
    [SerializeField] private LineRenderer laser;
    [SerializeField] private float NextFire;
    [SerializeField] private float Damage=50;
    [SerializeField] private WaitForSeconds LaserTime = new WaitForSeconds(0.05f);
    [SerializeField] private AudioSource ShootSound;
    private RaycastHit hit;
    private Ray ray;


    [SerializeField] GameObject Player;
    HpBar playerController;
    private void Start()
    {
        playerController = Player.GetComponent<HpBar>();
        ShootSound = GetComponent<AudioSource>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        SystemGan();
    }
    IEnumerator ShotEffect()
    {
        ShootSound.Play();
        laser.enabled = true;
        yield return LaserTime;
        laser.enabled = false;
    }
    void SystemGan()
    {
        
       
            var direction = TargetMax.position - TargetMin.position;
            ray = new Ray(TargetMin.position, direction);
            Physics.Raycast(ray, out hit);
            

            if ((Input.GetKey(KeyCode.Mouse0) && !Input.GetKey(KeyCode.R)) && Time.time > NextFire)
            {
            SystemGanShop();
            NextFire = Time.time + .3f;
            if (ActiveGan == true)
            {
                StartCoroutine(ShotEffect());

                laser.SetPosition(0, EndGan.position);
                laser.SetPosition(1, TargetMax.position);
                GanActiveFalse();
                if (hit.collider.gameObject.tag=="Enemy")
                {
                    
                    var Enemy = hit.collider.gameObject;
                    if (Enemy != null)
                    {
                        var hpEnemy = Enemy.GetComponent<EnemyHealth>();
                        hpEnemy.DealDamageBody(20);
                        if (hpEnemy.value <= 0)
                        {
                            counter++;
                            hpEnemy.TextCounter(counter);
                        }
                    }

                }
            }
            }
        
        if(Input.GetKey(KeyCode.R))
        {
            GanShopBar.fillAmount += 0.5f*Time.deltaTime;
        }
    }
    void SystemGanShop()
    {
        GanActiveTrue();
        if(Input.GetKey(KeyCode.Mouse0))
        {
            GanShopBar.fillAmount -= 0.1f;
            
        }
    }
    void GanActiveTrue()
    {
       
        if (GanShopBar.fillAmount > 0)
        {
            ActiveGan = true;
        }
    }
    void GanActiveFalse()
    {
        if (GanShopBar.fillAmount == 0)
        {
            ActiveGan = false;
        }
    }
}
