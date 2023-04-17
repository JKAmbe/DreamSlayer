using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickUp : MonoBehaviour
{
    public float HealAmount = 50.0f;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInChildren<HealthBar>())
        {
            other.GetComponentInChildren<HealthBar>().Heal(HealAmount);
            Destroy(gameObject);
        }
    }
}
