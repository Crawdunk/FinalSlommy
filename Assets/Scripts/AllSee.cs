using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AIState { Idle, Chase }

public class AllSee : MonoBehaviour
{
    public GameObject player;
    public float agroRange;
    public float moveSpeed;
    public AIState currentState;
    public Rigidbody2D rb;
    public Animator anim;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentState = AIState.Idle;
        player = GameObject.FindWithTag("Player");
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.transform.position); //Find the distance between AllSee and the player.

        //Set Agro Range
        if (distToPlayer <= agroRange)
        {
            currentState = AIState.Chase; //If the distToPlayer is less than the agroRange set to Chase state
        }
        else if (distToPlayer > agroRange)
        {
            currentState = AIState.Idle; //If distToPlayer is greater than agro set to Idle state
        }

        //Idle
        if (currentState == AIState.Idle)
        {
            StopChasing();   
            anim.SetBool("isChasing", false); //Set the animation bool to false which sets the idle animation.
        } else
        {
            ChasePlayer();
            anim.SetBool("isChasing", true); //Set the animation bool to true which sets the chase animation.
        }
    }

    void ChasePlayer()
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime); //Move from AllSee position to the player position at the moveSpeed set.
        }

    void StopChasing()
        {
            rb.velocity = new Vector2(0,0); //Stop all movement
        }
}
