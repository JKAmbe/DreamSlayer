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
    protected float duration = 2.0f;
    public bool bAllowWeaponFire = true;
    public GameObject WeaponProjectile;
    protected float totalDamage = 0.0f;
    [Header("Weapon stats")]
    public EAimMode WeaponAimingMode;
    public float damage = 10.0f;
    public float aimSpread = 0.0f;
    public float shotsPerSecond = 12.0f;
   
    protected float refireTimer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        totalDamage = damage;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (bAllowWeaponFire &&  refireTimer >= 0.0f)
        {
            refireTimer -= Time.deltaTime;
            if (refireTimer < 0.0f)
            {
                refireTimer = 0.0f;
            }
        }
    }

    virtual public void WeaponFire()
    {

        if (bAllowWeaponFire)
        {
            // can fire, start timer
            if (refireTimer <= 0.0f)
            {
                // create new instance and start firing timer
                GameObject projectileInstance = Instantiate(WeaponProjectile, transform.position, Quaternion.identity, transform.parent.parent);
                projectileInstance.GetComponent<Projectile>().damage = totalDamage;
                projectileInstance.transform.rotation = Quaternion.LookRotation(GetProjectileDirection());
                projectileInstance.GetComponent<Rigidbody>().AddForce(GetProjectileDirection());
                Destroy(projectileInstance, duration);
                refireTimer = 1.0f / shotsPerSecond;
            }
        }
    }

    virtual public void WeaponRelease()
    {

    }

    protected Vector3 GetProjectileDirection()
    {
        Vector3 Direction = Vector3.forward;
        // projectile direction based on aiming mode
        switch (WeaponAimingMode)
        {
            case EAimMode.Freelook:
                Direction = (Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, planeDistance)) - transform.position).normalized;
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
    virtual public void MultiplyDamage(float multiplyDamageBy = 1.0f)
    {
        totalDamage = damage * multiplyDamageBy;
    }
}
