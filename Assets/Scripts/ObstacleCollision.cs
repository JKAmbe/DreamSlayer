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
                Destroy(other.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
