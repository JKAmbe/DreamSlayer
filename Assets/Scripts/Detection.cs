using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    public GameObject target;


     void FixedUpdate()
    {
        fixedUpdateCall();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.SetParent(null, true);
            target = other.gameObject;
        }
    }

    virtual protected void fixedUpdateCall()
    {
        
    }

    

}
