using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTrigger : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner spawner;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            spawner.StartSpawner();
        }
    }
}
