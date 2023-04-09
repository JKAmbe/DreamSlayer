using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Enemyhealthbar : MonoBehaviour
{
    public float maxHealth;
    public float currentHealth;

    public Image healthBar;


    void Start()
    {
        maxHealth = currentHealth;
    }

    void Update()
    {
        healthBar.fillAmount = Mathf.Clamp(currentHealth / maxHealth, 0, 1);
    }
    public void TakeDamage(float amount)
    {
        Debug.Log(currentHealth);
        currentHealth -= amount;
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
