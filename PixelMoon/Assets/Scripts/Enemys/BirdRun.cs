using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdRun : StateMachineBehaviour
{
    [SerializeField] private float speed = 2.5f;
    [SerializeField] private float attackRange = 3f;

    [Range(0f, 20f)] 
    [SerializeField] private float followRange = 2f;

    Transform player;
    Transform bird;
    Rigidbody2D rb;
    FlipEnemy flipper;
    Player pl;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        flipper = animator.GetComponent<FlipEnemy>();
        player = GameObject.FindObjectOfType<Player>().transform;
        bird = animator.GetComponent<Transform>();
        rb = animator.GetComponent<Rigidbody2D>();
        pl = player.GetComponent<Player>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        flipper.LookAtPlayer();

        Vector2 target = new Vector2(player.position.x, player.position.y + 2);
        Vector2 newPos = Vector2.MoveTowards(rb.position, target, speed * Time.fixedDeltaTime);

        if ((Vector2.Distance(player.position, rb.position) <= followRange) && !pl.hidden)
            rb.MovePosition(newPos);
        
        if((Vector2.Distance(player.position, rb.position) <= attackRange) && !pl.hidden)
        {
            animator.SetTrigger("Attack");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("Attack");
    }

    
}
