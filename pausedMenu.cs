using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pausedMenu : MonoBehaviour
{

    public GameObject menu;

    // Use this for initialization
    void Start()
    {
        Time.timeScale = 1;
        hidePaused();
    }


    public void buttonPress()
    {
        if( Time.timeScale == 1 )
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if( Time.timeScale == 0 )
        {
            Debug.Log("high");
            Time.timeScale = 1;
            hidePaused();
        }
    }


    //Reloads the Level
    public void Reload()
    {
        //Application.LoadLevel(Application.loadedLevel);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    //controls the pausing of the scene
    public void pauseControl()
    {
        if( Time.timeScale == 1 )
        {
            Time.timeScale = 0;
            showPaused();
        }
        else if( Time.timeScale == 0 )
        {
            Time.timeScale = 1;
            hidePaused();
        }
    }

    public void showPaused()
    {
        menu.SetActive(true);
    }

    public void hidePaused()
    {
        menu.SetActive(false);
    }

    //loads inputted level
    public void LoadLevel(string level)
    {
        //Application.LoadLevel(level);
        SceneManager.LoadScene(level);
    }
}