using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class AbilityShield : SpecialAbility
{
    public MeshRenderer ShieldSphere;

    [Header("Ability Statistics")]
    public float MaxDuration = 2.0f;
    public float RechargeRate = 1.0f;
    public float ForceCooldownDuration = 3.0f;
    public float ScaleAtMaxDuration = 1.0f;
    public float ScaleAtMinDuration = 1.0f;

    float cDuration = 0.0f;
    bool bForceCooldownOn = false;


    // Start is called before the first frame update
    void Start()
    {
        cDuration = MaxDuration;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateShield();
    }
    
    void UpdateShield()
    {
        // rechage shields
        if (!bAbilityOn && cDuration < MaxDuration)
        {
            cDuration += RechargeRate * Time.deltaTime;
            if (cDuration >= MaxDuration)
            {
                bForceCooldownOn = false;
            }
        }

        // Update shields every frame
        ActivateShield(bAbilityOn);
    }

    override public void useSpecialAbility()
    {
        if (bAllowAbilityOn)
        {
            if (!bForceCooldownOn)
            {
                if (cDuration > 0.0f)
                {
                    bAbilityOn = true;
                }
            }
        }
    }

    public override void unuseSpecialAbility()
    {
        bAbilityOn = false;
    }


    void ActivateShield(bool bOn)
    {
        // turn shieldsphere on or off
        ShieldSphere.enabled = bOn;
        
        if (bOn)
        {
            // reduce duration
            cDuration -= Time.deltaTime;
            // force off if duration runs out
            if (cDuration <= 0.0f)
            {
                bAbilityOn = false;
                bForceCooldownOn = true;
            }
            // change shield sphere depending on duration
            ShieldSphere.transform.localScale = Vector3.one * Mathf.Lerp(ScaleAtMinDuration, ScaleAtMaxDuration, (cDuration / MaxDuration));
        }
        
        if (!bOn)
        {

        }

        //// apply effects to the player
        //// right now there's a bug where the player cannot do iframes once they deactivate shields because this itself to turn off invulnerability every frame
        if (bOn) { useSpecialAbilityPlayerEffects(); } else { unuseSpecialAbilityPlayerEffects(); }
    }

    override public void useSpecialAbilityPlayerEffects()
    {
        // make the player invulnerable and slow them down
        // if the player isnt already invulnerable, make the invulnerable
        //parent.healthBar.binvulnerable = true;
        if (!parent.healthBar.binvulnerable)
        {
            parent.healthBar.binvulnerable = true;
        }
    }

    override public void unuseSpecialAbilityPlayerEffects()
    {
        // undo invulnerability and slowdown
        if (!parent.bIframeOn)
        {
            parent.healthBar.binvulnerable = false;
        }
        //if (parent.healthBar.binvulnerable)
        //{
        //    parent.healthBar.binvulnerable = false; 
        //}
        // turn off invulnerability
        //if (parent.healthBar.binvulnerable == false)
        //{
        //    parent.healthBar.binvulnerable = false;
        //} 
    }
}
