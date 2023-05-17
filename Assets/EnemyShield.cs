using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShield : MonoBehaviour
{
    public GameObject shieldArea;
    Vector3 OriginalScale;
    Vector3 CurrentScale;
    public float reductionSpeed = 0.5f;
    private void Start()
    {
        shieldArea = transform.GetChild(0).gameObject;
        OriginalScale = shieldArea.transform.localScale;
        CurrentScale = OriginalScale;
    }

    private void FixedUpdate()
    {
        CurrentScale.x = Mathf.Clamp(CurrentScale.x - Time.deltaTime*reductionSpeed, 0, OriginalScale.x);
        CurrentScale.z = Mathf.Clamp(CurrentScale.z - Time.deltaTime * reductionSpeed, 0, OriginalScale.x);
        shieldArea.transform.localScale = CurrentScale;
    }
    private void OnTriggerEnter(Collider other)
    {     
        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            Vector3 projectilePosition = other.transform.position;
            projectilePosition.z = transform.parent.position.z;
            GetComponentInParent<ShieldEnemy>().nextPosition = projectilePosition;
            CurrentScale = OriginalScale;
        }
    }
}
