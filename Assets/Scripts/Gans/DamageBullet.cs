using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBullet : MonoBehaviour
{
    [SerializeField] private float Damage=2;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            var Enemy = GameObject.FindGameObjectWithTag("Enemy");
            var HpEnemy = GetComponent<EnemyHealth>();
            HpEnemy.value-=Damage;
        }
    }
}
