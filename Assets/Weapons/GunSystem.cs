using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GunSystem : MonoBehaviour
{
    public int damage;
    public float rof, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot, bulletsHit;
    //bools
    bool shooting, readyToShoot, reloading;

    //Reference
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;

    public ParticleSystem bulletStream;

    //Graphics
    public GameObject muzzleFlash, bulletHoleGraphic;
    //public TextMeshProUGUI text;
    //public CamShake camShake;
    //public float camShakeMagnitude, camShakeDuration;

    private void Awake()
    {
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        if (Input.GetButtonDown("Fire1")) {
            this.Shoot();
        }
        
        
        
      
        //MyInput(); // not my input, garbage name

        //SetTextt
        //text.SetText(bulletsLeft + " / " + magazineSize);
    }
    
    private void Shoot()
    {
        //readyToShoot = false;

        bulletStream.Play();
        RaycastHit objHit; // stores info about hit

        //Spread
        //float x = Random.Range(-spread, spread);
        //float y = Random.Range(-spread, spread);

        //Calculate Direction with Spread
        //Vector3 spreadDir = fpsCam.transform.forward + new Vector3(x, y, 0);

        if (Physics.Raycast(fpsCam.transform.position,fpsCam.transform.forward, out objHit, range)) {
            // bullet collision... calc damage, etc.
            Debug.Log(objHit.transform.name);
            //if (rayHit.collider.CompareTag("Enemy"))
            //rayHit.collider.GetComponent<ShootingAi>().TakeDamage(damage);
            Target target = objHit.transform.GetComponent<Target>();
            if (target != null) {
                target.TakeDamage(10.0f);
            }
        }

        bulletsLeft--;
        bulletsShot++;



        //ShakeCamera
        //camShake.Shake(camShakeDuration, camShakeMagnitude);

        //Graphics <- what you doing with quaternions, my guy?
        //Instantiate(bulletHoleGraphic, rayHit.point, Quaternion.Euler(0, 180, 0));
        //Instantiate(muzzleFlash, attackPoint.position, Quaternion.identity);

        

        //Invoke("ResetShot", rof);

        //if(bulletsShot > 0 && bulletsLeft > 0)
        //    Invoke("Shoot", timeBetweenShots);
    }
        private void ResetShoot()
    {
        readyToShoot = true;

        bulletsLeft--;
    }
    private void Reload()
    {
        reloading = true;
        Invoke("ReloadFinished", reloadTime);
    }

    private void ReloadFinished()
    {
        bulletsLeft = magazineSize;
        reloading = false;
    }
}




/*
if (allowButtonHold)
        shooting = Input.GetKey(KeyCode.Mouse0);
    else 
        shooting = Input.GetKeyDown(KeyCode.Mouse0);

    if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading) 
        Reload();

    //Shoot
    if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        bulletsShot = bulletsPerTap; // weird way to do this
        Shoot();
        
        

*/