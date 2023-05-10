using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChange2 : MonoBehaviour
{
    public TextMeshProUGUI text;  // Reference to the TextMeshProUGUI component
    private string[] messages =
    {
        "Great Job!\nLet's dive into the other characters that are available to us",
        "Different characters enable us to use different playstyles through shooting mechanics and abilities",
        "Currently, we are using the default blue."
    };  // The text to display
    public float delay = 5f;  // The delay before showing the first message
    public float duration = 10f;  // The duration each message should be shown for
    public float messageDelay = 1f;  // The delay between each message

    public int currentMessageIndex = 0;  // The index of the current message being displayed
    private bool shown = false;  // Whether a message has been shown yet
    private float shownTime = 0f;  // The time the current message was shown
    private float nextMessageTime = 0f;

    void Start()
    {
        Invoke("ShowText", delay);
        nextMessageTime = Time.time + messageDelay;
    }

    void Update()
    {
        if (shown && Time.time - shownTime >= duration)
        {
            currentMessageIndex++;
            if (currentMessageIndex >= messages.Length)
            {
                HideText();
            }
            else
            {
                nextMessageTime = Time.time + messageDelay;
                ShowText();
            }
        }

        if (!shown && Time.time >= nextMessageTime)
        {
            ShowText();
        }
        
        
    }

    void ShowText()
    {
        if (currentMessageIndex < 3)
        {
            text.enabled = true;  // Enable the TextMeshProUGUI component
            text.text = messages[currentMessageIndex];  // Set the text to display
            shown = true;  // Set the 'shown' flag to true
            shownTime = Time.time;  // Record the time the text was shown
        }
    }

    void HideText()
    {
        text.enabled = false;  // Disable the TextMeshProUGUI component
        shown = false;  // Reset the 'shown' flag to false
    }
}
