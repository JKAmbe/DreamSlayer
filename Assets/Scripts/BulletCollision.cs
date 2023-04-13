using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float damage;
    public float despwantimer;

    void Start()
    {
        Destroy(this.gameObject, despwantimer);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            other.GetComponent<Collider>().gameObject.GetComponent<HealthBar>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
