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
    public GameObject deadParticleObject;
    public AudioSource audiosource;

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
        audiosource.pitch = 1.0f + Random.Range(-0.25f, 0.25f);
        audiosource.Play();
        if (currentHealth <= 0)
        {
            // play the dead particle
            GameObject deadParticleInstance = Instantiate(deadParticleObject, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
