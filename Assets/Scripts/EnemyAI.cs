using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    public Transform target; //o ������  
    private NavMeshAgent agent;
    [HideInInspector] public float defaultSpeed; // � ������ ��������

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        defaultSpeed = agent.speed; 

    }


    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
       
    }

    public NavMeshAgent GetAgent()
    {
        return agent;
    }
}
