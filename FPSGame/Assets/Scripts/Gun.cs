using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public float impactForce = 30f;
    public float reloadTime = 1f;

    public int maxAmmo = 15;
    public int currentAmmo;

    private bool isReloading = false;

    public Camera fpsCamera;
    public ParticleSystem muzzleFlash;
    public GameObject bulletHole;

    public Animator animator;

    void Start()
    {
        currentAmmo = maxAmmo;
    }

    // Update is called once per frame
    void Update()
    {
        if (isReloading)
        {
            return;
        }
        if(currentAmmo <= 0 || Input.GetKeyDown(KeyCode.R))
        {
            StartCoroutine(Reload());
            return;
        }

        //if left click
        if (Input.GetButtonDown("Fire1"))
        {   //change animation
            Shoot();
        }
    }



    IEnumerator Reload()
    {
        isReloading = true;
        Debug.Log("Reloading...");

        animator.SetBool("Reloading", true);

        yield return new WaitForSeconds(reloadTime);

        animator.SetBool("Reloading", false);

        currentAmmo = maxAmmo;
        isReloading = false;
    }

    void Shoot()
    {
        animator.SetTrigger("Shooting");
        muzzleFlash.Play();
        currentAmmo--;
        //shoot a raycast at camera position out forward, check what the hit object is if within range.
        RaycastHit hit;
        if(Physics.Raycast(fpsCamera.transform.position, fpsCamera.transform.forward, out hit, range))
        {
            //if it hits the enemy
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if(enemy != null)
            {
                //damage enemy
                enemy.TakeDamage(damage);
            }

            if(hit.rigidbody != null)
            {  
                hit.rigidbody.AddForce(-hit.normal * impactForce);
            }

            GameObject impactGO = Instantiate(bulletHole, hit.point, Quaternion.LookRotation(hit.normal));
            impactGO.transform.parent = hit.transform;
            Destroy(impactGO, 2f);
        }
    }
}
