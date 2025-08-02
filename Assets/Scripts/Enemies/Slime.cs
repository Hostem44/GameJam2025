using UnityEngine;

public class Slime : MonoBehaviour
{
    [SerializeField] float movespeed = 1f;
    public Transform player;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;

    public int damage = 1;

    bool seenPlayer;
    private Vector2 aimDir;


    void Start()
    {
        seenPlayer = false;
    }

    void Update()
    {
        aimDir = (new Vector2(player.position.x, player.position.y) -
        new Vector2(transform.position.x, transform.position.y)).normalized;

        if (player.position.x < rb.position.x)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }
    }

    void FixedUpdate()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(rb.position, aimDir);
        if (hitInfo && hitInfo.transform.name == "Player")
        {
            seenPlayer = true;
        }

        if (seenPlayer == false)
        {
            return;
        }

        rb.linearVelocity = new Vector2(aimDir.x * movespeed, aimDir.y * movespeed);
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            PlayerHealth player = collision.GetComponent<PlayerHealth>();

            player.TakeDamage(damage);
        }
    }
}
