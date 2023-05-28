using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public AudioSource audio1;
    public void goToTutorial()
    {
        SceneManager.LoadScene("Tutorial");
    }
    public void goToLvl1()
    {
        SceneManager.LoadScene("Lvl1");
    }
    public void goToLvl2()
    {
        SceneManager.LoadScene("Lvl2");
    }

    public void goToEndless()
    {
        SceneManager.LoadScene("Endless");
    }


    public void quitButton()
    {
        Application.Quit();
    }

    public void PlayAudio()
    {
        audio1.Play();
    }
}
