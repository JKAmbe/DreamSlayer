using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    public float maxSpeed;
    private float speed;

    private Collider[] hitColliders;
    private RaycastHit hit;

    public float sightRange;
    public float detectionRange;

    public Rigidbody rb;
    public GameObject target;

    private bool seePlayer;



    void Start()
    {
        speed = maxSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (!seePlayer)
        {
            hitColliders = Physics.OverlapSphere(transform.position, detectionRange);

            foreach (var HitCollider in hitColliders)
            {
                if (HitCollider.tag == "Player")
                {
                    target = HitCollider.gameObject;
                    seePlayer = true;
                }

            }

        }
        else
        {
            if (Physics.Raycast(transform.position, (target.transform.position - transform.position), out hit, sightRange))
            {
                if (hit.collider.tag == "Player")
                {
                    seePlayer = false;
                }
                else
                {

                    var heading = target.transform.position - transform.position;
                    var distance = heading.magnitude;
                    var direction = heading / distance;

                    Vector3 move = new Vector3(direction.x * speed, direction.y * speed, direction.z * speed);
                    rb.velocity = move;
                    transform.forward = move;
                }
            }
        }
    }
}
