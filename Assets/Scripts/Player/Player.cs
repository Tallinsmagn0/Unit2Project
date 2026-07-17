using UnityEngine;

public class Player : PlayableObject
{
    // Object references
    [SerializeField] private Camera camera;

    // Attack variables
    [SerializeField] private float weaponDamage = 10;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Bullet bulletPrefab;

    private Rigidbody2D playerRB;

    private void Awake()
    {
        health = new Health(100, 0.5f, 100);
        playerRB = GetComponent<Rigidbody2D>();
        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);
    }

    void Update()
    {
        health.RegenHealth();
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

    public override void Shoot()
    {
        weapon.Shoot(bulletPrefab, this, "Enemy", 5);
    }

    public override void GetDamage(float damage)
    {
        health.DeductHealth(damage);

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
