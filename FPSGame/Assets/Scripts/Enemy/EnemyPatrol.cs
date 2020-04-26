using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyPatrol : MonoBehaviour
{
    public Transform[] PatrolPoints;
    private int destPoint = 0;
    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if(PatrolPoints.Length == 0)
        {
            return;
        }

        agent.destination = PatrolPoints[destPoint].position;

        destPoint = (destPoint + 1) % PatrolPoints.Length;
    }

    // Update is called once per frame
    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < .05f)
        {
            GotoNextPoint();
        }
    }
}
