using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public enum EAimMode
    {
        Freelook,
        PitchYaw
    }

    float planeDistance = 50.0f;
    float duration = 2.0f;
    public bool bAllowWeaponFire = true;
    public Transform ProjectileSpawnPoint;
    public GameObject WeaponProjectile;
    public float totalDamage = 0.0f;
    [Header("Weapon stats")]
    public EAimMode WeaponAimingMode;
    public float damage = 10.0f;
    public float aimSpread = 0.0f;
    public float shotsPerSecond = 12.0f;
    float refireTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void WeaponFire()
    {
        if (bAllowWeaponFire)
        {
            // can fire, start timer
            if (refireTimer <= 0.0f)
            {
                // create new instance and start firing timer
                GameObject projectileInstance = Instantiate(WeaponProjectile, transform.position, Quaternion.identity, transform.parent);
                projectileInstance.GetComponent<Projectile>().damage = totalDamage;
                projectileInstance.GetComponent<Rigidbody>().AddForce(GetProjectileDirection());
                Destroy(projectileInstance, duration);
                refireTimer = shotsPerSecond / 60.0f;
            }
            // cannot fire, wait for cooldown
            else
            {
                refireTimer -= Time.deltaTime;
            }
        }
    }

    public void WeaponRelease()
    {

    }

    Vector3 GetProjectileDirection()
    {
        Vector3 Direction = Vector3.forward;
        // projectile direction based on aiming mode
        switch (WeaponAimingMode)
        {
            case EAimMode.Freelook:
                Direction = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, planeDistance)) - transform.position.normalized;
                break;
            case EAimMode.PitchYaw:
                Direction = transform.forward;
                break;
        }
        // adding spread to direction
        Direction.x += Random.Range(-aimSpread / 100, aimSpread / 100);
        Direction.y += Random.Range(-aimSpread / 100, aimSpread / 100);
        return Direction;
    }

    // buff/debuff weapon damage, pass no argument to reset damage
    public void MultiplyDamage(float multiplyDamageBy = 1.0f)
    {
        totalDamage = damage * multiplyDamageBy;
    }
}
