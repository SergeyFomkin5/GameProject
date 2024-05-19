using UnityEngine;

public class EnemyAttack: MonoBehaviour
{
    private float time;
    public float DamageZombie = 0.3f;
    public Animator animator;
    public GameObject PlayerHP;
    HpBar PlayerHealth;
    private void Start()
    {
        PlayerHealth = PlayerHP.GetComponent<HpBar>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("AttackZombie");

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetTrigger("RunZombie");
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            animator.SetTrigger("RunZombie");
        }
        if (other.gameObject.tag == "Player")
        {
            AttackPlayer();
        }
    }
    void AttackPlayer()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            PlayerHealth.HpBarImage.fillAmount -=DamageZombie;
            time = 0;
        }

    }
}
