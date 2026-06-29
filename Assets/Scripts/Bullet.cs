using UnityEngine;

public class Bullet
{
    private float damage;


    float GetDamage()
    {
        return damage;
    }

    void Move(Transform target)
    {
        Debug.Log($"Bullet is moving toward {target.name} to do {damage} damage!");
    }

    void ApplyDamage()
    {
        Debug.Log($"Dealt {damage} damage");

        LevelLoader.AddScore(10);
    }
}
