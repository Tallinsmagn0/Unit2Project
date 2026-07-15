using UnityEngine;
using System;

public class Enemy : PlayableObject
{
    private EnemyType enemyType;
    protected Transform target;

    protected virtual void Start()
    {
        try
        {
            target = GameManager.GetInstance().GetPlayer().transform;
        }
        catch (NullReferenceException e)
        {
            Debug.Log("There is no player in the scene! Goodbye!");
            Destroy(gameObject);
        }
        health = new Health(100);
    }

    protected virtual void Update()
    {
        if (target != null)
        {
            Move(target.position);
        } else
        {
            Move();
        }
    }

    public void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void Move(Transform target)
    {
        transform.LookAt(target.position);
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public void Move(float _speed)
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

    public override void Shoot() { }

    public virtual void Attack()
    {
        Debug.Log($"Enemy attacking.");
    }

    public virtual void Attack(float interval)
    {
        Debug.Log($"Enemy attacking with interval {interval}");
    }

    public override void Defeated()
    {
        Destroy(gameObject);
    }

    public void SetEnemyType(EnemyType _enemyType)
    {
        enemyType = _enemyType;
    }

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);

        Debug.Log("Enemy health: " + health.GetHealth());

        if (health.GetHealth() == 0)
        {
            Defeated();
        }
    }
}
