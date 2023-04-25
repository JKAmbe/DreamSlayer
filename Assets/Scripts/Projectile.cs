using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float maxTimer;
    public string includeTag;

    void Start()
    {
        Destroy(this.gameObject, maxTimer);
    }

    private void OnTriggerEnter(Collider other)
    {
        //Debug.Log(other.name);
        DamageOtherHealth(other);
    }

    public void DamageOtherHealth(Collider other)
    {
        if (other.CompareTag(includeTag) && other.GetComponentInChildren<HealthBar>())
        {
            other.GetComponentInChildren<HealthBar>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
    }
}
