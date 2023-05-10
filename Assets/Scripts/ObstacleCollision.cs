using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ObstacleCollision : MonoBehaviour
{
    public float alpha1 = 0.8f;
    public float alpha2 = 0.6f;
    public float alpha3 = 0.4f;
    public float alpha4 = 0.2f;

    public int count = 0;
    public bool destroyed = false;
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
            if (count == 0)
            {
                Destroy(other.gameObject);
                Debug.Log("Other Object: " + other.gameObject);
                Color color = objectMaterial.color;
                color.a = alpha1;
                objectMaterial.color = color;
                count++;
                Debug.Log("Count: " + count);
            }
            else if (count == 1)
            {
                Destroy(other.gameObject);
                Debug.Log("Other Object: " + other.gameObject);
                Color color = objectMaterial.color;
                color.a = alpha2;
                objectMaterial.color = color;
                count++;
                Debug.Log("Count: " + count);
            }
            else if (count == 2)
            {
                Destroy(other.gameObject);
                Debug.Log("Other Object: " + other.gameObject);
                Color color = objectMaterial.color;
                color.a = alpha3;
                objectMaterial.color = color;
                count++;
                Debug.Log("Count: " + count);
            }
            else if (count == 3)
            {
                Destroy(other.gameObject);
                Debug.Log("Other Object: " + other.gameObject);
                Color color = objectMaterial.color;
                color.a = alpha4;
                objectMaterial.color = color;
                count++;
                Debug.Log("Count: " + count);
            }
            else
            {
                destroyed = true;
                Destroy(other.gameObject);
                Destroy(gameObject);
                count = 0;
            }

        }
    }
}