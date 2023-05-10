using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public float[] alpha;
    
    public int count = 0;
    
    private Material objectMaterial;

    private void Start()
    {
        objectMaterial = GetComponent<MeshRenderer>().material;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<HealthBar>().TakeDamage(50);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            Color color = objectMaterial.color;
            color.a = alpha[count];
            objectMaterial.color = color;
            count++;
            if (count >= alpha.Length)
            {
                Destroy(gameObject);
            }
        }
    }
}
