using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    [Range(1, 5)]
    [SerializeField] private int bulletCount = 3;
    [SerializeField] private Bullet bullet;
    void Start()
    {
        switch (bulletCount)
        {
            case 1:
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 90f), transform);
                break;
            case 2:
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 85f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 95f), transform);
                break;
            case 3:
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 80f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 90f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 100f), transform);
                break;
            case 4:
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 75f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 85f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 95f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 105f), transform);
                break;
            case 5:
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 70f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 80f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 90f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 100f), transform);
                Instantiate(bullet, transform.position, Quaternion.Euler(0f, 0f, 110f), transform);
                break;
            default:
                break;
        }
    }
    public void DestroyParent()
    {
        Destroy(gameObject);
    }
}
