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
                cCharge += Time.deltaTime;
                if (refireTimer <= 0.0f && cCharge <= 0.0f)
                {
                    cCharge += Time.deltaTime;
                    refireTimer = 1.0f / shotsPerSecond;
                }
            }
        }
    }

    override public void WeaponRelease()
    {
        GameObject projectileInstance = null;
        // change projectile to fire based on the charge rate
        if (cCharge >= secondsToFullCharge)
        {
            projectileInstance = Instantiate(WeaponProjectileFullCharge, transform.position, Quaternion.identity, transform.parent.parent);
            projectileInstance.GetComponent<Projectile>().damage = totalDamageFullCharge;
            projectileInstance.GetComponent<Projectile>().bPiercingBullet = true;
            projectileInstance.GetComponent<AudioSource>().pitch = 0.8f;
        }
        else
        {
            projectileInstance = Instantiate(WeaponProjectile, transform.position, Quaternion.identity, transform.parent.parent);
            projectileInstance.GetComponent<Projectile>().damage = totalDamage;
        }
        projectileInstance.transform.rotation = Quaternion.LookRotation(GetProjectileDirection());
        projectileInstance.GetComponent<Rigidbody>().AddForce(GetProjectileDirection());
        Destroy(projectileInstance, duration);


        cCharge = 0.0f;
    }

    override public void MultiplyDamage(float multiplyDamageBy = 1.0f)
    {
        totalDamage = damage * multiplyDamageBy;
        totalDamageFullCharge = damageFullCharge * multiplyDamageBy;
    }
}
