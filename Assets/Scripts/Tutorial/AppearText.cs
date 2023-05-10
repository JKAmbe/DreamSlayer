using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppearText : MonoBehaviour
{
    public GameObject enableObject;

    public TextChange textChange;
    // Start is called before the first frame update
    void Start()
    {
        enableObject.SetActive(false);
    }

    void Update()
    {
        if (textChange.currentMessageIndex == 3)
        {
            enableObject.SetActive(true);
            textChange.currentMessageIndex++;
        }
    }
}
