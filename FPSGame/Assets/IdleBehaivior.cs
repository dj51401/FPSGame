using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaivior : StateMachineBehaviour
{
    public GameObject enemy;

    public float patrolDelay = 5f;
    public float timer;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        animator.SetBool("isIdle", true);
        animator.SetBool("isPatrol", false);

    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer += Time.deltaTime;
        if (animator.GetBool("isPatrol") == false)
        {
            enemy.GetComponent<EnemyPatrol>().enabled = false;
        }

        if (timer >= patrolDelay)
        {
            animator.SetBool("isIdle", false);
            animator.SetBool("isPatrol", true);
        }

    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
