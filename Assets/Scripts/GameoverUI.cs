using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameoverUI : MonoBehaviour
{
    public TextMeshProUGUI GameoverText;
    public TextMeshProUGUI TipText;

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
        if (bWin)
        {
            GameoverText.text = "You Win!";
            TipText.text = "";
        }
        if (!bWin)
        {
            GameoverText.text = "Game over!";
            TipText.text = TipTexts[Random.Range(0, TipTexts.Length)];
        }
    }

    public void RetryGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ReturnToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
