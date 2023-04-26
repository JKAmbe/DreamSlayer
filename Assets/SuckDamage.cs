using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckDamage : MonoBehaviour
{
    public float dps = 1.0f;
    public GameObject health;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
            other.GetComponentInChildren<HealthBar>().TakeDamage(dps);
        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
            health.GetComponentInChildren<HealthBar>().Heal(dps);
    }
}
