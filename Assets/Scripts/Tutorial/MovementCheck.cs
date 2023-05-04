using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCheck : MonoBehaviour
{
    public KeyCode press;
    public Material green;
    private MeshRenderer arrow;
    public int count;

    private void Start()
    {
        arrow = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(press))
        {
            arrow.material = green;
            count++;
        }
    }
}
