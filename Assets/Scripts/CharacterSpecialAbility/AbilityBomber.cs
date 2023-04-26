using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityBomber : SpecialAbility
{
    [Header("Bomb stats")]
    public PlayerBomb BombPrefab;
    public float bombSpeed;
    public float bombFuse;
    public float bombDamagePerTick;
    public float bombDamageTicks;
    public float explosionRadius;

    [Header("Ability Stats")]
    public float bomberCooldown = 0.0f;
    float cBomberCooldown = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        UpdateBomber();
    }

    void UpdateBomber()
    {
        if (cBomberCooldown > 0.0f)
        {
            Debug.Log("Bomb cooldown");
            cBomberCooldown -= Time.deltaTime;
            if (cBomberCooldown <= 0.0f)
            {
                cBomberCooldown = 0.0f;
                bAllowAbilityOn = true;
            }
        }
    }

    override public void useSpecialAbility()
    {
        if (bAllowAbilityOn)
        {
            // throw bomb
            throwBomb();
            cBomberCooldown = bomberCooldown;
            bAllowAbilityOn = false;
        }
    }

    void throwBomb()
    {
        PlayerBomb bombInstance = Instantiate(BombPrefab, transform.position, Quaternion.identity);
        bombInstance.init(parent.GetPlayerToMouseAim(), bombSpeed, bombFuse, bombDamagePerTick, bombDamageTicks, explosionRadius );
    }
}
