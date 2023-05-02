using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage;
    public float maxTimer;
    public string includeTag;
    public bool bPiercingBullet = false;

    void Start()
    {
        Destroy(this.gameObject, maxTimer);
    }

    private void OnTriggerEnter(Collider other)
    {      
        DamageOtherHealth(other);
    }

    public void DamageOtherHealth(Collider other)
    {
        if (other.CompareTag(includeTag) && other.GetComponentInChildren<HealthBar>())
        {
            other.GetComponentInChildren<HealthBar>().TakeDamage(damage);
            if (!bPiercingBullet)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
