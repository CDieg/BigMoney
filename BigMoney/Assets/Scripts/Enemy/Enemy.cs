using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;

    public NavMeshAgent Agent {  get => agent; }

    [SerializeField]
    private string currentState;
    public Path path;

    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine.Initialize();
    }

    void Update()
    {
        
    }
}
