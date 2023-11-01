using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private int health;
    [SerializeField]
    public int maxHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
    }
}
