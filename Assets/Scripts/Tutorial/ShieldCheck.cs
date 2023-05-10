using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldCheck : MonoBehaviour
{
    public GameObject targetTrack;
    public EnemyHealthBarTut enemyHealthBarTut;
    public TextChange2 textChange2;

    public float delay;
    // Start is called before the first frame update
    void Start()
    {
        textChange2.enabled = false;
        
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
        textChange2.enabled = true;
    }
}