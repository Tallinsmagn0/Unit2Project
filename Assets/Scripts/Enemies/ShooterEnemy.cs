using UnityEngine;

public class ShooterEnemy : Enemy
{
    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private GameObject laserPointer;
    [SerializeField] private float bulletSpeed;

    new private void Start()
    {
        base.Start();
        weapon = new Weapon("Shooter", attackDamage, bulletSpeed);
    }

    protected override void Update()
    {
        base.Update();
        StretchLaserToTarget();
    }

    private void StretchLaserToTarget()
    {
        float laserLength = (target.position - transform.position).magnitude;
        Vector3 laserScale = laserPointer.transform.localScale;
        laserPointer.transform.localScale = new Vector3(laserScale.x, laserLength, laserScale.z);
    }

    protected override void StartAttack()
    {
        base.StartAttack();
        laserPointer.SetActive(true);
    }

    protected override void StopAttack()
    {
        base.StopAttack();
        laserPointer.SetActive(false);
    }

    protected override void Attack()
    {
        if (timer <= attackRate)
            {
                timer += Time.deltaTime;
            } 
            else
            {
                timer = 0;
                Shoot();
            }
    }

    public override void Shoot()
    {
        weapon.Shoot(bulletPrefab, this, "Player");
    }
}
