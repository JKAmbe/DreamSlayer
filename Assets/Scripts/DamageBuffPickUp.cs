using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageBuffPickUp : MonoBehaviour
{
    public float damageMultiplier;
    public float buffDuration;
    public AudioSource audioSource;
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        Debug.Log("ACTVIATE");
        if (other.GetComponent<PlayerBase>())
        {
            other.GetComponent<PlayerBase>().BuffDamage(damageMultiplier, buffDuration);
            Destroy(gameObject);
        }
    }
}
