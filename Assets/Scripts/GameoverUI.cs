using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class GameoverUI : MonoBehaviour
{
    public TextMeshProUGUI GameoverText;
    public TextMeshProUGUI TipText;
    public AudioClip losingSound;
    public AudioClip VictorySound;

    string[] TipTexts =
    {
        "Switch to another character if your health is low!",
        "Blue's bomb ability can block enemy bullets!",
        "You can charge your laser while using Red's shield ability!",
        "Use Wedding Girl's (is that her official name?) parry when surrounded by bullets!",
        "Shoot and break the walls to avoid collision!"
    };


    // Start is called before the first frame update
    void Start()
    {
        this.gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void showGameoverUI(bool bWin)
    {
        this.gameObject.SetActive(true);
        //Time.timeScale = 0f;
        //AudioListener.pause = true;
        if (bWin)
        {
            GetComponent<AudioSource>().PlayOneShot(VictorySound);
            GameoverText.text = "You Win!";
            TipText.text = "";
        }
        if (!bWin)
        {
            GetComponent<AudioSource>().PlayOneShot(losingSound);
            GameoverText.text = "Game over!";
            TipText.text = TipTexts[Random.Range(0, TipTexts.Length)];
        }
    }

    public void RetryGame()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        AudioListener.pause = false;
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu2");
    }
}
