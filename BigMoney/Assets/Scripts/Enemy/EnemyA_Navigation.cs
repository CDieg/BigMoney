using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyA_Navigation : MonoBehaviour
{
    public Transform player;
    private UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    void Update()
    {
        agent.destination = player.position;
    }
}