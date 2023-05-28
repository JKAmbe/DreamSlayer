using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSpammer : Detection
{
    public GameObject bullet;
    public Transform shootPoint;

    public float projectileSpeed = 10f;
    public float rateOfFire = 1.3f;
    protected float timetoShoot;
    // Start is called before the first frame update
    void Start()
    {
        timetoShoot = rateOfFire;
    }

    protected virtual void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        rb.AddForce(transform.forward * projectileSpeed, ForceMode.VelocityChange);
    }
    protected override void fixedUpdateCall()
    {
        base.fixedUpdateCall();
        if (target)
        {
            transform.LookAt(target.transform);
            timetoShoot -= Time.deltaTime;
            if (timetoShoot < 0)
            {
                ShootPlayer();
                timetoShoot = rateOfFire;
            }
        }
    }
}
