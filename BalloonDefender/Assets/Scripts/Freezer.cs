using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    [SerializeField] private float slow = 0.5f;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                collision.GetComponent<Ball>().StartFreeze(slow);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {
                var freeze = collision.GetComponent<Ball>().EndFreeze();
                StartCoroutine(freeze);
            }
        }
    }
}
