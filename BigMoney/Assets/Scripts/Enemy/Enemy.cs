using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private StateMachine stateMachine;
    private UnityEngine.AI.NavMeshAgent agent;
    private GameObject player;
    
    
    public NavMeshAgent Agent {  get => agent; }
    public GameObject Player { get => player; }
    public Path path;

    [Header("Seight")]
    public float sightDistance = 20f;
    public float enemyFOV = 85f;
    public float eyeHight;
    [SerializeField]
    public float waitForSearch;

    [Header("Weapon")]
    public Transform gunBarrel;
    [SerializeField]
    public float fireRate;
    [SerializeField]
    public float bulletSpeed;
    [SerializeField]
    private string currentState;
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        stateMachine.Initialize();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
    }

    public bool CanSeePlayer()
    {
        if (player != null)
        {
            // Player seen by distance
            if (Vector3.Distance(transform.position, player.transform.position) < sightDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHight);
                float angleToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angleToPlayer >= -enemyFOV && angleToPlayer <= enemyFOV)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sightDistance)) 
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            // Debug enemy raycast to localize player
                            Debug.DrawRay(ray.origin, ray.direction * sightDistance);
                            return true;
                        }
                    }                    
                }
            }
        }
        return false;
    }
}
