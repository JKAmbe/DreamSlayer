using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a template class which each special ability will inherit from
public abstract class SpecialAbility : MonoBehaviour
{
    public bool bAbilityOn = false;
    // blocks abilities from being activated (forced cooldowns etc)
    public bool bAllowAbilityOn = true;
    // the playerbase this ability belongs to
    public PlayerBase parent = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // called at PlayerBase.Start() as a way to pass variables and stuff
    virtual public void Init(PlayerBase player)
    {

    }

    virtual public void useSpecialAbility()
    {
        if (bAllowAbilityOn)
        {
            // do something
            Debug.Log("Use Special Ability");
        }
    }
    // called when ability button is released
    virtual public void unuseSpecialAbility()
    {

    }

    // effects to PlayerBase when ability is used
    virtual public void useSpecialAbilityPlayerEffects()
    {

    }

    virtual public void unuseSpecialAbilityPlayerEffects()
    {

    }
}
