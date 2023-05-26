using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    public enum EAimMode
    {
        Freelook,
        PitchYaw,
        Autolock
    }

    protected PlayerBase player;
    float planeDistance = 50.0f;
    protected float duration = 2.0f;
    public bool bAllowWeaponFire = true;
    public GameObject WeaponProjectile;
    public Animator animator;
    protected float totalDamage = 0.0f;
    [Header("Weapon stats")]
    public EAimMode WeaponAimingMode;
    public float damage = 10.0f;
    public float aimSpread = 0.0f;
    public float shotsPerSecond = 12.0f;
    public int multishots = 3;
    public float projectileSpeedMultiplier = 1.0f;
   
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

    virtual public void Init(PlayerBase player)
    {
        this.player = player;
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


    virtual public void FireProjectile()
    {
        // shoot bullets multishots per shot (basically shotgun)
        for (int i = 0; i < multishots; i++)
        {
            // create new instance and start firing timer
            GameObject projectileInstance = Instantiate(WeaponProjectile, transform.position, Quaternion.identity, transform.parent.parent);
            projectileInstance.GetComponent<Projectile>().damage = totalDamage;
            projectileInstance.transform.rotation = Quaternion.LookRotation(GetProjectileDirection());
            projectileInstance.GetComponent<Rigidbody>().AddForce(GetProjectileDirection() * projectileSpeedMultiplier);
            Destroy(projectileInstance, duration);
        }

        refireTimer = 1.0f / shotsPerSecond;

        // call the reticle shooting animation from the player and to PlayerManager
        player.switchController.Reticle.PlayCrosshairAnimation();
        //animator.SetTrigger("trigShoot");
        animator.Play("Base Layer.Shoot", 0, 0.0f);
    }

    virtual public void WeaponFire()
    {

        if (bAllowWeaponFire)
        {
            // can fire, start timer
            if (refireTimer <= 0.0f)
            {
                FireProjectile();
            }
        }
    }


    virtual public void WeaponRelease()
    {

    }

    // buff/debuff weapon damage, pass no argument to reset damage
    virtual public void MultiplyDamage(float multiplyDamageBy = 1.0f)
    {
        totalDamage = damage * multiplyDamageBy;
    }
}
