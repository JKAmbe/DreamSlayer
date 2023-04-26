using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityParry : SpecialAbility
{
    public GameObject ParryCheckHitbox;
    [Header("Parry ability Stats")]
    public float parryCooldown = 0.0f;
    public float parryWindow = 0.0f;
    float cParryCooldown = -1.0f;
    float cParryWindow = -1.0f;
    bool bParrySuccess = false;
    [Header("Parry Bullet Stats")]
    public float parryDamage = 0.0f;
    public float parrySpeed = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateParry();
    }

    void UpdateParry()
    {
        // ability can be used depending on if there's a cooldown
        bAllowAbilityOn = cParryCooldown <= 0.0f;

        if (bAllowAbilityOn)
        {
            if (cParryWindow != 0.0f)
            {
                cParryWindow -= Time.deltaTime;
                // turn parry window off 
                if (cParryWindow <= 0.0f)
                {
                    bAbilityOn = false;
                    cParryWindow = 0.0f;
                    // if the parry was success at this point force a cooldown
                    if (bParrySuccess)
                    {
                        cParryCooldown = parryCooldown;
                    }
                }
            }
        } else {
            bAbilityOn = false; 
            if (cParryCooldown != 0.0f)
            {
                cParryCooldown -= Time.deltaTime;
                if (cParryCooldown <= 0.0f)
                {
                    bParrySuccess = false;
                    bAllowAbilityOn = true;
                    cParryCooldown = 0.0f;
                }
            }

        }

        // allow parry to be used 
        ParryCheckHitbox.SetActive(bAbilityOn);
    }

    override public void useSpecialAbility()
    {
        // if the ability isnt already on, turn it on and start parry attempt
        if (!bAbilityOn)
        {
            bAbilityOn = true;
            cParryWindow = parryWindow;
        }

    }

    public override void unuseSpecialAbility()
    {

    }
    public void ParryBullet(EnemyBullet EnemyBullet)
    {
        bParrySuccess = true;
        // Parry the enemy bullet so it damages themselves
        EnemyBullet.bParried = true;
        EnemyBullet.GetComponent<Rigidbody>().velocity *= -1 * parrySpeed;
        EnemyBullet.gameObject.layer = 9;
        EnemyBullet.includeTag = "Enemy";
        EnemyBullet.damage = parryDamage;

    }
}
