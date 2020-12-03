using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float bulletDamage = 1f;
    [SerializeField] private float bulletSpeed;
    private float t = 0f;
    public Transform StartPoint { get; set; }
    public Transform EndPoint { get; set; }
    private void Update()
    {
        if (EndPoint == null)
        {
            Destroy(gameObject);
            return;
        }
        t += Time.deltaTime * bulletSpeed;
        transform.position = Vector3.MoveTowards(StartPoint.position, EndPoint.position, t);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if(other != null)
            {
                var ball = other.gameObject.GetComponent<Ball>();
                ball.GetDamage(bulletDamage);
            }
            Destroy(gameObject);
        }
    }
}
