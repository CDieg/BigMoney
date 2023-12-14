using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyTrigger : MonoBehaviour
{
    [SerializeField]
    private EnemySpawner spawner;
    private bool isActive = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActive)
        {
            isActive = true;
            spawner.StartSpawner();
        }
    }
}
