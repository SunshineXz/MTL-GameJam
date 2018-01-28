using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    public static bool Paused = false;

    public GameObject PauseMenuUI;

    private void Awake()
    {
        Resume();
    }
    // Update is called once per frame
    void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
	}

    public void Resume()
    {
        if(PauseMenuUI)
        {
            PauseMenuUI.SetActive(false);
            Time.timeScale = 1f;
            Paused = false;
        }
    }

    public void Pause()
    {
        if (PauseMenuUI)
        {
            PauseMenuUI.SetActive(true);
            Time.timeScale = 0f;
            Paused = true;
        }
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

}
