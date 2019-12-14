using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour { 

   
    public void PlayGame ()
    {
        //Uses the in Unity scene manager to load up the next scene (in this case, the main game)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame ()
    {
        //quits the game (for testing purposes prints quitter so you know it's working)
        Debug.Log("QUITTER!");
        Application.Quit();
    }
}
