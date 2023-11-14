using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponManager : MonoBehaviour
{
    [SerializeField]
    private bool canShoot;
    [SerializeField]
    private bool hasShot = false;
    [SerializeField]
    private bool canReload;
    [SerializeField]
    private bool hasReload = false;
    [SerializeField]
    private int currentAmmoInClip;
   
    [SerializeField]
    private PlayerUI playerUI;
    [SerializeField]
    private GameObject reloadText;


    //
    // TODO Implement weapon class
    // private Weapon weapon;
    //

    [Header("Shooting Controls")]
    public float range = 100f;
    public float damage = 25f;
    public GameObject shotOrigin;
   

    [Header("Weapon Settings")]
    [SerializeField]
    private float fireRate = 0.1f;
    [SerializeField]
    private int clipSize = 6;
    [SerializeField]
    private float reloadTime = 2f;
    // Muzzle
    [SerializeField]
    private Image muzzleFlash;
    [SerializeField]
    private Sprite[] flashes;

    private void Start()
    {
        currentAmmoInClip = clipSize;
        canShoot = true;
        canReload = false;
        hasReload = false;
    }
    void Update()
    {

        if (hasShot && currentAmmoInClip > 0)
        {
            hasShot = false;
            canShoot = false;
            currentAmmoInClip--;
            StartCoroutine(ShootWeapon());
            if (currentAmmoInClip == 0)
            {
                canReload = false;
                hasReload = false;
                StartCoroutine(ReloadTimer());
            }
            else canReload = true;
        }

        if (!canReload)
        {
            hasReload = false;
        }
        else if (canReload && hasReload) StartCoroutine(ReloadTimer());
    }





    //
    // Weapon
    //
    public void Fire1()
    {
        RaycastHit hit;

        if (Physics.Raycast(shotOrigin.transform.position, shotOrigin.transform.forward, out hit, range) && canShoot)
        {
            hasShot = true;
            
            // Debug
            Debug.DrawLine(shotOrigin.transform.position, hit.point, Color.red, 10f);

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if (enemyManager != null)
            {
                enemyManager.Hit(damage);
            }
        }
    }
    public void Reload()
    {
        hasReload = true;        
    }


    //
    // Coroutines
    //
    IEnumerator ShootWeapon()
    {
        StartCoroutine(MuzzleFlash());
        yield return new WaitForSeconds(fireRate);
        if (currentAmmoInClip > 0)
        {
            canShoot = true;
        }
    }
    IEnumerator ReloadTimer()
    {
        // Reload Message
        if (currentAmmoInClip == 0 || hasReload) playerUI.reloadShow();

        hasReload = false;
        canReload = false;
        canShoot = false;
        yield return new WaitForSeconds(reloadTime);
        currentAmmoInClip = clipSize;
        canShoot = true;
        

        // Reload Message
        playerUI.reloadHide();
    }
    IEnumerator MuzzleFlash()
    {
        muzzleFlash.sprite = flashes[Random.Range(0, flashes.Length)];
        muzzleFlash.color = new Color(1f,1f,1f,0.5f);
        yield return new WaitForSeconds(0.05f);
        muzzleFlash.sprite = null;
        muzzleFlash.color = new Color(0, 0, 0, 0);
    }
}
