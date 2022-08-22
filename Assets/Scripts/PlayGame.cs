using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour {
    // Changelevel function
    public void ChangeLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Game Options
    public void OptionsOpen()
    {
        Debug.Log("Options");
        // Change the options menu to active
    }

    // Quit game
    public void QuitGame()
    {
        Debug.Log("Quit");
        // Application.Quit();
    }
}