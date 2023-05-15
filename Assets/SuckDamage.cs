using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuckDamage : MonoBehaviour
{
    public float dps = 1.0f;
    public GameObject health;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player") || other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
            GetComponentInParent<AudioSource>().Play();
    }
    private void OnTriggerStay(Collider other)
    {
        
        if (other.gameObject.layer == LayerMask.NameToLayer("Player"))
        {
            health.GetComponentInChildren<HealthBar>().Heal(dps/4);
            other.GetComponentInChildren<HealthBar>().TakeDamage(dps);
        } 
        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
            health.GetComponentInChildren<HealthBar>().Heal(dps/4);
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            Destroy(other);
        }
            
    }
}
