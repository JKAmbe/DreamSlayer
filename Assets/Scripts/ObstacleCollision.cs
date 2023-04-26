using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public float alpha = 0.2f;
    public int count = 0;
    
    private Material objectMaterial;

    private void Start()
    {
        objectMaterial = GetComponent<MeshRenderer>().material;
        Debug.Log("Count: " + count);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.GetComponentInChildren<HealthBar>().TakeDamage(50);
        }

        if (other.gameObject.layer == LayerMask.NameToLayer("Player Projectile"))
        {
            while (count != 5)
            {
                Destroy(other.gameObject);
                Color color = objectMaterial.color;
                color.a -= alpha;
                count++;
                Debug.Log("Count: " + count);
            }

            count = 0;
            Destroy(gameObject);
        }
    }
}
