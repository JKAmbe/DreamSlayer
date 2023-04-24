using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour2 : MonoBehaviour
{
    bool detected;
    GameObject target;
    Rigidbody rb;
    public float speed = 20f;
    public float multiplier = 10f;


    void Update()
    {
        if (detected)
        {
            if (target)
            {
                transform.LookAt(target.transform);
            }

        }

    }

    private void FixedUpdate()
    {
        if (detected)
        {
            Vector3 velo = rb.velocity;
            if(detected && velo.x > -2 && velo.x < 2 && velo.z > -2 && velo.z < 2)
            {
                rb.AddForce(speed * multiplier * Time.deltaTime * transform.forward);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.SetParent(null, true);
            detected = true;
            target = other.gameObject;
        }
    }


}
