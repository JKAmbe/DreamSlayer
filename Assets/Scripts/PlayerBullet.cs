using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
   

    public float damage;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Collider>().tag == "Enemy")
        {
            other.GetComponent<Collider>().gameObject.GetComponent<Enemyhealthbar>().TakeDamage(damage);
            Destroy(this.gameObject, 1.0f);
        }
    }

}
