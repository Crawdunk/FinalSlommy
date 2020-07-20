using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public GameObject canvas;
    public GameObject player;
    private static GameManager instance;
    public Vector2 lastCheckpointPos;
    public float lives;
    bool gameHasEnded = false;
    public int score;


    public bool Area1;
    public bool Area2;
    public bool Area3;

    public AudioSource deathNoise;
    
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        } else
        {
            Destroy(gameObject);
        } //Make Singleton
    }
    
    void Start()
    {
        score = 0;
    }

    void Update()
    {
        player = GameObject.FindWithTag("Player");
        canvas = GameObject.FindWithTag("Canvas"); //Grabs the gameobjects for player and canvas by tag.  

        if(SceneManager.GetActiveScene().buildIndex == 5 || SceneManager.GetActiveScene().buildIndex == 7 || SceneManager.GetActiveScene().buildIndex == 11 || SceneManager.GetActiveScene().buildIndex == 13)
        {
            if(Input.GetKeyDown(KeyCode.Space)) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex +1);
            }
        }

    }

    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            Destroy(player); //Destroy the player
            canvas.GetComponent<Canvas>().enabled = true; //Enable the game over canvas.
            Invoke("Restart", 2f); //Start the restart function after 2 seconds.
        }
    }

    void Restart()
    {
        if (Area1 == true) 
        {
            SceneManager.LoadScene(1); //Load the 2nd scene in the build index which is Area 1 Level 1.
            lives = 2; //Resets the lives to 3.
            gameHasEnded = false;
            canvas.GetComponent<Canvas>().enabled = false; //Disables the game over canvas.
        } else if (Area2 == true)
        {
            SceneManager.LoadScene(8); //Load the 7th scene in the build index which is Area 2 Level 1.
            lives = 2; 
            gameHasEnded = false;
            canvas.GetComponent<Canvas>().enabled = false; 
        } else if (Area3 == true)
        {
            SceneManager.LoadScene(14); //Load the 11th scene in the build index which is Area 3 Level 1.
            lives = 2; 
            gameHasEnded = false;
            canvas.GetComponent<Canvas>().enabled = false; 
        }
    }

}
