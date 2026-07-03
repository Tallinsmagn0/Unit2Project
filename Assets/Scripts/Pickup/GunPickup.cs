using UnityEngine;

public class GunPickup : Pickup
{
    public override void OnPicked()
    {
        base.OnPicked();

        Debug.Log("Picked up gun");
    }
}
