using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : Projectile
{
    public bool bParried = false;
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
        if (!bParried)
        {
            DamageOtherHealth(other);
            if (other.tag == "PlayerAbility")
            {
                // need to call parent because the collider is in its children
                if (other.GetComponentInParent<AbilityParry>())
                {
                    other.GetComponentInParent<AbilityParry>().ParryBullet(this);
                }
            }
        }
        if (bParried)
        {
            Debug.Log("Parry hit " + other.name);
            DamageOtherHealth(other);
        }
    }
}
