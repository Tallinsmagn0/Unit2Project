using UnityEngine;

public class ExplosionFragment : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private float speed = 3f;
    private Vector2 moveDirection;

    private float timer = 0;

    // Update is called once per frame
    void Update()
    {
        Move();

        if (timer < duration)
        {
            timer += Time.deltaTime;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Move()
    {
        transform.Translate(moveDirection * speed * Time.deltaTime);
    }

    public void SetMoveDirection(Vector2 direction)
    {
        this.moveDirection = direction;
    }
}
