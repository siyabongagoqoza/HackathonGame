using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;
    public GameObject settingsPanel;
    private bool isPaused;
    public string loadScene;
    public string loadCurrentScene;
    public FloatValue currentHealth;
    public Signal playerHealthSignal;

    /*
        This is a toggle system which swaps between two windows. 
    */
    public void SwitchSettings()
    {
        if(pausePanel.activeInHierarchy == true)
        {
            pausePanel.SetActive(false); 
            settingsPanel.SetActive(true);
        }
        else
        {
            pausePanel.SetActive(true);
            settingsPanel.SetActive(false);
        }
    }

    // This activates and deactivates the pasue menu depending on if it was active.
    public void ChangePause()
    {
        isPaused = !isPaused;
        if (isPaused)
        {
            pausePanel.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            pausePanel.SetActive(false);
            Time.timeScale = 1f;
        }
    }

    // This loads the main scene then goes to it
    public void LoadScene()
    {
        SceneManager.LoadScene(loadScene);
        Time.timeScale = 1f;
    }

    public void Restart()
    {
        currentHealth.initialValue += 1;

        // Raise will activate method belonging to it example play a sound when the user takes damage.
        playerHealthSignal.Raise();
        SceneManager.LoadScene(loadCurrentScene);
        Time.timeScale = 1f;
    }
}
