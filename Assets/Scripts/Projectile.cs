using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float maxTimer;
    public string targetTag;

    void Start()
    {
        Destroy(this.gameObject, maxTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<HealthBar>())
            other.GetComponentInChildren<HealthBar>().TakeDamage(damage);
    }

}
