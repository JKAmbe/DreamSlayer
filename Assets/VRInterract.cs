using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine;

public class VRInterract : MonoBehaviour
{
    [SerializeField] InputActionReference[] switchCharReference;
    [SerializeField] InputActionReference[] fireReference;
    [SerializeField] InputActionReference[] abilityReference;
    public CharacterSwitchController switchController;

    PlayerWeapon currentWeapon;
    SpecialAbility currentAbility;

    bool bFiring;
    bool bAbiliting;


    private void Start()
    {
        currentWeapon = switchController.currentCharacter.GetComponentInChildren<PlayerWeapon>();
        currentAbility = switchController.currentCharacter.GetComponentInChildren<SpecialAbility>();

        foreach (InputActionReference switchAction in switchCharReference)
        {
            switchAction.action.performed += switchCharacter;
        }

        foreach (InputActionReference fireAction in fireReference)
        {
            fireAction.action.performed += fireWeapon;
            fireAction.action.canceled += releaseWeapon;
        }

        foreach (InputActionReference abilityReference in abilityReference)
        {
            abilityReference.action.performed += activateAbility;
            abilityReference.action.canceled += deactivateAbility;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (bAbiliting)
        {
            currentAbility.useSpecialAbility();
        }

        if (bFiring)
        {
            currentWeapon.WeaponFire();
        }
    }

    void switchCharacter(InputAction.CallbackContext obj)
    {
        switchController.SwitchCharacters();
        currentWeapon = switchController.currentCharacter.GetComponentInChildren<PlayerWeapon>();
        currentAbility = switchController.currentCharacter.GetComponentInChildren<SpecialAbility>();
        Debug.Log("character switched");
    }

    void fireWeapon(InputAction.CallbackContext obj)
    {
        bFiring = true;
        //currentWeapon.WeaponFire();
        Debug.Log("weapon firing");
    }

    void releaseWeapon(InputAction.CallbackContext obj)
    {
        bFiring = false;
        currentWeapon.WeaponRelease();
        Debug.Log("weapon release");
    }

    void activateAbility(InputAction.CallbackContext obj)
    {
        bAbiliting = true;
        //currentAbility.useSpecialAbility();
        Debug.Log("ability active");
    }

    void deactivateAbility(InputAction.CallbackContext obj)
    {
        bAbiliting = false;
        currentAbility.unuseSpecialAbility();
        Debug.Log("ability deactive");
    }


    //activate ability
}
