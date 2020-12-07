using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletNoAim : MonoBehaviour
{
    [SerializeField] private float speed;
    void Start()
    {
        var rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.localPosition.normalized* 10 * speed);
    }

}
