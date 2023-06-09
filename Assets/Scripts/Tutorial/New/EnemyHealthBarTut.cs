using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class EnemyHealthBarTut : HealthBar
{
    
    public Animator animator;
    public ParticleSystem takeDamageParticle;
    public GameObject deadParticleObject;
    public AudioSource audiosource;

    public bool targetCheck = false;
    override public void TakeDamage(float amount)
    {
        //Debug.Log(currentHealth);
        // trigger take damage animation
        animator.SetTrigger("takeDamage");
        takeDamageParticle.Play();
        audiosource.pitch = 1.0f + Random.Range(-0.25f, 0.25f);
        audiosource.Play();
        if (currentHealth-amount <= 0)
        {
            GameObject deadParticleInstance = Instantiate(deadParticleObject, transform.position, transform.rotation);
            targetCheck = true;
        }
        base.TakeDamage(amount);
    }
}
