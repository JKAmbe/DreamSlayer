using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : MonoBehaviour
{

    public List<GameObject> prefabList;

    public float spawnInterval = 5.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPrefab", spawnInterval, spawnInterval);
    }

    void SpawnPrefab()
    {
        int randomIndex = Random.Range(0, prefabList.Count);
        Instantiate(prefabList[randomIndex], transform.position, Quaternion.identity);
    }
}
