using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public float healthPoints = 1f;
    [SerializeField] private int reward = 1;
    private float freezeTimer = 1f;
    private Rigidbody2D _rigidbody2D;

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void GetDamage(float damage)
    {
        healthPoints -= damage;
        if(healthPoints <= 0f)
        {
            Destroy(gameObject);
        }
    }

    public void StartFreeze(float slow)
    {
        _rigidbody2D.gravityScale = -0.005f;
        if(_rigidbody2D.velocity.y > slow)
            _rigidbody2D.velocity -= new Vector2(0f, slow);
    }

    public IEnumerator EndFreeze()
    {
        for(float t = 0; t <= freezeTimer; t += Time.deltaTime)
        {
            if(t > freezeTimer - 0.1f)
            {
                _rigidbody2D.gravityScale = -0.01f;
                yield return null;
            }
        }
    }

    private void OnDestroy()
    {
        MoneyManager.money += reward;
        ScoreManager.ScoreAdd(reward);
        CurrentMoneyShow.UpdateMoneyText();
        Spawner.enemiesAlive--;
    }
}
