using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{

    private NavMeshAgent agent;
    public float moveRadius;
    private Vector3 currentDestination;
    
    
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        FindNewDestination();
        
    }

    private void FindNewDestination()
    {
        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;
        NavMeshHit rayHit;
        NavMesh.SamplePosition (randomDirection, out rayHit, moveRadius, 1);
        Vector3 newDestination = rayHit.position;
        currentDestination = newDestination;        
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending)
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    FindNewDestination();
                }
            }
        }


        agent.SetDestination (currentDestination);        
    }
}
