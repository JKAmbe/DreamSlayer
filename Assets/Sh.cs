using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sh : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            other.GetComponent<Collider>().enabled = false;
            //other.GetComponent<Renderer>().enabled = false;
            Destroy(other.gameObject, 0.5f);
        }
    }
}

