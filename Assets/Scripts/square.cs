using UnityEngine;

public class square : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;

    private Vector2 moveDir;

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
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * movespeed, moveDir.y * movespeed);
    }
}
