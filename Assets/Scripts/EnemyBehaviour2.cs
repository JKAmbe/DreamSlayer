using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour2 : MonoBehaviour
{
    public Transform target;
    public float speed = 20f;
    Rigidbody rb;
    public float damage;
    public GameObject enemy;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.tag == "Player")
        {
            other.collider.gameObject.GetComponent<HealthBar>().TakeDamage(damage);

            Destroy(enemy);
        }
        else
        {
            Destroy(enemy);
        }
    }


}
