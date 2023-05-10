using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingTornado : MonoBehaviour
{
    public float speed = 1;
    public float duration = 5;
    public float damage = 30;
    //Rigidbody RB;
    private void Start()
    {
       // RB = GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * -speed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<HealthBar>().TakeDamage(damage);
        }
    }
}
