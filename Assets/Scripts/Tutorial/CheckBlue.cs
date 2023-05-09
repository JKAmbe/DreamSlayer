using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckBlue : MonoBehaviour
{
    public GameObject enableObject;
    public GameObject disableObject;
    public float delay;

    public CharacterSwitchController CSC;
    // Start is called before the first frame update
    void Start()
    {
        enableObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CSC.index == 2 && Input.GetMouseButtonDown(1))
        {
            Invoke("ChangePrompt", delay);
        }
    }

    void ChangePrompt()
    {
        enableObject.SetActive(true);
        disableObject.SetActive(false);
    }
}
