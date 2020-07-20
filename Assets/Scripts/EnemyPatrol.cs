using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float speed;
    public bool moveRight = true;

    public bool alive;

    public Transform groundDetection;
    public float rayDist;

    void Start()
    {
    }

    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime); //Moves right * his speed and Time.deltaTime;

        RaycastHit2D groundInfo = Physics2D.Raycast(groundDetection.position, Vector2.down, rayDist); //Shoots a short raycast towards the ground to detect if there is ground there.

        if(groundInfo.collider == false)//If No Ground
        {
            if(moveRight == true)//And Moving Right
            {
                transform.eulerAngles = new Vector3 (0, -180, 0);//Flip to the left
                moveRight = false;//Not moving Right
            } else
            {
                transform.eulerAngles = new Vector3 (0, 0, 0);//Flip to the right
                moveRight = true;//is Moving Right
            }
        }
    }
}
