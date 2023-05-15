using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TornadoHealthBar : HealthBar
{
    public float ArmorMultiplier = 1;

    public override void TakeDamage(float amount)
    {
        base.TakeDamage(amount*ArmorMultiplier);
    }


}
