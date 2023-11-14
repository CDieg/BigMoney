using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private bool canTakeDamage;
    
    [Header("Health")]
    [SerializeField]
    private float health;
    [SerializeField]
    public float maxHealth;
    public float invincibilityTime;

    [Header("Damage Overlay")]
    public Image damageOverlay;
    public float overlayDuration;
    public float overlayFadeSpeed;

    private float overlayTimer;

    void Start()
    {
        health = maxHealth;
        canTakeDamage = true;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 0);
    }

    void Update()
    {
        if (damageOverlay.color.a > 0)
        {
            overlayTimer += Time.deltaTime;
            if (overlayTimer > overlayDuration)
            {
                // Fade
                float tempAlpha = damageOverlay.color.a;
                if (health < 2 && tempAlpha < 0.55f)
                {
                    return;
                }
                else
                {
                    tempAlpha -= Time.deltaTime * overlayFadeSpeed;
                    damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, tempAlpha);
                }
                
            }
            
            
        }
    }

    public void UpdateHealthUI()
    {
        // TODO Health UI
        Debug.Log(health);
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {            
            health -= damage;
            StartCoroutine(InvincibilityTime());
            overlayTimer = 0;
            damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);
            if (health <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void heal (int healAmount)
    {
        health += healAmount;
    }



    IEnumerator InvincibilityTime()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(invincibilityTime);
        canTakeDamage = true;
    }
}
