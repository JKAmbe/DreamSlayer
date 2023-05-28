using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
using Unity.VisualScripting;

public class GameoverUI : MonoBehaviour
{
    public TextMeshProUGUI GameoverText;
    public TextMeshProUGUI TipText;
    public AudioClip losingSound;
    public AudioClip VictorySound;

    public Button BossfightButton;

    public bool bGameover = false;

    string[] TipTexts =
    {
        "Switch to another character if your health is low!",
        "Different characters excell at different situations!",
        "Blue's bomb ability can block enemy bullets!",
        "Charge your Laser while using Red's shield ability!",
        "Use White's parry when surrounded by bullets!",
        "Shoot and break the walls to avoid collision!",
        "Blue's Rifle is good at any situation!",
        "Red's Charging Laser is devastating against a single target!",
        "White's Minigun excells in punching through anything!",

        // joke tips
        "dying too much? get good",
        "that was a massive L",
        "Shoutout to John Matrix: Time Puncher Extraordinare",
        "Shoutout to Blood Debt",
        "Shoutout to Halloween Tower",
        "Stop playing as Red bro",
        "Blue is the best girl",
        "Red is the best girl",
        "White is the best girl"
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
        bGameover = true;
        if(this.gameObject) 
            this.gameObject.SetActive(true);
        //Time.timeScale = 0f;
        //AudioListener.pause = true;
        if (bWin)
        {
            GetComponent<AudioSource>().PlayOneShot(VictorySound);
            GameoverText.text = "You Win!";
            TipText.text = "";
            if (BossfightButton) { BossfightButton.enabled = true; }
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

    public void BossFight()
    {
        AudioListener.pause = false;
        Time.timeScale = 0.0f;
        SceneManager.LoadScene("Level2");
    }
}
 