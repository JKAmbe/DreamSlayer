using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour

{
    [SerializeField] private Image healthbarSprite;

    public float maxHealth;
    [SerializeField] private float currentHealth;

    public void UpdateHealthBar(float maxHealth, float currentHealth)
    {
        healthbarSprite.fillAmount = currentHealth / maxHealth;
    }







    void Start()
    {
        currentHealth = maxHealth;
    }

   public void TakeDamage(float amount)
    {
        currentHealth -= amount;

        if(currentHealth <= 0)
        {
            Debug.Log("The player died");
            currentHealth = maxHealth;
        }
    }
}
