using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSlime : MonoBehaviour
{
    public GameObject slimePrefab;
    public GameObject nextLevelPrefab;
    public float speed;
    public bool moveRight = true;

    public float health;

    public Transform groundDetection;
    public float rayDist;

    void Start()
    {
        health = 5; //Set boss health.
        speed = 9; //Set base speed of boss.
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //Moves right * his speed and Time.deltaTime;

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDist); //Shoots a short raycast towards the ground to detect if there is ground there.

        if(groundInfo.collider == false) //If No Ground
        {
            if(moveRight == true) //And Moving Right
            {
                transform.eulerAngles = new Vector3 (0, -180, 0); //Flip to the left
                moveRight = false;//Not moving Right
            } else
            {
                transform.eulerAngles = new Vector3 (0, 0, 0);//Flip to the right
                moveRight = true;//is Moving Right
            }
        }

        if (health == 4)
        {
            speed = 12;
        } else if (health == 3)
        {
            speed = 14;
        } else if (health == 2)
        {
            speed = 18;
        } else if (health == 1)
        {
            speed = 23; //Increases the speed based on how much health the boss has left.
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player") 
        {
            } if (health == 0)
            {
                Destroy(gameObject);
                Instantiate(nextLevelPrefab, transform.position, Quaternion.identity);
                Instantiate(slimePrefab, transform.position, Quaternion.identity); //If collide with the player and health = 0, destroy BossSlime, Instantiate the final NextLevel orb, and a small baby slime;
            }
        }
    }
