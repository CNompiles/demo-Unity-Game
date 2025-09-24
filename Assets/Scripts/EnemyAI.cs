using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform player; //o Παιτης  
    private NavMeshAgent agent;
    [HideInInspector] public float defaultSpeed; // η αρχική ταχύτητα
    public float stopDistance = 10f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (player == null)
        {
            GameObject p = GameObject.FindGameObjectWithTag("Player");
            if (p != null) player = p.transform;
        }

    }
    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stopDistance) 
        {
            agent.isStopped = false;
            agent.SetDestination(player.position);
        }
        else
        {
            agent.isStopped = true;
            GetComponent<EnemyShooting>()?.TryShoot(player.position);
        }
       
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
    }
}
