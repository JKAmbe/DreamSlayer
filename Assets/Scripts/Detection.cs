using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    bool detected;
    GameObject target;
    public Transform enemy;

    public GameObject bullet;
    public Transform shootPoint;

    public float shootSpeed = 10f;
    public float timetoShoot = 1.3f;
    float originalTime;
    public float damage;
    void Start()
    {
        originalTime = timetoShoot;
    }

    // Update is called once per frame
    void Update()
    {
        if (detected)
        {
            if (target)
            {
                enemy.LookAt(target.transform);
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
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log(transform.parent);
            transform.SetParent(transform.parent.parent, true);
            detected = true;
            target = other.gameObject;
        }
    }

    private void ShootPlayer()
    {
        GameObject currentBullet = Instantiate(bullet, shootPoint.position, shootPoint.rotation);
        Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
        Destroy(currentBullet, 5);
        rb.AddForce(transform.forward * shootSpeed, ForceMode.VelocityChange);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            collision.collider.gameObject.GetComponent<HealthBar>().TakeDamage(damage);

            Destroy(this.bullet);
        }
    }
}
