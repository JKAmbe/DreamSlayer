using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    public float damage;
    public GameObject enemyBullet;
    public float despwantimer;

    void Start()
    {
        Destroy(this.gameObject, despwantimer);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Player")
        {
            other.GetComponent<Collider>().gameObject.GetComponent<HealthBar>().TakeDamage(damage);
        
            Destroy(this.gameObject);
        }
    }
}
