using UnityEngine;

public class PopupEnemy : Enemy
{
    public string scamMessage;

    public override void Attack()
    {
        base.Attack();
        Scam();
    }

    private void Scam()
    {
        Debug.Log(scamMessage);
    }
}
