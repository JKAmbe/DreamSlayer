using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearText1 : MonoBehaviour
{
    public GameObject enableObject;

    public TextChange1 textChange1;
    // Start is called before the first frame update
    void Start()
    {
        enableObject.SetActive(false);
    }

    void Update()
    {
        if (textChange1.currentMessageIndex == 2)
        {
            enableObject.SetActive(true);
            textChange1.currentMessageIndex++;
        }
    }
}
