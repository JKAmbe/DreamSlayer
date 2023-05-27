using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        AudioListener.pause = true;
    }

    public void Resume()
    {
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
