using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject levelEnd;
    public GameObject playerUI;

    [SerializeField]
    private int maxEnemies = 20;
    [SerializeField]
    private int enemiesNumber;
    [SerializeField]
    private int enemiesToWin = 50;

    [Header("Spawner 01")]
    [SerializeField]
    private GameObject enemy01;
    [SerializeField]
    private float chaserInterval01 = 5f;
    [SerializeField]
    private GameObject SpawnerPosition01;

    [Header("Spawner 02")]
    [SerializeField]
    private GameObject enemy02;
    [SerializeField]
    private float chaserInterval02 = 5f;
    [SerializeField]
    private GameObject SpawnerPosition02;

    [Header("Spawner 03")]
    [SerializeField]
    private GameObject enemy03;
    [SerializeField]
    private float chaserInterval03 = 5f;
    [SerializeField]
    private GameObject SpawnerPosition03;

    [Header("Spawner 04")]
    [SerializeField]
    private GameObject enemy04;
    [SerializeField]
    private float chaserInterval04 = 5f;
    [SerializeField]
    private GameObject SpawnerPosition04;



    private void Start()
    {
        enemiesNumber = 0;
    }

    public void StartSpawner()
    {
        StartCoroutine(spawnEnemy(chaserInterval01, enemy01, SpawnerPosition01));
        StartCoroutine(spawnEnemy(chaserInterval02, enemy02, SpawnerPosition02));
        StartCoroutine(spawnEnemy(chaserInterval03, enemy03, SpawnerPosition03));
        StartCoroutine(spawnEnemy(chaserInterval04, enemy04, SpawnerPosition04));        
    }

    public void enemyDied ()
    {
        enemiesNumber--;
        enemiesToWin--;
        if (enemiesToWin <= 0)
        {
            levelEnd.SetActive(true);
            playerUI.SetActive(false);
            GameManager.instance.UpdateGameState(GameState.Pause);
        }
    }


    private IEnumerator spawnEnemy(float interval, GameObject enemy, GameObject position)
    {
        yield return new WaitForSeconds (interval);
        if (enemiesNumber < maxEnemies)
        {
            GameObject newEnemy = Instantiate(enemy, position.transform.position, Quaternion.identity);
            enemiesNumber++;
        }        
        StartCoroutine(spawnEnemy(interval, enemy, position));
    }
}
