using UnityEngine;

public class ShotGun : MonoBehaviour
{
    [SerializeField] private Transform Cub;
    [SerializeField] private Transform TargetMin;
    [SerializeField] private Transform TargetMax;
    [SerializeField] private Transform EndGan;
    [SerializeField] private float NextFire;
    RaycastHit hit;
    Ray ray;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && Time.time > NextFire) 
        {
            NextFire = Time.time + .0f; 
            Shoot(); 
        }
    }
    public void Shoot()
    {
        for (int i = 0; i < 10; i++)
        {
            var direction =TargetMax.position - TargetMin.position+ Vector3.forward* Random.Range(-3, 3)+ Vector3.up * Random.Range(-3, 3);
            ray = new Ray(TargetMin.position, direction);
            Physics.Raycast(ray, out hit);
            Debug.DrawRay(EndGan.position, direction, Color.yellow);
            if (hit.collider.gameObject)
            {
                Instantiate(Cub, hit.point, Quaternion.identity);
            }
        }   
        
    }
}
