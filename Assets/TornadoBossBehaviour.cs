using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoBossBehaviour : MonoBehaviour
{
    bool bAttacking = true;
    int currentAttack = 0;
    float attackDuration = 0;
    HealthBar health;
    Animator anim;
    public GameObject suckArea;

    // Start is called before the first frame update
    void Start()
    {
        health =  GetComponentInChildren<HealthBar>();
        anim = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        attackDuration -= Time.deltaTime;
        if (attackDuration <= 0)
            bAttacking = false;

        if (!bAttacking)
            ResetAttack();
        else
            switch (currentAttack)
            {
                case 0:
                    SuckAttack();
                    break;
                case 1:
                    SuckAttack();
                    break;
                case 2:
                    SuckAttack();
                    break;
                case 3:
                    SuckAttack();
                    break;
            }

    }

    void ResetAttack()
    {
        int newAttack = Random.Range(0, 4);
        if (currentAttack != newAttack)
            currentAttack = newAttack;
        attackDuration = Random.Range(10, 20);
        bAttacking = true;
        anim.SetTrigger("Reset");
        anim.SetBool("Suck", false);
    }
    void SuckAttack()
    {
        anim.SetBool("Suck", true);
        health.binvulnerable = true;
    }

    void TornadoPillars()
    {

    }

    void ReplenishEnemies()
    {

    }

    void MathAttack()
    {

    }
}
