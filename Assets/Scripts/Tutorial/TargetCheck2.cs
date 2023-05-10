using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetCheck2 : MonoBehaviour
{
    public GameObject targetTrack;
    public EnemyHealthBarTut enemyHealthBarTut;
    public TextChange3 textChange3;

    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        textChange3.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyHealthBarTut.targetCheck == true)
        {
            Invoke("DisableObject", delay);
        }
    }
    

    void DisableObject()
    {
        gameObject.SetActive(false);
        textChange3.enabled = true;
    }
}
