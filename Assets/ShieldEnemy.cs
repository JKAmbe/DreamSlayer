using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Detection
{
    public Vector3 nextPosition;
    public float speed;
    public int currentColliding;
    GameObject shield;

    private void Start()
    {
        nextPosition = Vector3.zero;
        shield = GetComponentInChildren<EnemyShield>().gameObject;
    }

    protected override void fixedUpdateCall()
    {
        if (nextPosition != Vector3.zero)
        {
            transform.position = Vector3.MoveTowards(transform.position, nextPosition, Time.deltaTime * speed);
        }
    }
   

}
