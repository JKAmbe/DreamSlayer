using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearText3 : MonoBehaviour
{
    public GameObject enableObject;

    public TextChange3 textChange3;
    // Start is called before the first frame update
    void Start()
    {
        enableObject.SetActive(false);
    }

    void Update()
    {
        if (textChange3.currentMessageIndex == 4)
        {
            enableObject.SetActive(true);
            textChange3.currentMessageIndex++;
        }
    }
}
