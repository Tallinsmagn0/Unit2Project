using UnityEngine;

public class Weapon
{

    public static int weaponCount = 0;
    private string name;
    private float damage;

    public Weapon(string _name, float _damage)
    {
        name = _name;
        damage = _damage;
        weaponCount++;
    }

    public Weapon()
    {
        weaponCount++;
    }

    public void Shoot()
    {
        Debug.Log($"Using {name} to shoot for {damage} damage");
    }
}
