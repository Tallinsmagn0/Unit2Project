using UnityEngine;

public class MeleeEnemy : Enemy
{
    new private void Start()
    {
        base.Start();
    }

    public override void Attack()
    {
        if (timer <= attackRate)
        {
            timer += Time.deltaTime;
        } else
        {
            timer = 0;
            target.GetComponent<IDamageable>().GetDamage(attackDamage);
        }
    }

    public void SetupMeeleeEnemy(float desiredAttackRange, float desiredAttackRate)
    {
        attackRange = desiredAttackRange;
        attackRate = desiredAttackRate;
    }

}
