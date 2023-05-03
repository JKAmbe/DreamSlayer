using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TornadoBossBehaviour : MonoBehaviour
{
    bool bAttacking = true;
    int currentAttack = 0;
    float attackDuration = 5;
    HealthBar health;
    Animator anim;
    public GameObject EnemySpawnPrefab;
    public Transform[] SpawnLocation;

    // Start is called before the first frame update
    void Start()
    {
        health =  GetComponentInChildren<HealthBar>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

        if (!bAttacking)
            ResetAttack();
        else
        {
            switch (currentAttack)
            {
                case 0:
                    ReplenishEnemies();
                    break;
                case 1:
                    SuckAttack();
                    break;
                case 2:
                    SuckAttack();
                    break;
                case 3:
                    ReplenishEnemies();
                    break;
            }
            attackDuration -= Time.deltaTime;
            if (attackDuration <= 0)
                bAttacking = false;
        }
            

    }

    void ResetAttack()
    {
        int newAttack = Random.Range(0, 4);
        if (currentAttack != newAttack)
            currentAttack = newAttack;
        switch (currentAttack)
        {
            case 0:
                attackDuration = 5;
                break;
            case 1:
                attackDuration = 5;
                break;
            case 2:
                attackDuration = 5;
                break;
            case 3:
                attackDuration = 5;
                break;
        }
        attackDuration = Random.Range(5, 10);
        bAttacking = true;
        anim.SetTrigger("Reset");
        anim.SetBool("Suck", false);
        anim.SetBool("Spawn", false);
    }
    void SuckAttack()
    {
        anim.SetBool("Suck", true);
    }

    void TornadoPillars()
    {

    }

    void ReplenishEnemies()
    {
        anim.SetBool("Spawn", true);
    }

    void MathAttack()
    {

    }

    public void SpawnEnemy()
    {
        
        Instantiate(EnemySpawnPrefab, SpawnLocation[Random.Range(0, SpawnLocation.Length)].position, Quaternion.identity, null);
    }
    private void OnDestroy()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
