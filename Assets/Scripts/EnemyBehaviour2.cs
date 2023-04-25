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
    public float despwantimer;
    public string includeTag;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        Destroy(this.gameObject, despwantimer);
    }

    private void FixedUpdate()
    {
        Vector3 pos = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        rb.MovePosition(pos);
        transform.LookAt(target);
    }

    private void OnTriggerEnter(Collider other)
    {
        
            if (other.CompareTag(includeTag) && other.GetComponentInChildren<HealthBar>())
            {
            other.GetComponentInChildren<HealthBar>().TakeDamage(damage);
            Destroy(this.gameObject);
            }
                
        
    }


}
