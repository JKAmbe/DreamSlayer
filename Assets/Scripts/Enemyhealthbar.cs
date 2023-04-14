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
    
    public Animator animator;
    public ParticleSystem takeDamageParticle;

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
        // trigger take damage animation
        animator.SetTrigger("takeDamage");
        takeDamageParticle.Play();
        if (currentHealth <= 0)
            Destroy(gameObject);
    }
}
