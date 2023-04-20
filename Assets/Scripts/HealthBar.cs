using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    [SerializeField]
    Image maskingBar;
    [SerializeField]
    Image healthBar;

    Vector2 baseSize;

     void Start()
    {
        maskingBar = GetComponentsInChildren<Image>()[0];
        healthBar = GetComponentsInChildren<Image>()[1];
        baseSize = maskingBar.rectTransform.sizeDelta;
        currentHealth = maxHealth;
        healthBar.pixelsPerUnitMultiplier = maxHealth / 400.0f;
    }

    virtual public void TakeDamage(float amount)
    {
        currentHealth -= amount;
        maskingBar.rectTransform.sizeDelta = new Vector2((baseSize.x * (currentHealth / maxHealth)), baseSize.y);
        // call to play the TakeDamage effect on the parent object, this class should be only handling the health mechanics
        if (GetComponentInParent<PlayerBase>() != null)
        {
            if (GetComponentInParent<PlayerBase>().GetType().GetMethod("TakeDamageEffects") != null)
            {
                GetComponentInParent<PlayerBase>().TakeDamageEffects();
            }
        }

        if (currentHealth <= 0)
            Destroy(transform.parent.gameObject);
    }
    public void Heal (float amount)
    {
        currentHealth += amount;
        maskingBar.rectTransform.sizeDelta = new Vector2((baseSize.x * (currentHealth / maxHealth)), baseSize.y);
    }

}
