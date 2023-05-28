using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneControl : MonoBehaviour
{
    public float Speed;

    public float destoryPosition = -750;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + Vector3.back * Speed * Time.deltaTime;
        if (transform.position.z < destoryPosition)
        {
            Destroy(gameObject);
        }
    }
}
