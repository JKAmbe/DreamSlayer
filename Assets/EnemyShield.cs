using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public GameObject shieldArea;
    Vector3 OriginalScale;
    public float reductionSpeed = 0.5f;
    private void Start()
    {
        OriginalScale = shieldArea.transform.localScale;
    }

    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            GetComponent<AudioSource>().Play();
            Vector3 projectilePosition = other.transform.position;
            projectilePosition.z = transform.parent.position.z;
            GetComponentInParent<ShieldEnemy>().nextPosition = projectilePosition;
            shieldArea.transform.localScale = OriginalScale;
        }
    }
}
