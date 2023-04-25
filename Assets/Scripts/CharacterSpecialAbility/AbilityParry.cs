using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityParry : SpecialAbility
{
    public GameObject ParryCheckHitbox;
    [Header("Parry ability Stats")]
    public float parryCooldown = 0.0f;
    float cParryCooldown = -1.0f;
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
        // parry cooldown
        if (cParryCooldown >= 0.0f)
        {
            bAllowAbilityOn = false;
            cParryCooldown -= Time.deltaTime;
            if (cParryCooldown <= 0.0f)
            {
                cParryCooldown = -1.0f;
            }
        }
        if (bAllowAbilityOn)
        {
            ParryCheckHitbox.SetActive(bAbilityOn);
        } else { ParryCheckHitbox.SetActive(false); }
    }

    override public void useSpecialAbility()
    {
        bAbilityOn = true;
    }

    public override void unuseSpecialAbility()
    {
        bAbilityOn = false;
    }
    public void ParryBullet(EnemyBullet EnemyBullet)
    {
        // allow parry only when its not on a cooldown
        if (bAllowAbilityOn)
        {
            // force cooldown
            cParryCooldown = parryCooldown;
            // Parry the enemy bullet so it damages themselves
            EnemyBullet.bParried = true;
            EnemyBullet.GetComponent<Rigidbody>().velocity *= -1 * parrySpeed;
            EnemyBullet.gameObject.layer = 9;
            EnemyBullet.includeTag = "Enemy";
            EnemyBullet.damage = parryDamage;
        }

    }
}
