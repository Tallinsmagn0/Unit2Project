using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class Player : PlayableObject
{
    [SerializeField]  private Camera camera;
    private Rigidbody2D playerRB;

    void Start()
    {
        health = new Health(100, 0.5f, 100);
        playerRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        health.RegenHealth();
    }

    public override void Move(Vector3 direction)
    {
        base.Move(direction);
    }

    public override void Defeated()
    {
        Debug.Log("ouch");
    }
}
