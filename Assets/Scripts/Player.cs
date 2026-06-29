using UnityEditor.ShaderGraph.Drawing.Inspector.PropertyDrawers;
using UnityEngine;

public class Player : PlayableObject
{
    void Start()
    {
        health = new Health(100, 0.5f, 100);
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
