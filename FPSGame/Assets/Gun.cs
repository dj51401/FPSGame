using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public Camera fpsCamera;

    // Update is called once per frame
    void Update()
    {
        //if l click
        if (Input.GetButtonDown("Fire1"))
        {   //shoot
            Shoot();
        }
    }

    void Shoot()
    {
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
        }
    }
}
