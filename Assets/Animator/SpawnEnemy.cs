using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject[] Enemy;
    [SerializeField] private Transform[] SpawnPosition;
    [SerializeField] private float timer;
    [SerializeField] public float value=5;
    private GanLazer counterEnemys;
    private void Start()
    {
         counterEnemys = GetComponent<GanLazer>();
    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > value)
        {
            
            var Enemys = Enemy[Random.Range(0, 1)];
            var EnemysPosition = SpawnPosition[Random.Range(0, 10)];
            Instantiate(Enemys, EnemysPosition.position, Quaternion.identity);
            if (counterEnemys != null)
            {
                if (counterEnemys.counter >= 2)
                {
                    value = 3;
                }
                else
                {
                    value = 5;
                }
            }
            timer = 0;
        }
    }
}
