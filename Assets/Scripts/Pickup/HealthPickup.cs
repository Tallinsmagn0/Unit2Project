using UnityEngine;

public class HealthPickup : Pickup, IDamageable
{

    [SerializeField] private float healthMin = 25;
    [SerializeField] private float healthMax = 50;

    public override void OnPicked()
    {
        base.OnPicked();

        float health = Random.Range(healthMin, healthMax);
        Player player = GameManager.GetInstance().GetPlayer();

        player.health.AddHealth(health);
    }

    public void GetDamage(float damage)
    {
        base.OnPicked();
    }
}
