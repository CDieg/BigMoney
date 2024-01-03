using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEditor.Experimental.GraphView;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField]
    private bool canTakeDamage;

    
    [Header("Health")]
    [SerializeField]
    private float health;
    [SerializeField]
    public float maxHealth;
    private PlayerUI playerUI;
    public float invincibilityTime;

    [Header("Damage Overlay")]
    public Image damageOverlay;
    public float overlayDuration;
    public float overlayFadeSpeed;

    private float overlayTimer;

    void Start()
    {
        health = maxHealth;
        playerUI = GetComponent<PlayerUI>();
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
        if (health / maxHealth > 0.84) {
            playerUI.UpdateHealthUI(6);
        } else if (health / maxHealth > 0.68) {
            playerUI.UpdateHealthUI(5);
        } else if (health / maxHealth > 0.52) {
            playerUI.UpdateHealthUI(4);
        } else if (health / maxHealth > 0.36) {
            playerUI.UpdateHealthUI(3);
        } else if (health / maxHealth > 0.14) {
            playerUI.UpdateHealthUI(2);
        } else if (health / maxHealth > 0) {
            playerUI.UpdateHealthUI(1);
        } else if (health / maxHealth <= 0)
        {
            playerUI.UpdateHealthUI(0);
        }
    }

    public void TakeDamage(float damage)
    {
        if (canTakeDamage)
        {            
            health -= damage;
            UpdateHealthUI();
            StartCoroutine(InvincibilityTime());
            overlayTimer = 0;
            damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);
            if (health <= 0)
            {
                //FindObjectOfType<GameManager>().GameOver();
                GameManager.instance.GameOver();
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
