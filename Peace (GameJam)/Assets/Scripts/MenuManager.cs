using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{

    [SerializeField] Canvas pauseCanvas;

    private void Start()
    {
        if(pauseCanvas != null)
        {
            pauseCanvas.enabled = false;
        }
    }

    void OnPause()
    {
        Pause();
    }

    public void Pause()
    {
        if (pauseCanvas != null)
        {
            pauseCanvas.enabled = true;
            Time.timeScale = 0;
        }
    }
    public void Resume()
    {
        pauseCanvas.enabled = false;
        Time.timeScale = 1;
    }
    public void Play()
    {
        SceneManager.LoadScene("X_LVL 1");
    }
    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
    public void Quit()
    {
        Application.Quit();
    }
}
