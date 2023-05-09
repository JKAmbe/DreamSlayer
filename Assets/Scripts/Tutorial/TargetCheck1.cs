using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheck1 : MonoBehaviour
{
    public GameObject targetTrack;
    public EnemyHealthBarTut enemyHealthBarTut;
    public GameObject enableObject;
    public GameObject disableObject;

    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        enableObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealthBarTut.targetCheck == true)
        {
            // Debug.Log("Check:True");
            Invoke("DisableObject", delay);
        }
    }
    

    void DisableObject()
    {
        disableObject.SetActive(false);
        enableObject.SetActive(true);
    }
}
