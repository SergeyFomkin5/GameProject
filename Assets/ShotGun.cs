using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [SerializeField] private GameObject[] Players=new GameObject[2];
    [SerializeField] private GameObject Cub;
    [SerializeField] private Transform TargetMin;
    [SerializeField] private Transform TargetMax;
    [SerializeField] private Transform EndGan;
    [SerializeField] private bool ActiveClone = false, OneOrTwo=true; 
    [SerializeField] private float NextFire;
    RaycastHit hit;
    Ray ray;
    private void Update()
    {
        if (ActiveClone==false&&Input.GetKey(KeyCode.Mouse1) && Time.time > NextFire) 
        {
            NextFire = Time.time + .0f; 
            Shoot();
            ActiveClone = true;
        }
        OneOrTwoPlayer();
    }
    public void Shoot()
    {
        for (int i = 0; i < 13; i++)
        {
            var direction = TargetMax.position - TargetMin.position + Vector3.forward * Random.Range(-3, 3) + Vector3.up * Random.Range(-3, 3);
            ray = new Ray(TargetMin.position, direction);
            Physics.Raycast(ray, out hit);
            Debug.DrawRay(EndGan.position, direction, Color.yellow);
            if (hit.collider.gameObject)
            {
            }
        
        }
    }
    void PlayerClone()
    {
        Instantiate(Cub, hit.point, Quaternion.identity);
        Players[1] = Cub; 
    }
    void OneOrTwoPlayer()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Players[0].SetActive(false);
            Players[1].SetActive(true);
        }
        else
        {
            Players[0].SetActive(true);
            Players[1].SetActive(false);
        }
    }
}
