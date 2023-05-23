using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBlocker : Detection
{
    public GameObject laser;
    public float speed = 20;
    // Start is called before the first frame update
    public float stopDuration = 5f;
    float stopTimer;
    public float lockOnDuration = 5f;
    float lockOnTimer;
    bool firing = false;
    bool locking = false;
    HealthBar health;
    MeshRenderer renderer;
    Color basecolor;


    void Start()
    {
        health = GetComponentInChildren<Enemyhealthbar>();
        stopTimer = stopDuration;
        lockOnTimer = lockOnDuration;
        laser = transform.Find("Beam").gameObject;
        renderer = GetComponent<MeshRenderer>();
        basecolor = renderer.material.color;
    }

    protected override void fixedUpdateCall()
    {
        base.fixedUpdateCall();
        if (target && !firing)
        {
            MoveToTarget();
            Locking();
        }
        if (firing)
        {
            
            Firing();
        }
    }

    private void Firing()
    {
        stopTimer -= Time.deltaTime;
        if (stopTimer <= 0)
        {
            health.binvulnerable = false;
            laser.SetActive(false);
            firing = false;
            stopTimer = stopDuration;
        }
    }

    private void Locking()
    {
        lockOnTimer -= Time.deltaTime;
        renderer.material.color = Color.Lerp(Color.red, basecolor, lockOnTimer / lockOnDuration);
        if (lockOnTimer <= 0)
        {
            health.binvulnerable = true;
            laser.SetActive(true);
            firing = true;
            lockOnTimer = lockOnDuration;
        }
    }

    private void MoveToTarget()
    {
        Vector3 targetPosition = target.transform.position;
        targetPosition.z = transform.position.z;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, Time.deltaTime * speed);
    }
}
