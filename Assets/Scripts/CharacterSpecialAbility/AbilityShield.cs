using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

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
    PlayerBase parent = null;


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
    }
}
