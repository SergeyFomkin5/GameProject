using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GanLazer : MonoBehaviour
{
    [SerializeField] Image GanShopBar;
    [SerializeField] bool ActiveGan=true;

    [SerializeField] private Transform TargetMin;
    [SerializeField] private Transform TargetMax;
    [SerializeField] private Transform EndGan;
    [SerializeField] private LineRenderer laser;
    [SerializeField] private float NextFire;
    [SerializeField] private float Damage=0.2f;
    [SerializeField] private WaitForSeconds LaserTime = new WaitForSeconds(0.05f);
    private RaycastHit hit;
    private Ray ray;


    [SerializeField] GameObject Player;
    HpBar playerController;
    private void Start()
    {
        playerController = Player.GetComponent<HpBar>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        SystemGan();
    }
    IEnumerator ShotEffect()
    {
        laser.enabled = true;
        yield return LaserTime;
        laser.enabled = false;
    }
    void SystemGan()
    {
        
       
            var direction = TargetMax.position - TargetMin.position;
            ray = new Ray(TargetMin.position, direction);
            Physics.Raycast(ray, out hit);
            

            if (Input.GetKey(KeyCode.Mouse0) && Time.time > NextFire)
            {
            SystemGanShop();
            NextFire = Time.time + .3f;
            if (ActiveGan == true)
            {
                StartCoroutine(ShotEffect());

                laser.SetPosition(0, EndGan.position);
                laser.SetPosition(1, TargetMax.position);
                GanActiveFalse();
                if (hit.collider.gameObject)
                {
                    var rb=hit.collider.gameObject.AddComponent<Rigidbody>();
                    rb.AddForce(Vector3.forward * 100);
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
