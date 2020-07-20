using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    bool isPaused = false;
    public GameObject pauseMenuUI;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame(); //If escape is pressed bring up the pause menu
        }
    }

    public void PauseGame()
    {
        if (isPaused)
        {
            Resume(); //if game is paused already, unpause
        } else
        {
            Pause();   //If not, pause the game
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false); //Set the pauseMenu to false
        Time.timeScale = 1; //Set the time to 1
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true); //Bring up the pause menu
        Time.timeScale = 0; //freeze time by setting the timeScale to 0.
        isPaused = true;   
    }

    public void Menu()
    {
        SceneManager.LoadScene(0); //Loads up the first scene which is the main menu.
        Time.timeScale = 1; //Set the timescale to normal.
        isPaused = false;
    }

    public void Quit()
    {
        Application.Quit(); //Quit the game.
    }
}
