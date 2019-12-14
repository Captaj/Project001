using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool gameIsPaused = false;

    public GameObject pauseMenuUI;

     // Update is called once per frame
    void Update(){
        //If you hit escape, what happens
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                //If the game is already paused, you resume
                Resume();
            } else
            {
                //If the game isn't paused, then you pause it
                Pause();
            }
        }
    }

    public void Resume ()
    {
        //When you the game is resumed, the UI is set to fales, and the game speed to turned back on.
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        //the bool stored for game state is set to false
        gameIsPaused = false;
    }


    void Pause ()
    {
        //the pause menu is shown
        pauseMenuUI.SetActive(true);
        //the game itself is paused in the background (needs to be tweaked
        Time.timeScale = 0f;
        //the bool for the game state is stored as true
        gameIsPaused = true;
    }

    public void LoadMenu()
    {
        //the main menu is loaded. Any game progress is lost
        SceneManager.LoadScene("MainMenu");
        //The game speed is returned to normal
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        //The game is quit (due to not being able to quit the emulator, the Quitting game is printed to the log
        Debug.Log("Quitting Game");
        Application.Quit();
    }
}



