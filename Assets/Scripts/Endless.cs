using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Endless : MonoBehaviour
{
    public float speed = 42.5f;
    public float speedIncrease = 10f;
    public List<GameObject> prefabList;

    public float spawnInterval = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnPrefab", spawnInterval, spawnInterval);
    }

    void SpawnPrefab()
    {
        int randomIndex = Random.Range(0, prefabList.Count);
        GameObject tmp =  Instantiate(prefabList[randomIndex], transform.position, Quaternion.identity);
        tmp.GetComponent<PlaneControl>().Speed = speed;
        speed += speedIncrease;
        spawnInterval -= 0.0625f * speedIncrease;
    }
}
