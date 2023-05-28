using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ProjectShooterShotgun : ProjectileSpammer
{
    public int shotgunAmount = 3;
    Vector3 offset = Vector3.one;

    // Start is called before the first frame update
    void Start()
    {
        offset = Vector3.one;
        offset.x *= Random.RandomRange(-1.0f, 1.0f);
        offset.y *= Random.RandomRange(-1.0f, 1.0f);
        offset.z *= Random.RandomRange(-1.0f, 1.0f);
    }

    override protected void ShootPlayer()
    {

        for (int i = 0; i < shotgunAmount; i++) 
        {
            GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            Vector3 tOffset = offset;
            tOffset *= Random.RandomRange(-1.0f, 1.0f);
            rb.AddForce(Vector3.Normalize(transform.forward + tOffset) * projectileSpeed, ForceMode.VelocityChange);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
