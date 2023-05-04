using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCheck : MonoBehaviour
{
    public KeyCode Up = KeyCode.W;
    public KeyCode Left = KeyCode.A;
    public KeyCode Down = KeyCode.S;
    public KeyCode Right = KeyCode.D;
    public Color color = Color.green;

    private Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(Up))
        {
            renderer.material.color = color;
        }
        if (Input.GetKeyDown(Left))
        {
            renderer.material.color = color;
        }
        if (Input.GetKeyDown(Down))
        {
            renderer.material.color = color;
        }
        if (Input.GetKeyDown(Right))
        {
            renderer.material.color = color;
        }
    }
}
