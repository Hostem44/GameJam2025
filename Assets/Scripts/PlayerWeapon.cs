using UnityEngine;
using UnityEngine.UIElements;

public class PlayerWeapon : MonoBehaviour
{
    private Vector2 mousePos;

    [SerializeField] GameObject Player;
    [SerializeField] Rigidbody2D rb;

    public SpriteRenderer sprite;

    PlayerMovement playerScript;

    void Start()
    {
        playerScript = Player.GetComponent<PlayerMovement>();
    }

    void Update()
    {

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (playerScript.isDashing)
        {
            Dash();
        }
        else
        {
            sprite.enabled = true;
            RotateStaff();
        }

    }

    void RotateStaff()
    {
        Vector2 aimDir = mousePos - rb.position;
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }

    void Dash()
    {
        sprite.enabled = false;
    }
}
