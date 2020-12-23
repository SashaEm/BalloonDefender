using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTurret : Turret
{
    public override Transform LookForBestTarget()
    {
        float hp = 0f;
        foreach (Ball target in enemies)
        {
            var newHp = target.healthPoints;
            if (target == null)
            {
                continue;
            }
            if (newHp > hp)
            {
                bestTarget = target.transform;
            }
        }
        return bestTarget;
    }

    public override void Update()
    {
        if (bestTarget != null)
        {
            Aim();
        }
        else
        {
            if (enemies.Count != 0)
            {
                lerpFactor = 0f;
                LookForBestTarget();
            }
        }
    }
}
