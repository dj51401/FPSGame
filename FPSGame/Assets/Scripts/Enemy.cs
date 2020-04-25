using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform player;

    public int health = 100;
    public int maxDist = 15;
    public int moveSpeed = 5;



    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            //die
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) <= maxDist)
        {
            transform.position += transform.forward * moveSpeed * Time.deltaTime;
        }
    }

}
