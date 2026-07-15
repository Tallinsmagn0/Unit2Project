using UnityEngine;
using System;

public class Player : PlayableObject
{
    [SerializeField] private Camera camera;
    private Rigidbody2D playerRB;

    [SerializeField] private float weaponDamage;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Bullet bulletPrefab;

    public Action<float> OnHealthUpdate;

    private void Start()
    {
        health = new Health(100, 0.5f, 100);
        playerRB = GetComponent<Rigidbody2D>();

        OnHealthUpdate?.Invoke(health.GetHealth());
    }

    void Update()
    {
        health.RegenHealth();
        OnHealthUpdate.Invoke(health.GetHealth());
    }

    public void Move(Vector3 direction, Vector2 target)
    {
        playerRB.linearVelocity = direction * speed * Time.deltaTime;

        Vector3 playerScreenPos = camera.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    public override void Move(Vector3 direction)
    {
        base.Move(direction);
    }

    public override void Shoot()
    {
        weapon.Shoot(bulletPrefab, this, "Enemy", 5);
    }

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);
        OnHealthUpdate.Invoke(health.GetHealth());

        if (health.GetHealth() <= 0)
        {
            Defeated();
        }
    }

    public override void Defeated()
    {
        Destroy(gameObject);
    }
}
