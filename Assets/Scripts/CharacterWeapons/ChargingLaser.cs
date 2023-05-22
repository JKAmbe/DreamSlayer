using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargingLaser : PlayerWeapon
{
    [Header("Charging Laser stats")]
    public GameObject WeaponProjectileFullCharge;
    public float damageFullCharge;
    public float secondsToFullCharge = 1.0f;
    float cCharge = 0.0f;
    float totalDamageFullCharge = 0.0f;
    float nearFullChargeRate = 0.85f;


    [Header("Visuals")]
    public ParticleSystem ChargeParticle;
    public ParticleSystem FullchargeParticle;
    // Start is called before the first frame update
    void Start()
    {
        totalDamage = damage;
        totalDamageFullCharge = damageFullCharge;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    override public void WeaponFire()
    {
        if (bAllowWeaponFire)
        {
            if (refireTimer <= 0.0f)
            {
                if (!ChargeParticle.isPlaying) 
                { 
                    ChargeParticle.Play();
                }
                if (ChargeParticle.isPlaying)
                {
                    ChargeParticle.transform.localScale = Vector3.one * Mathf.Lerp(0.1f, 1f, (cCharge / secondsToFullCharge));
                }
                cCharge += Time.deltaTime;
                if (cCharge >= nearFullChargeRate)
                {
                    if (!FullchargeParticle.isPlaying) { FullchargeParticle.Play(); }
                }
                player.switchController.Reticle.PlayCrosshairAnimation();
            }
        }
    }

    override public void WeaponRelease()
    {
        GameObject projectileInstance = null;
        // change damage depending on charge rate, if nearly full charge use the big projectile
        if (cCharge >= nearFullChargeRate)
        {
            projectileInstance = Instantiate(WeaponProjectileFullCharge, transform.position, Quaternion.identity, transform.parent.parent);
            projectileInstance.GetComponent<Projectile>().bPiercingBullet = true;
            projectileInstance.GetComponent<AudioSource>().pitch = 0.8f;
            if (cCharge >= secondsToFullCharge)
            {
                projectileInstance.transform.localScale *= 2;
                projectileInstance.GetComponent<AudioSource>().pitch = 0.7f;
            }
        }
        else
        {
            projectileInstance = Instantiate(WeaponProjectile, transform.position, Quaternion.identity, transform.parent.parent);
        }
        float projectileDamage = projectileInstance.GetComponent<Projectile>().damage = Mathf.Lerp(totalDamage, totalDamageFullCharge, (cCharge / secondsToFullCharge));
        projectileInstance.transform.rotation = Quaternion.LookRotation(GetProjectileDirection());
        projectileInstance.GetComponent<Rigidbody>().AddForce(GetProjectileDirection());
        Destroy(projectileInstance, duration);

        cCharge = 0.0f;
        player.switchController.Reticle.PlayCrosshairAnimation();
        ChargeParticle.Stop();
        FullchargeParticle.Stop();
        animator.SetTrigger("trigShoot");
        animator.Play("Base Layer.Shoot", 0, 0.0f);
    }

    override public void MultiplyDamage(float multiplyDamageBy = 1.0f)
    {
        totalDamage = damage * multiplyDamageBy;
        totalDamageFullCharge = damageFullCharge * multiplyDamageBy;
    }
}
