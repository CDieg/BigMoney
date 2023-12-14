using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject chaser;
    [SerializeField]
    private float chaserInterval = 5f;
    [SerializeField]
    private Vector3 SpawnerPosition;

    private void Start()
    {
        {
            SpawnerPosition = transform.position;
        }
    }

    public void StartSpawner()
    {
        StartCoroutine(spawnEnemy(chaserInterval, chaser));
    }
    private IEnumerator spawnEnemy(float interval, GameObject enemy)
    {
        yield return new WaitForSeconds (interval);
        GameObject newEnemy = Instantiate(enemy, SpawnerPosition, Quaternion.identity);
        StartCoroutine(spawnEnemy(interval, enemy));
    }
}
