using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingPlane : MonoBehaviour
{

    public GameObject Plane;

    public float StartingZ;
    // Start is called before the first frame update
    void Start()
    {
        ScrollPlane();
    }
    

    void ScrollPlane()
    {
        GameObject.Instantiate(Plane, new Vector3(0, -13, StartingZ), Quaternion.identity);
        Invoke("ScrollPlane", 1);
    }
}
