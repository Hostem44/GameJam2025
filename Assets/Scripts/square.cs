using UnityEngine;
using UnityEngine.InputSystem;

public class square : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    public InputAction playerMovement;

    private Vector2 moveDir;

    private void OnEnable()
    {
        playerMovement.Enable();
    }

    private void OnDisable()
    {
        playerMovement.Disable();
    }  

    void Update()
    {
        ProcessInputs();
    }

    void FixedUpdate()
    {
        Move();
    }

    void ProcessInputs()
    {
        //float moveX = Input.GetAxisRaw("Horizontal");
        //float moveY = Input.GetAxisRaw("Vertical");

        //moveDir = new Vector2(moveX, moveY).normalized;
        
        moveDir = playerMovement.ReadValue<Vector2>();
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * movespeed, moveDir.y * movespeed);
    }
}
