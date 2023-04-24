using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// this is a template class which each special ability will inherit from
public class SpecialAbility : MonoBehaviour
{
    public bool bAbilityOn = false;
    // blocks abilities from being activated (forced cooldowns etc)
    public bool bAllowAbilityOn = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
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
}