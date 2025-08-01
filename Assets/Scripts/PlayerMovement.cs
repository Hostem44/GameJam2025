using UnityEngine;
using System.Collections;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float movespeed = 5f;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public Animator animator;

    private Vector2 moveDir;
    private Vector2 mousePos;

    [SerializeField] float dashSpeed = 20f;
    [SerializeField] float dashDuration = 0.1f;
    [SerializeField] float dashCooldown = 1f;
    public bool isDashing;
    bool canDash;

    private void Start()
    {
        canDash = true;
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(moveDir.magnitude));
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (mousePos.x < rb.position.x && !isDashing)
        {
            sprite.flipX = true;
        }
        else if (!isDashing)
        {
            sprite.flipX = false;
        }

        ProcessInputs();
    }

    void FixedUpdate()
    {
        if (isDashing)
        {
            return;
        }

        Move();
    }

    void ProcessInputs()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDir = new Vector2(moveX, moveY).normalized;

        if (Input.GetKeyDown(KeyCode.Space) && canDash && Mathf.Abs(moveDir.magnitude) > 0)
        {
            StartCoroutine(Dash());
        }
    }

    void Move()
    {
        rb.linearVelocity = new Vector2(moveDir.x * movespeed, moveDir.y * movespeed);
    }

    private IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;

        animator.SetBool("isRolling", true);
        if (moveDir.x < 0)
        {
            sprite.flipX = true;
        }
        else
        {
            sprite.flipX = false;
        }

        rb.linearVelocity = new Vector2(moveDir.x * dashSpeed, moveDir.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        animator.SetBool("isRolling", false);
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}