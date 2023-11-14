using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public float health = 100f;
    public float damage = 20f;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        health -= damage;
        if (health <= 0)
        {            
            Destroy(gameObject, 0.2f);
        }
    }

    
}
