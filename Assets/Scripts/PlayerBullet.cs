using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
   

    public float damage;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Enemy")
        {
            other.GetComponent<Collider>().gameObject.GetComponent<Enemyhealthbar>().TakeDamage(damage);
            Destroy(this.gameObject, 0.2f);
        }
    }

}
