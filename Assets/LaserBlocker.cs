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
        //base.fixedUpdateCall();

        if (!firing)
        {
            MoveToTarget();
            Locking();
        }
        else
        {
            Firing();
        }
    }

    private void Firing()
    {
        if (stopTimer >= 0)
        {
            stopTimer -= Time.deltaTime;
        }
        else
        {
            health.binvulnerable = false;
            laser.SetActive(false);
            firing = false;
            stopTimer = stopDuration;
        }
    }

    private void Locking()
    {
        if (lockOnTimer >= 0)
        {
            lockOnTimer -= Time.deltaTime;
            renderer.material.color = Color.Lerp(Color.red, basecolor, lockOnTimer / lockOnDuration);
        }
        else
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
