using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Suck : MonoBehaviour
{
    public float suction = 5.0f;
    private void OnTriggerStay(Collider other)
    {
        Vector3 Center = GetComponent<Collider>().bounds.center;
        Vector3 otherPosition = other.bounds.center;
        Vector3 pullForce = (Center - otherPosition).normalized*suction;
        pullForce.z = 0;
        other.GetComponent<CharacterController>().Move (pullForce);
    }
}
