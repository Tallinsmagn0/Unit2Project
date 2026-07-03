using UnityEngine;

public class Enemy : PlayableObject
{
    private EnemyType enemyType;

    public void Move(Transform target)
    {
        Debug.Log($"Moving towards {target.name}!");
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
    }

    public void SetEnemyType(EnemyType _enemyType)
    {
        enemyType = _enemyType;
    }
}
