using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Animator animator;
    public Transform player;
    public HealthBar healthBar;

    public int maxHealth = 100;
    int currentHealth;
    public int maxDist = 10;
    public int patrolSpeed = 4;
    public int moveSpeed = 7;

    enum states { isIdle, isChasing, isPatrol };
    states state = states.isIdle;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        healthBar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            //die
            Destroy(gameObject);
        }
    }

    void Update()
    {
        transform.LookAt(player);


        switch (state)
        {
            case states.isIdle:
                transform.position += Vector3.zero;
                StartCoroutine(Wait());
                state = states.isPatrol;

                if(Vector3.Distance(transform.position, player.transform.position) <= maxDist)
                {
                    state = states.isChasing;
                }
                break;

            case states.isChasing:
                transform.LookAt(player);
                transform.position += transform.forward * moveSpeed * Time.deltaTime;
                if(Vector3.Distance(transform.position, player.transform.position) >= maxDist)
                {
                    state = states.isIdle;
                }
                break;

            case states.isPatrol:
                //patrol
                StartCoroutine(Wait());

                if (Vector3.Distance(transform.position, player.transform.position) <= maxDist)
                {
                    state = states.isChasing;
                }
                break;
        }
        
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5f);
    }
}
