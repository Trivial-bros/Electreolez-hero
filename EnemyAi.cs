using UnityEngine;
using UnityEngine.AI;

public class EnemyAi : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform box;

    private void Update()
    {
        agent.SetDestination(box.position);
    }
}
