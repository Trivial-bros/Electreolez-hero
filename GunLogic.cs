using EZCameraShake;
using UnityEngine;
using System.Collections;
using TMPro;

public class GunLogic : MonoBehaviour
{
    public int damage = 40;
    public float range = 100f;
    public float fireRate = 1f;
    public float scopedFOV = 15f;
    public float reloadTime = 1f;
    public int maxAmmo = 10;
    public bool Sniper;
    public bool AssaultRifle;

    int currentAmmo;
    [HideInInspector]
    public bool isReloading = false;
    [HideInInspector]
    public bool isScoped = false;

    public Camera cam;
    public Camera MainCam;
    public Animator animator;
    public ParticleSystem muzzleflash;
    public GameObject impactEffect;
    public TextMeshProUGUI CurrentAmmoText;
    public TextMeshProUGUI MaxAmmoText;
    public playerhealth playerhealth;

    private float nextTimeToAttack = 0f;

    private void Start()
    {
        currentAmmo = maxAmmo;
        
    }

    private void OnEnable()
    {

        isScoped = false;
        isReloading = false;
        animator.SetBool("Reloading", false);
    }

    private void Update()
    {
        CurrentAmmoText.text = currentAmmo + "";
        MaxAmmoText.text = maxAmmo + "";
        if (playerhealth.isDead)
            isScoped = false;

        if (isReloading)
            return;

        

        if (Input.GetKeyDown(KeyCode.R) && !isReloading)
        {
            StartCoroutine(Reload());
        }

        if(currentAmmo <= 0)
        {
            StartCoroutine(Reload());
            return;
        }

        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = !isScoped;
            animator.SetBool("isScoped", isScoped);           
        }

        

        if (isScoped == true)
        {
            StartCoroutine(ZoomIn());
        }
        else
        {
            MainCam.fieldOfView = 45f;
        }
        

        if (Input.GetButton("Fire1") && Time.time >= nextTimeToAttack)
        {
            Sounds();
            nextTimeToAttack = Time.time + 1f / fireRate;
            shoot();
        }
        
    }

    void shoot()
    {
        muzzleflash.Play();
        CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);

        currentAmmo--;

        RaycastHit hitinfo;
        if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hitinfo, range))
        {           
            enemyhealth target = hitinfo.transform.GetComponent<enemyhealth>();
            if (target != null)
            {
                target.takeDamage(damage);
            }

            GameObject impactGO = Instantiate(impactEffect, hitinfo.point, Quaternion.LookRotation(hitinfo.normal));
            Destroy(impactGO, 0.5f);
        }
    }

    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);
        currentAmmo = maxAmmo;

        animator.SetBool("Reloading", false);

        isReloading = false;
    }

    void Sounds()
    {
        if (1 > 0)
        {
            if (Input.GetButton("Fire1"))
            {
                FindObjectOfType<Audio_Manager>().Play("GunShot");
            }
        }
        if (AssaultRifle == true)
        {
            if (Input.GetButton("Fire1"))
            {
                FindObjectOfType<Audio_Manager>().Play("GunShot");

            }   
        }
    }

    IEnumerator ZoomIn()
    {
        yield return new WaitForSeconds(0.25f);
        MainCam.fieldOfView = scopedFOV;
    }
}
