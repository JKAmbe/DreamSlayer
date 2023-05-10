using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckMovement : MonoBehaviour
{
    public KeyCode press;
    public Material green;
    private MeshRenderer arrow;
    public bool clicked = false;

    private void Start()
    {
        arrow = GetComponent<MeshRenderer>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(press))
        {
            arrow.material = green;
            clicked = true;
        }
    }
}