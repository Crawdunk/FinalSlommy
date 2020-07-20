using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private GameManager gm;

    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameManager>(); // Gets the game manager script.
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            gm.lastCheckpointPos = transform.position; //On colliding with the trigger of the checkpoint, it sets the position of the last checkpoint to the current checkpoint position.
        }

        if(SceneManager.GetActiveScene().buildIndex == 1)
        {
            gm.Area1 = true; //If you are in Area 1-1 and up set the GameManager bool to true
        } else if (SceneManager.GetActiveScene().buildIndex == 8)
        {
            gm.Area1 = false;
            gm.Area2 = true; //If you are in Area 2-1 and up set teh GameManager bool Area 2 to true and Area 1 to false
        } else if (SceneManager.GetActiveScene().buildIndex == 14)
        {
            gm.Area2 = false;//If you are in Area 3-1 and up set teh GameManager bool Area 3 to true and Area 2 to false
            gm.Area3 = true;
        }
    }

}
