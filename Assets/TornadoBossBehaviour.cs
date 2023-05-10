using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TornadoBossBehaviour : MonoBehaviour
{
    int currentAttack = 0;
    float attackDuration = 10;
    Animator anim;
    //TornadoHealthBar health;
    public GameObject EnemySpawnPrefab;
    public GameObject TornadoSpawnPrefab;
    public Transform[] SpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        //health = GetComponent<TornadoHealthBar>();
        anim = GetComponentInChildren<Animator>();
        anim.SetTrigger("Suck");
    }

    // Update is called once per frame
    void Update()
    {
        if (attackDuration > 0)
        {
            Debug.Log(attackDuration);
            attackDuration -= Time.deltaTime;
        }
        else
            ResetAttack();
    }

    void ResetAttack()
    {
        anim.SetTrigger("Reset");
        int oldAttack = currentAttack;
        while (currentAttack == oldAttack)
            currentAttack = Random.Range(0, 3);
        switch (currentAttack)
        {
            case 0:
                anim.SetTrigger("Suck");
                attackDuration = 5;
                break;
            case 1:
                anim.SetTrigger("SpawnMinion");
                attackDuration = 3;
                break;
            case 2:
                anim.SetTrigger("SpawnTornado");
                attackDuration = 10;
                break;
        }
        
    }

    public void SpawnEnemy()
    {
        Instantiate(EnemySpawnPrefab, SpawnLocation[Random.Range(0, SpawnLocation.Length)].position, Quaternion.identity, null);
    }

    public void SpawnTornado()
    {
        Instantiate(TornadoSpawnPrefab, SpawnLocation[Random.Range(0, SpawnLocation.Length)].position, Quaternion.Euler(0,0,Random.Range(0.0f,360.0f)), null);
    }
    private void OnDestroy()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
