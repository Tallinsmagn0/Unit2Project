using UnityEngine;

/// <summary>
/// PlayableObject type for game playable objects like player or enemies
/// </summary>
public abstract class PlayableObject : MonoBehaviour, IDamageable
{
    protected Health health = new Health();
    public Weapon weapon;

    [SerializeField]  protected float speed;

    public abstract void GetDamage(float damage);

    public virtual void Move(Vector2 direction)
    {
        
    }

    public virtual void Move(Vector3 direction, float speed)
    {
        
    }

    public abstract void Shoot();

    public abstract void Defeated();


}