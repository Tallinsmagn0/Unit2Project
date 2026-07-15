using UnityEngine;

[RequireComponent (typeof(Player))]
public class PlayerInput : MonoBehaviour
{
    private Player player;

    private float horizontalInput;
    private float verticalInput;
    private Vector2 lookTarget;
    private bool shootInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        lookTarget = Input.mousePosition;
        shootInput = Input.GetMouseButtonDown(0);

        if (shootInput) player.Shoot();
        
        player.Move(new Vector2(horizontalInput, verticalInput), lookTarget);
    }
}
