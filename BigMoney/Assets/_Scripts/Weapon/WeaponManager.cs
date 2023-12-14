using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class WeaponManager : MonoBehaviour
{
    private Ray ray;
    private RaycastHit hit;
    [SerializeField] private bool isShooting, readyToShoot, reloading;

    [SerializeField]
    private PlayerUI playerUI;
    [SerializeField]
    private GameObject reloadText;
    private int ammoLeft;
    public ParticleSystem muzzleFlash;
    public GameObject bulletImpactMetal;
    private GameObject impact;
    [SerializeField]
    private GameObject VFXProjectile;
    private Quaternion rotation;
    [SerializeField]
    private Animator playerAnimator;
    [SerializeField]
    private Animator weaponAnimator;

    private AudioSource audioReload;


    //
    // TODO Implement weapon class
    // private Weapon weapon;
    //

    [Header("Shooting Controls")]
    public float range = 100f;
    public float damage = 25f;
    public GameObject shotOrigin;
    public Transform raycastOrigin;
    public Transform raycastTarget;


    [Header("Weapon Settings")]
    [SerializeField]
    private float fireRate = 0.2f;
    [SerializeField]
    private int magazineSize = 100;
    [SerializeField]
    private float reloadTime = 2f;
    [SerializeField]
    private bool isAutomatic;
    [SerializeField]
    private float horizontalSpread, verticalSpread, burstDelay;
    [SerializeField]
    private int bulletsPerBurst;
    private int bulletsShot;


    private void Awake()
    {
        ammoLeft = magazineSize;
        readyToShoot = true;
    }
    
    void Update()
    {        
        if (isShooting && readyToShoot && !reloading && ammoLeft > 0)
        {
            bulletsShot = bulletsPerBurst;
            PerformShot();
        }
        if (isShooting && !reloading && ammoLeft == 0)
        {
            Reload();
        }

    }


    //
    // Weapon
    //
    public void StartShot()
    {
        isShooting = true;
    }

    public void EndShot()
    {
        isShooting = false;
    }
    
    public void PerformShot()
    {
        readyToShoot = false;
        muzzleFlash.Play();

        // SFX
        SoundManager.PlayOneShotSound(SoundManager.Sound.LaserRifle_Shot);

        ray.origin = raycastOrigin.position;
        float x = Random.Range(-horizontalSpread, horizontalSpread);
        float y = Random.Range(-verticalSpread, verticalSpread);
        ray.direction = raycastTarget.position - raycastOrigin.position + new Vector3(x, y, 0);

        // Get rotation for bullet direction
        rotation = Quaternion.LookRotation(ray.direction, Vector3.up);

        GameObject vfx;
        vfx = Instantiate(VFXProjectile, raycastOrigin.transform.position, rotation);

        if (Physics.Raycast(ray, out hit, range))
        {
            //Debug.DrawLine(ray.origin, hit.point, Color.red, 5.0f);
            
            impact = Instantiate(bulletImpactMetal, hit.point, Quaternion.identity) as GameObject;
            impact.transform.forward = hit.normal;

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if (enemyManager != null)
            {
                enemyManager.Hit(damage);
            }
        }

        
        
        ammoLeft--;
        bulletsShot--;

        if (bulletsShot > 0 && ammoLeft > 0)
        {
            Invoke("ResumeBurst", burstDelay);
        }
        else
        {
            Invoke("ResetShot", fireRate);

            if (!isAutomatic)
            {
                EndShot();
            }
        }

        // Animations
        playerAnimator.SetTrigger("Shoot");
        weaponAnimator.SetTrigger("Shoot");

    }

    private void ResumeBurst()
    {
        readyToShoot = true;
        PerformShot();
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    public void Reload()
    {
        reloading = true;
        // SFX
        audioReload = SoundManager.PlaySound(SoundManager.Sound.LaserRifle_Reload);
        Invoke("ReloadFinish", reloadTime);
        Invoke("StopReloadSound", reloadTime);

        // Reload UI Message
        playerUI.reloadShow();

        // Animations
        playerAnimator.SetBool("Reload", true);
        weaponAnimator.SetBool("Reload", true);
    }

    private void ReloadFinish()
    {
        ammoLeft = magazineSize;
        reloading = false;
        // Reload UI Message
        playerUI.reloadHide();

        // Animations
        playerAnimator.SetBool("Reload", false);
        weaponAnimator.SetBool("Reload", false);
    }

    private void StopReloadSound()
    {
        audioReload.Stop();
    }
}
