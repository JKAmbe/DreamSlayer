using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HealthBar : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;
    Image maskingBar;
    Image healthBar;
    Image InvisBar;
    public bool binvulnerable = false;

    Vector2 baseSize;

     void Start()
    {
        maskingBar = GetComponentsInChildren<Image>()[0];
        healthBar = GetComponentsInChildren<Image>()[1];
        InvisBar = GetComponentsInChildren<Image>()[2];
        baseSize = maskingBar.rectTransform.sizeDelta;
        currentHealth = maxHealth;
        healthBar.pixelsPerUnitMultiplier = maxHealth / 400.0f;
        InvisBar.pixelsPerUnitMultiplier = maxHealth / 400.0f;
        InvisBar.enabled = binvulnerable;
    }

    private void Update()
    {
        InvisBar.enabled = binvulnerable;
    }
    virtual public void TakeDamage(float amount)
    {
        if (!binvulnerable)
        {
            
            StartCoroutine(HealthLerp(0.5f, currentHealth, currentHealth-amount));
            currentHealth -= amount;
            //maskingBar.rectTransform.sizeDelta = new Vector2((baseSize.x * (currentHealth / maxHealth)), baseSize.y);
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

    }
    IEnumerator HealthLerp(float lerpDuration, float startValue, float endValue)
    {

        float timeElapsed = 0;
        while (timeElapsed < lerpDuration)
        {
            maskingBar.rectTransform.sizeDelta = new Vector2((baseSize.x * (Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration) / maxHealth)), baseSize.y);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        maskingBar.rectTransform.sizeDelta = new Vector2((baseSize.x * (endValue / maxHealth)), baseSize.y);
    }

    public void Heal (float amount)
    {
        StartCoroutine(HealthLerp(0.5f, currentHealth, Mathf.Clamp(currentHealth + amount, 0, maxHealth)));
        currentHealth = Mathf.Clamp(currentHealth + amount, 0, maxHealth);
        //maskingBar.rectTransform.sizeDelta = new Vector2((baseSize.x * (currentHealth / maxHealth)), baseSize.y);
    }

}
