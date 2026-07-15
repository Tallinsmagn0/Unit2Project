using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] public float attackRange;
    [SerializeField] public float attackTime = 0f;

    private float targetSpeed;

    float timer = 0;

    new private void Start()
    {
        base.Start();

        health = new Health(100, 0);
        targetSpeed = speed;
    }

    protected override void Update()
    {
        if (target == null)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            speed = 0;
            Attack(attackTime);
        } else
        {
            speed = targetSpeed;
        }
    }

    public override void Attack(float interval)
    {
        if (timer <= interval)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0;
            target.GetComponent<IDamageable>().GetDamage(0);
        }
    }

    public void SetupMeeleeEnemy(float desiredAttackRange, float desiredAttackTime)
    {
        attackRange = desiredAttackRange;
        attackTime = desiredAttackTime;
    }

}
