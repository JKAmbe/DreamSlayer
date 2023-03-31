using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pewtmp : MonoBehaviour
{
    public float speed = 1;
    public int duration = 1;

    // Update is called once per frame
    private void Start()
    {
        Destroy(gameObject, duration);
    }
    void FixedUpdate()
    {
        transform.Translate(transform.forward* speed);
    }
}
