using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
//using UnityEditor.UI;

public class CharacterSwitchController : MonoBehaviour
{
    public GameObject[] CharacterPrefabs;
    GameObject currentCharacter;
    Vector3 charPosition;
    public CameraFollow MainCamera;
    public AimingReticle Reticle;

    public int index;
    // Start is called before the first frame update
    void Start()
    {
        currentCharacter = CharacterPrefabs[0];
        ActivateCharacter(0);
    }

    // Update is called once per frame
    void Update()
    {
        // check input then switch character to the next one
        if (Input.GetButtonUp("Fire2"))
        {
            SwitchCharacters();
        }
    }

    void ActivateCharacter(int characterIndex)
    {
        //Debug.Log("Activate character at index " + characterIndex);
        // Save the posistion of the current character
        charPosition = currentCharacter.transform.position;

        // disable all character except for the selected one
        foreach (GameObject character in CharacterPrefabs) { character.SetActive(false); }
        currentCharacter = CharacterPrefabs[characterIndex];
        currentCharacter.GetComponent<PlayerBase>().switchController = this;

        // for some reason the character's position needs to be changed before they can move
        currentCharacter.transform.position = charPosition;
        CharacterPrefabs[characterIndex].SetActive(true);
        MainCamera.target = currentCharacter.transform;
        Reticle.player = currentCharacter;
        Reticle.ChangeCrosshairSprite(currentCharacter.GetComponent<PlayerBase>().Reticle, currentCharacter.GetComponent<PlayerBase>().ReticleColor);
    }

    // Cycle through and switch to different characters
    public void SwitchCharacters()
    {
        // Get the index of the currently active character
        index = Array.IndexOf(CharacterPrefabs, currentCharacter);
        // update index by 1, wrap back to 0 if needed
        index += 1;
        Debug.Log("Index is: " + index);
        if (index >= CharacterPrefabs.Length) { index = 0; }
        // activate the character
        ActivateCharacter(index);
    }
}
