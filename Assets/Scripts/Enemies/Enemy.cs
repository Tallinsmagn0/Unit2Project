using UnityEngine;

public class Enemy : PlayableObject
{
    private EnemyType enemyType;
    protected Transform target;

    protected virtual void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
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

    public virtual void Attack()
    {
        SpawnBullet();
        Debug.Log($"Enemy attacking.");
    }

    public virtual void Attack(float interval)
    {
        SpawnBullet();
        Debug.Log($"Enemy attacking with interval {interval}");
    }

    public void Defeated(string message)
    {
        Debug.Log($"Enemy was defeated! They left a message: {message}");
        Destroy(gameObject);
    }

    public void SetEnemyType(EnemyType _enemyType)
    {
        enemyType = _enemyType;
    }
}
