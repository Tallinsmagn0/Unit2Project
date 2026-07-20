using UnityEngine;
using System;

public class Enemy : PlayableObject
{
    private EnemyType enemyType;
    protected Transform target;
    [SerializeField] protected float attackDamage = 10f;
    [SerializeField] protected float attackRange = 5;
    [SerializeField] protected float attackRate = 2f;
    [SerializeField] protected int defeatScore = 10;

    protected float targetSpeed;
    protected float timer = 0;

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
        targetSpeed = speed;
    }

    protected virtual void Update()
    {
        if (target == null)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            speed = 0;
            Attack();
        } else
        {
            speed = targetSpeed;
        }
        Move(target.position);
    }

    public void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90; 
        transform.rotation = Quaternion.Euler(0, 0, angle);
        rb.linearVelocity = direction.normalized * speed;
    }

    public override void Shoot() { }

    public virtual void Attack()
    {
        Debug.Log($"Enemy attacking.");
    }

    public override void Defeated()
    {
        Destroy(gameObject);
        GameManager.GetInstance().GetScoreManager().IncrementScore(defeatScore);
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
