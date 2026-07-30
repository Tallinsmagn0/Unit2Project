using UnityEngine;

public abstract class Pickup : MonoBehaviour, IDamageable
{
    public virtual void OnPicked()
    {
        Destroy(gameObject);
    }

    public void GetDamage(float damage)
    {
        Destroy(gameObject);
    }
}
