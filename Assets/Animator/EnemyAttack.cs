using UnityEngine;
using UnityEngine.UI;

public class EnemyAttack: MonoBehaviour
{
    private float time;
    public float DamageEnemy = 30f;
    public Animator animator;
    [SerializeField] private Image HpBarPlayer;
    private void Start()
    {
        animator.SetBool("RunEnemy", true);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("AttackEnemy", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("RunEnemy", true);
            animator.SetBool("AttackEnemy", false);
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag != "Player")
        {
            animator.SetBool("RunEnemy" , true);
        }
        else if (other.gameObject.tag == "Player")
        {
            AttackPlayer();
        }
    }
    void AttackPlayer()
    {
        time += Time.deltaTime;
        if (time > 1)
        {
            animator.SetBool("AttackEnemy", true);
            HpBarPlayer.fillAmount -=(DamageEnemy/100);
            time = 0;
        }

    }
}
