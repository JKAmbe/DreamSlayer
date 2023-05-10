using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class AppearText2 : MonoBehaviour
{
    public GameObject enableObject;
    public TextChange2 textChange2;
    // Start is called before the first frame update
    void Start()
    {
        enableObject.SetActive(false);
    }

    void Update()
    {
        if (textChange2.currentMessageIndex == 3)
        {
            enableObject.SetActive(true);
            textChange2.currentMessageIndex++;
        }
    }
}
