using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : MonoBehaviour
{
    [SerializeField] private float attackSpeed = 1f;
    [SerializeField] private float aimSpeed = 1f;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Bullet projectile1;
    [SerializeField] private Transform turretSprite;
    [HideInInspector] public List<Ball> enemies = new List<Ball>();
    [HideInInspector] public bool isOnLeft;
    [HideInInspector] public Transform bestTarget;
    [HideInInspector] public float lerpFactor = 0f;
    private float shootTimer = 0f;

    private void Start()
    {
        if (!isOnLeft)
        {
            var sprite = turretSprite.gameObject.GetComponent<SpriteRenderer>();
            turretSprite.localPosition = new Vector3(-0.4f, 0f);
            firePoint.localPosition = new Vector3(1.77f, 0.43f, -0.113f);
            firePoint.localRotation = Quaternion.Euler(180f, -90f, 0f);
            sprite.flipX = true;
        }
    }
    public virtual void Update()
    {
        if(bestTarget != null)
        {
            //Aims at target
            Aim();
        }
        else
        {
            if(enemies.Count != 0)
            {
                lerpFactor = 0f;
                LookForBestTarget();
            }
        }
    }
    /// <summary>
    /// Registers each ball in range.
    /// </summary>
    /// <param name="other"></param>
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.transform.gameObject.GetComponent<Ball>();
            enemies.Add(enemy);
        }
    }

    /// <summary>
    /// Unregisters each ball leaving the range.
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            var enemy = other.transform.GetComponent<Ball>();
            enemies.Remove(enemy);
            bestTarget = null;
        }
    }

    public virtual void Aim()
    {
        if (lerpFactor < 1f)
        {
            lerpFactor += Time.deltaTime * aimSpeed;
            if (isOnLeft)
            {
                transform.right = Vector3.Slerp(transform.right, bestTarget.position - transform.position, lerpFactor);
            }
            else
            {
                transform.right = Vector3.Slerp(transform.right, -(bestTarget.position - transform.position), lerpFactor);
            }
        }
        else if (lerpFactor >= 1f)
        {
            if (isOnLeft)
            {
                transform.right = bestTarget.position - transform.position;
            }
            else
            {
                transform.right = -(bestTarget.position - transform.position);
            }
            shootTimer += Time.deltaTime * attackSpeed;
            if (shootTimer >= 1f)
            {
                Shoot();
            }
        }
    }

    /// <summary>
    /// Looks for the closest target in turret proximity
    /// </summary>
    /// <param name="transforms"></param>
    /// <returns> best target </returns>
    public virtual Transform LookForBestTarget()
    {
        float closestDistance = Mathf.Infinity;
        foreach(Ball target in enemies)
        {
            if(target == null)
            {
                continue;
            }
            if (Vector2.Distance(transform.position, target.transform.position) < closestDistance)
            {
                bestTarget = target.transform;
            }
        }
        return bestTarget;
    }

    private void Shoot()
    {
        var bullet = Instantiate(projectile1, firePoint.position, Quaternion.identity);
        bullet.StartPoint = firePoint;
        bullet.EndPoint = bestTarget;
        shootTimer = 0f;
    }
}
