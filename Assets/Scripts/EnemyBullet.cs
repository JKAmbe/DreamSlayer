using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, maxTimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log(other.name);
        if (other.CompareTag(includeTag) && other.GetComponentInChildren<HealthBar>())
        {
            other.GetComponentInChildren<HealthBar>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        if (other.tag == "PlayerAbility")
        {
            // need to call parent because the collider is in its children
            if (other.GetComponentInParent<AbilityParry>())
            {
                other.GetComponentInParent<AbilityParry>().ParryBullet(this);
            }
        }
    }
}
