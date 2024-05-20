using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEditor.Experimental.AssetDatabaseExperimental.AssetDatabaseCounters;

public class EnemyHealth : MonoBehaviour
{
    public float value = 100;
    [SerializeField] private TMP_Text counter;
    [SerializeField] private Image HealthEnemy; 
    public NavMeshAgent agent;
    public CapsuleCollider capsuleCollider1, capsuleCollider2;
    public Animator animator;
    public Score score;

    private void Start()
    {
        score = GetComponent<Score>();
    }
    public void DealDamageBody(float damageBody)
    {
        value -= damageBody;
        HealthEnemy.fillAmount -= (damageBody / 100);
        if (value <= 0)
        {
            agent.enabled = false;
            capsuleCollider1.enabled = false;
            capsuleCollider2.enabled = false;
            animator.SetTrigger("DeathEnemy");
            Destroy(gameObject, 10f);
            score.AddPoints();
        }
        

    }
    public void TextCounter(int counterText)
    {
        counter.text = counterText.ToString();
    }
}
