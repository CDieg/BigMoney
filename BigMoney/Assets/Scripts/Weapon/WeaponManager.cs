using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    private RaycastHit hit;
    [SerializeField] private bool isShooting, readyToShoot, reloading;

    [SerializeField]
    private PlayerUI playerUI;
    [SerializeField]
    private GameObject reloadText;
    private int ammoLeft;
    public ParticleSystem muzzleFlash;


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

        float x = Random.Range(-horizontalSpread, horizontalSpread);
        float y = Random.Range(-verticalSpread, verticalSpread);

        Vector3 direction = shotOrigin.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(shotOrigin.transform.position, direction, out hit, range))
        {
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
        Invoke("ReloadFinish", reloadTime);
        // Reload UI Message
        playerUI.reloadShow();
    }

    private void ReloadFinish()
    {
        ammoLeft = magazineSize;
        reloading = false;
        // Reload UI Message
        playerUI.reloadHide();
    }
}
