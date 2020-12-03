using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonTurret : Turret
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            enemies.Add(other.transform);
        }
    }

    public override Transform LookForBestTarget()
    {
        float hp = 0f;
        foreach (Transform target in enemies)
        {
            var newHp = target.gameObject.GetComponent<Ball>().healthPoints;
            if (target == null)
            {
                continue;
            }
            if (newHp > hp)
            {
                bestTarget = target;
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
