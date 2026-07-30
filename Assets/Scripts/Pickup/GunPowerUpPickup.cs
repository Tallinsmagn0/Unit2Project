using UnityEngine;

public class GunPowerUpPickup : Pickup
{

    [SerializeField] private float duration;
    [SerializeField] private float shootRate;

    public override void OnPicked()
    {
        base.OnPicked();

        Player player = GameManager.GetInstance().GetPlayer();
        player.PowerUpWeapon(duration, shootRate);
    }
}
