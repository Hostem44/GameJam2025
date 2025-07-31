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

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Door") && Input.GetKey(KeyCode.E))
        {
            Door component = collision.gameObject.GetComponent<Door>();
            float x = component.TeleportDestination.x;
            float y = component.TeleportDestination.y;
            transform.position = new Vector3(
                transform.position.x + x,
                transform.position.y + y,
                transform.position.z
            );
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * movespeed, moveDir.y * movespeed);
    }
}
