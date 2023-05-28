using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class Enemyhealthbar : HealthBar
{
    public ParticleSystem takeDamageParticle;
    public GameObject deadParticleObject;
    public AudioSource audiosource;

    public int scoreOnDeath = 100;
    
    override public void TakeDamage(float amount)
    {
        //Debug.Log(currentHealth);
        // trigger take damage animation
        if (!binvulnerable)
        {
            takeDamageParticle.Play();
            audiosource.pitch = 1.0f + Random.Range(-0.25f, 0.25f);
            audiosource.Play();
            if (currentHealth - amount <= 0)
            {
                GameObject deadParticleInstance = Instantiate(deadParticleObject, transform.position, transform.rotation);
                //Debug.Log("Destoryed");

                // Endless mode score adding
                EndlessScoreManager EScoreManager = FindAnyObjectByType<EndlessScoreManager>();
                if (EScoreManager != null)
                {
                    EScoreManager.addScore(scoreOnDeath);
                }
            }
        }
        base.TakeDamage(amount);
    }
}
