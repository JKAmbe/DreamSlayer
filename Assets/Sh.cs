using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sh : MonoBehaviour
{
    public float reductionSpeed = 0.5f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            other.GetComponent<Collider>().enabled = false;
            other.GetComponentInChildren<Renderer>().enabled = false;
            other.GetComponentInChildren<TrailRenderer>().enabled = false;
            other.GetComponentInChildren<ParticleSystemRenderer>().enabled = false;
        }
    }
    private void FixedUpdate()
    {
        if (transform.localScale.x >= 0)
        { 
            transform.localScale -= Time.deltaTime * Vector3.one * reductionSpeed;
            GetComponent<Collider>().enabled = true;
        }
        else
        {
            GetComponent<Collider>().enabled = false;
        }
    }
}

