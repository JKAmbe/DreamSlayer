using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Update()
    {
        if (Input.GetKeyUp(KeyCode.Escape))
        {
            if (pauseMenu.activeSelf)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Resume()
    {
        Debug.Log("Attempt resume");
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }

    public void Quit()
    {
        Time.timeScale = 1f;
        AudioListener.pause = false;
        SceneManager.LoadScene("MainMenu2");
    }
}
