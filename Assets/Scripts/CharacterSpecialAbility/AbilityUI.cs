using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUI : MonoBehaviour
{

    float baseSize = 0.0f;
    public GameObject CooldownBar;

    // Start is called before the first frame update
    void Start()
    {
        baseSize = CooldownBar.GetComponent<RectTransform>().sizeDelta.x;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateCooldownBar(float abilityCooldownRatio)
    {
        CooldownBar.GetComponent<RectTransform>().sizeDelta = new Vector2(baseSize * abilityCooldownRatio, 200.0f);
    }
}
