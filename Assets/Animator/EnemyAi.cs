using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    [SerializeField] private Animator animator;
    public PlayerController player;
    public List<Transform> patrolPoints;
    public float viewAngel;
    public bool _isPlayerNoticed=false;
    public float StopDistance = 1.1f;

    private NavMeshAgent _navMeshAgent;

    void Start()
    {
        InitComponentLinks();
        PickNewPatrolPoint();
        _navMeshAgent.stoppingDistance = 0;
    }
    void Update()
    { 
        ChaseUpdate();
        NoticePlayerUpdate();
        PatrolUpdate();
    }
    void PickNewPatrolPoint()
    {
        _navMeshAgent.destination = patrolPoints[Random.Range(0, patrolPoints.Count)].position;
    }
    void PatrolUpdate()
    {

        if (_navMeshAgent.remainingDistance <= _navMeshAgent.stoppingDistance && !_isPlayerNoticed)
        {
            PickNewPatrolPoint();
        }
    }
    void InitComponentLinks()
    {
        _navMeshAgent = GetComponent<NavMeshAgent>();
    }
    void NoticePlayerUpdate()
    {
        var direction = player.transform.position - transform.position;
        _isPlayerNoticed = false;

        if (Vector3.Angle(transform.forward, direction) < viewAngel)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position + Vector3.up, direction, out hit))
            {
                if (hit.collider.gameObject == player.gameObject)
                {
                    _isPlayerNoticed = true;
                }
            }
        }
    }
    void ChaseUpdate()
    {
        if (_isPlayerNoticed) _navMeshAgent.destination = player.transform.position;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            _navMeshAgent.stoppingDistance = StopDistance;
        }
        else
        {
            _navMeshAgent.stoppingDistance = 0;
        }
    }
}
