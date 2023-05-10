using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
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
}
