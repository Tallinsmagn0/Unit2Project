using UnityEngine;

/// <summary>
/// PlayableObject type for game playable objects like player or enemies
/// </summary>
public class PlayableObject : MonoBehaviour
{
    protected Health health = new Health();
    public Weapon weapon;

    [SerializeField]  protected float speed;

    public virtual void Move()
    {
        Debug.Log($"Moving!");
    }

    public virtual void Move(Vector3 direction)
    {
        Debug.Log($"Moving towards {direction}!");
    }

    public virtual void Move(Vector3 direction, float speed)
    {
        Debug.Log($"Moving towards {direction} at speed {speed}!");
    }

    public virtual void SpawnBullet()
    {
        
    }

    public virtual void Shoot(Vector3 direction, float speed)
    {
        if (weapon != null)
        {
            
        } else
        {
            
        }
        Debug.Log($"{name} is shooting towards {direction} at speed {speed}!");
    }

    public virtual void Shoot(Vector3 direction, float speed, float extraDamage)
    {
        Debug.Log($"{name} is shooting towards {direction} at speed {speed} with {extraDamage} extra dammage!");
    }

    public virtual void Defeated()
    {
        Debug.Log("Oops");
    }
}