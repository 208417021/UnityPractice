using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float speed = 300f;
    NavMeshAgent enemy;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        enemy.speed = speed;
    }

    void Update()
    {
        enemy.SetDestination(target.position);
    }
}
