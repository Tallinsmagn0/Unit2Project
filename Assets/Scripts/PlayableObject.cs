using UnityEngine;

/// <summary>
/// PlayableObject type for game playable objects like player or enemies
/// </summary>
public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    public Health health = new Health();
    public Weapon weapon;
    [SerializeField]  protected float speed;
    protected Rigidbody2D rb;

    public virtual void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        health = new Health(100);
    }

    public abstract void GetDamage(float damage);

    public virtual void Move(Vector2 direction) {}

    public virtual void Move(Vector3 direction, float speed) {}

    public abstract void Shoot();

    public abstract void Defeated();


}