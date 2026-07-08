using UnityEngine;

public class MeleeEnemy : Enemy
{
    [SerializeField] public float attackRange;
    [SerializeField] public float attackTime = 0f;

    float timer = 0;

    protected override void Update()
    {
        if (target == null)
        {
            return;
        }

        float distance = Vector2.Distance(transform.position, target.position);

        if (distance <= attackRange)
        {
            Attack(attackTime);
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

}
