using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    bool detected;
    GameObject target;

    public GameObject bullet;
    public Transform[] shootPoint;

    public float shootSpeed = 10f;
    public float timetoShoot = 1.3f;
    float originalTime;
    int current;
    void Start()
    {
        originalTime = timetoShoot;
        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (detected)
        {
            if (target)
            {
                transform.LookAt(target.transform);
            }

        }

    }

    private void FixedUpdate()
    {
        if (detected)
        {
            timetoShoot -= Time.deltaTime;

            if (timetoShoot < 0)
            {
                ShootPlayer();
                timetoShoot = originalTime;
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            transform.SetParent(null, true);
            detected = true;
            target = other.gameObject;
        }
    }

    private void ShootPlayer()
    {
        if(transform.position != shootPoint[current].position)
        {
            GameObject currentBullet = Instantiate(bullet, shootPoint[current].position, shootPoint[current].rotation);
            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
        }
        else
        {
            current = (current) % shootPoint.Length;
        }
        
        
    }
}
