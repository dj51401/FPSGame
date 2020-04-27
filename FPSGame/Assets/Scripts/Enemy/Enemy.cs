using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{   // health
    public HealthBar healthBar;
    public int maxHealth = 100;
    int currentHealth;

    int damage = 20;

    //AI
    enum EnemyState { Patrolling, Chasing }
    EnemyState currentState;

    public Transform[] points;
    public Transform player;
    private int destPoint = 0;
    private NavMeshAgent agent;

    public PlayerController playerController;

    void Start()
    {
        //set current health to max
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();

        //if patrolling state then goto the next point
        if (currentState == EnemyState.Patrolling)
        {
            GotoNextPoint();
        }
    }

    void Update()
    {
        if (currentState == EnemyState.Patrolling && agent.remainingDistance < .5f)
        {
            GotoNextPoint();
        }
        //if players within 15m of enemy
        if (Vector3.Distance(transform.position, player.position) < 15f)
        {   //state = chasing
            currentState = EnemyState.Chasing;
        }
        else
        {   //if not then go back to patrolling
            currentState = EnemyState.Patrolling;
            agent.destination = points[destPoint].position;
        }
        //if in chasing state, then chase the player.
        if (currentState == EnemyState.Chasing)
        {
            agent.destination = player.position;
        }
    }

    void GotoNextPoint()
    {   //if no points have been setup
        if (points.Length == 0)
        {
            return;
        }

        //set agent to go to current point
        agent.destination = points[destPoint].position;

        //choose the next point in the array as the destination, cycle to start if necessary
        destPoint = (destPoint + 1) % points.Length;
    }

    void OnCollisionEnter(Collision collision)
    {   //if enemy touches player, it damages the player.
        if(collision.gameObject.tag == "Player")
        {
            playerController.TakeDamage(damage);
            player.transform.position += Vector3.forward;
        }
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
}
