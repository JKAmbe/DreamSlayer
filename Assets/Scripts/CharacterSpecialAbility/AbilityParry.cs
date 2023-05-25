using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityParry : SpecialAbility
{
    enum ParryState
    {
        Cooldown,
        Usable,
        InUse
    }

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
    ParryState cParryState = ParryState.Usable;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateParry();
        abilityUI.updateCooldownBar(getCooldownRate());
    }
    
    void UpdateParry()
    {
        if (cParryState == ParryState.Usable)
        {
            ParryCheckHitbox.SetActive(false);
        }
        // Parry is being used, activate the hitbox while parry window >= 0.0f and start cooldown once the window is 0
        if (cParryState == ParryState.InUse)
        {
            ParryCheckHitbox.SetActive(true);
            cParryWindow -= Time.deltaTime;
            if (cParryWindow < 0.0f)
            {
                cParryCooldown = parryCooldown;
                cParryState = ParryState.Cooldown;
            }
        }
        // run cooldown timer and set state to usable once cooldown is done
        if (cParryState == ParryState.Cooldown)
        {
            ParryCheckHitbox.SetActive(false);
            cParryCooldown -= Time.deltaTime;
            if (cParryCooldown < 0.0f)
            {
                cParryState = ParryState.Usable;
            }
        }
        if (ParryCheckHitbox.active) { useSpecialAbilityPlayerEffects(); } else { unuseSpecialAbilityPlayerEffects(); }
    }

    override public void useSpecialAbility()
    {
        if (bAllowAbilityOn)
        {
            if (cParryState == ParryState.Usable)
            {
                cParryState = ParryState.InUse;
                cParryWindow = parryWindow;
            }
        }
    }

    public override void unuseSpecialAbility()
    {

    }
    public void ParryBullet(EnemyBullet EnemyBullet)
    {
        // Parry the enemy bullet so it damages themselves
        EnemyBullet.bParried = true;
        EnemyBullet.GetComponent<Rigidbody>().velocity *= -1 * parrySpeed;
        EnemyBullet.gameObject.layer = 9;
        EnemyBullet.includeTag = "Enemy";
        EnemyBullet.damage = parryDamage;
    }

    public void useSpecialAbilityPlayerEffects()
    {
        // turn off player weapon use
        parent.CharacterWeapon.bAllowWeaponFire = false;
    }

    public void unuseSpecialAbilityPlayerEffects()
    {
        // turn on player weapon use if its already not on
        if (!parent.CharacterWeapon.bAllowWeaponFire) { parent.CharacterWeapon.bAllowWeaponFire = true; }
    }
    public float getCooldownRate()
    {
        if (cParryState == ParryState.Usable) { return 1; }
        return cParryCooldown / parryCooldown;
    }
}
