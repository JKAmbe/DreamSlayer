using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheckRed1 : MonoBehaviour
{
    public GameObject enableObject;
    public GameObject disableObject;
    public float delay;
    public CheckShootAbility CSA;
    public CharacterSwitchController CSC;
    // Start is called before the first frame update
    void Start()
    {
        enableObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (CSA.count == 1 && CSC.index == 0 && Input.GetMouseButtonDown(1))
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
