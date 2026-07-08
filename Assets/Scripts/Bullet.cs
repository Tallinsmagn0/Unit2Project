using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage;

    [SerializeField]  protected float speed;


    float GetDamage()
    {
        return damage;
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Move(Transform target)
    {
        Debug.Log($"Bullet is moving toward {target.name} to do {damage} damage!");
    }

    void ApplyDamage(IDamageable damageable)
    {
        if (damageable != null)
        {
            damageable.GetDamage(damage);
            Debug.Log("Damaged something");
            LevelLoader.AddScore(10);
            Destroy(gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        IDamageable damageable = collider.GetComponent<IDamageable>();
        ApplyDamage(damageable);
    }
}
