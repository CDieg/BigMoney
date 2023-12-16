using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyManager : MonoBehaviour
{
    public float health = 100f;
    public float damage = 20f;
    public int points = 5;
    private GameObject player;
    private GameObject scoreManager;
    private GameObject spawner;
    private bool isDead = false;
    public GameObject deathExplosion;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        scoreManager = GameObject.FindGameObjectWithTag("Score");
        spawner = GameObject.FindGameObjectWithTag("Spawner");
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
    public void Hit(float damage)
    {
        // SFX
        SoundManager.PlayOneShotSound(SoundManager.Sound.EnemyLaserHit);


        health -= damage;
        if (health <= 0 && !isDead)
        {
            isDead = true;

            // SFX
            SoundManager.PlayOneShotSound(SoundManager.Sound.EnemyExplosion1);
            Invoke("Coins", 0.2f);

            // Player explosion effect
            GameObject explosion = Instantiate(deathExplosion) as GameObject;
            explosion.transform.position = gameObject.transform.position + new Vector3(0, 1, 0);
            scoreManager.GetComponent<ScoreManager>().AddPoints(points);
            spawner.GetComponent<EnemySpawner>().enemyDied();
            Destroy(gameObject);
        }
    }
    private void Coins()
    {
        // SFX
        SoundManager.PlayOneShotSound(SoundManager.Sound.EnemyCoins);
    }
    
}
