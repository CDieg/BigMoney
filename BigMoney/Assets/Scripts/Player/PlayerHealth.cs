using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    [Header("Health")]
    [SerializeField]
    private int health;
    [SerializeField]
    public int maxHealth = 3;

    [Header("Damage Overlay")]
    public Image damageOverlay;
    public float overlayDuration;
    public float overlayFadeSpeed;

    private float overlayTimer;

    void Start()
    {
        health = maxHealth;
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
                tempAlpha -= Time.deltaTime * overlayFadeSpeed;
                damageOverlay.color = new Color (damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, tempAlpha);
            }
        }
    }

    public void UpdateHealthUI()
    {
        Debug.Log(health);
    }

    public void TakeDamage(int damage)
    {
        health -= damage;
        overlayTimer = 0;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);
    }
}
