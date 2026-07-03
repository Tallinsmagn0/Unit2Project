using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{
    public override void OnPicked()
    {
        base.OnPicked();

        Debug.Log("Picked up health");
    }

    public void GetDamage(float damage)
    {
        Debug.Log("Take damage");
    }
}
