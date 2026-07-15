using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;

    [SerializeField] private float speed;

    private string targetTag;

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Move(Transform target)
    {
        Debug.Log($"Bullet is moving toward {target.name} to do {damage} damage!");
    }

    public void SetBullet(float _damage, string _targetTag, float _speed = 10)
    {
        damage = _damage;
        targetTag = _targetTag;
        speed = _speed;
    }

    float GetDamage()
    {
        return damage;
    }

    void Damage(IDamageable damageable)
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
        if (collider.gameObject.CompareTag(targetTag))
        {
            IDamageable damageable = collider.GetComponent<IDamageable>();
            Damage(damageable);
        }
    }
}
