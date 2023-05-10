using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheck3 : MonoBehaviour
{
    public GameObject targetTrack;
    public EnemyHealthBarTut enemyHealthBarTut1;
    public EnemyHealthBarTut enemyHealthBarTut2;
    public EnemyHealthBarTut enemyHealthBarTut3;
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
        if (enemyHealthBarTut1.targetCheck == true && enemyHealthBarTut2.targetCheck == true && enemyHealthBarTut3.targetCheck == true)
        {
            Invoke("DisableObject", delay);
        }
    }
    

    void DisableObject()
    {
        disableObject.SetActive(false);
        enableObject.SetActive(true);
    }
}
