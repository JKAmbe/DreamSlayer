using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// I wanted to reference from the Projectile class for the sake of consistency but the way I want the bomb to work
// is a bit different from a bullet so this is its own class
public class PlayerBomb : MonoBehaviour
{
    public GameObject ExplosionRadius;
    public GameObject ExplosionVisual;

    Vector3 velocity = Vector3.zero;
    float fuse = 0.0f;
    bool bBombActive = false;
    float damageTicks = 0.0f;
    float damage = 0.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        BombUpdate();
    }

    public void init(Vector3 direction, float speed, float fuse, float damagePerTick, float ticks, float explosionRadius)
    {
        velocity = direction * speed;
        this.fuse = fuse;
        damage = damagePerTick;
        damageTicks = ticks;
        ExplosionRadius.transform.localScale *= explosionRadius;
        ExplosionVisual.transform.localScale *= explosionRadius;
    }

    void BombMovement()
    {
        // move the bomb forward at set speed;
        transform.position += velocity * Time.deltaTime;
    }

    void BombUpdate()
    {
        if (!bBombActive)
        {
            BombMovement();
            if (fuse > 0.0f)
            {
                fuse -= Time.deltaTime;
                if (fuse <= 0.0f)
                {
                    explode();
                }
            }
        }
        if (bBombActive)
        {
            damageTicks -= 1;
            // to make sure the bomb does damage overtime, switch the explosion and particle on and off
            ExplosionRadius.SetActive(damageTicks % 2 == 0);


            if (damageTicks <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    void explode()
    {
        bBombActive = true;
        ExplosionRadius.SetActive(true);
        ExplosionVisual.SetActive(true);
    }

    // when bBombActive is true enemy takes damage and bullets gets removed
    private void OnTriggerEnter(Collider other)
    {
        switch (other.gameObject.layer)
        {
            // enemy layer
            case 6:
                other.GetComponentInChildren<HealthBar>().TakeDamage(damage);
                break;
            // enemy projectile layer
            case 8:
                Destroy(other.gameObject);
                break;
        }
    }
}
