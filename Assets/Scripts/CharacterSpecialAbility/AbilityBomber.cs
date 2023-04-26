using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AbilityBomber : SpecialAbility
{
    [Header("Bomb stats")]
    public PlayerBomb BombPrefab;
    public float bombMinSpeed;
    public float bombMaxSpeed;
    public float bombFuse = 0.0f;
    float cFuse = 0.0f;
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
        if (bAbilityOn)
        {
            // track how much time special ability button is held down for
            cFuse -= Time.deltaTime;
            // force throw bomb when fuse is held down the whole duration
            if (cFuse <= 0.0f)
            {
                throwBomb();
            }
        }

        if (cBomberCooldown > 0.0f && !bAbilityOn)
        {
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
        if (bAllowAbilityOn && !bAbilityOn)
        {
            bAbilityOn = true;
            bAllowAbilityOn = false;
            cFuse = bombFuse;
        }
    }

    public override void unuseSpecialAbility()
    {
        if (bAbilityOn)
        {
            throwBomb();
        }
        cBomberCooldown = bomberCooldown;
    }

    void throwBomb()
    {
        float bombSpeed = Mathf.Lerp(bombMaxSpeed, bombMinSpeed, cFuse / bombFuse);
        Debug.Log(bombSpeed);
        PlayerBomb bombInstance = Instantiate(BombPrefab, transform.position, Quaternion.identity);
        bombInstance.init(parent.GetPlayerToMouseAim(), bombSpeed, bombFuse, bombDamagePerTick, bombDamageTicks, explosionRadius );
        bAbilityOn = false;
    }
}
