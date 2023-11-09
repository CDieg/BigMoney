using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    [SerializeField]
    private bool canShoot;
    [SerializeField]
    private int currentAmmoInClip;
    [SerializeField]
    private bool hasShot = false;
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
    public GameObject shotOrigin;
   

    [Header("Weapon Settings")]
    [SerializeField]
    private float fireRate = 0.1f;
    [SerializeField]
    private int clipSize = 6;
    [SerializeField]
    private float reloadTime = 2f;


    private void Start()
    {
        currentAmmoInClip = clipSize;
        canShoot = true;
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
                StartCoroutine(ReloadTimer());
            }            
        }
    }
    public void Fire1()
    {
        RaycastHit hit;

        if (Physics.Raycast(shotOrigin.transform.position, shotOrigin.transform.forward, out hit, range) && canShoot)
        {
            hasShot = true;
            Debug.DrawLine(shotOrigin.transform.position, hit.point, Color.red, 10f);            
        }
    }

    IEnumerator ShootWeapon()
    {
        yield return new WaitForSeconds(fireRate);
        if (currentAmmoInClip > 0)
        {
            canShoot = true;
        }
    }

    IEnumerator ReloadTimer()
    {
        // Reload Message
        if (currentAmmoInClip == 0) playerUI.reloadShow();

        yield return new WaitForSeconds(reloadTime);
        currentAmmoInClip = clipSize;
        canShoot = true;

        // Reload Message
        playerUI.reloadHide();
    }
}
