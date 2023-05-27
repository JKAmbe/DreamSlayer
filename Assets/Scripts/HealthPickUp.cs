using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float HealAmount = 50.0f;
    public AudioSource audioSource;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        audioSource.Play();
        if (other.GetComponentInChildren<HealthBar>())
        {
            other.GetComponentInChildren<HealthBar>().Heal(HealAmount);
            Destroy(gameObject);
        }
    }
}
