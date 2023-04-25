using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityParry : SpecialAbility
{
    public GameObject ParryCheckHitbox;
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
        if (bAbilityOn)
        {

        }
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
        EnemyBullet.bParried = true;
        EnemyBullet.GetComponent<Rigidbody>().velocity *= -1 * parrySpeed;
        //EnemyBullet.gameObject.tag = "Enemy";
        EnemyBullet.gameObject.layer = 9;
        EnemyBullet.includeTag = "Enemy";
        EnemyBullet.damage = parryDamage;
    }
}
