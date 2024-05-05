 using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class ShotGun : MonoBehaviour
{
    [SerializeField] private Rigidbody _Bullet;
    [SerializeField] private Transform TargetMin;
    [SerializeField] private Transform TargetMax;
    [SerializeField] private Transform EndGan;
    [SerializeField] private bool OneOrTwo=true; 
    [SerializeField] private float NextFire;
    [SerializeField] private float speedBullet;
    Rigidbody bullet;
    RaycastHit hit;
    Ray ray;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Mouse1) && Time.time > NextFire) 
        {
            NextFire = Time.time + .3f; 
            Shoot();
        }
        Invoke("DestroyBullet", 1f+Time.deltaTime);
    }
    public void Shoot()
    {
        for (int i = 0; i < 13; i++)
        {
            SpawnBullet();
            var direction = TargetMax.position - TargetMin.position + Vector3.forward * Random.Range(-3, 3) + Vector3.up * Random.Range(-3, 3);
            ray = new Ray(TargetMin.position, direction);
            Physics.Raycast(ray, out hit);
            Debug.DrawRay(EndGan.position, direction, Color.yellow);
            if (hit.collider.gameObject)
            {
            }
        }
    }
    public void SpawnBullet()
    {
        bullet = Instantiate(_Bullet, EndGan.position + Vector3.forward * Random.Range(-0.2f, 0.2f) + Vector3.up * Random.Range(-0.2f, 0.2f), EndGan.localRotation);
        bullet.AddForce(EndGan.forward * speedBullet * Random.Range(1, 6));
    }
    public void DestroyBullet()
    {
        Destroy(GameObject.FindGameObjectWithTag(bullet.gameObject.tag), 0.1f);
    }
}
