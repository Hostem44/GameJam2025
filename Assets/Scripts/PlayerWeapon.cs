using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;
using System.Collections;

public class PlayerWeapon : MonoBehaviour
{
    private Vector2 mousePos;

    [SerializeField] GameObject Player;
    [SerializeField] Transform rb;
    
    public SpriteRenderer sprite;
    public Transform firePoint;

    bool canShoot;
    [SerializeField] float shootCooldown = 0.5f;

    public GameObject blastPrefab;

    PlayerMovement playerScript;

    void Start()
    {
        playerScript = Player.GetComponent<PlayerMovement>();
        canShoot = true;
    }

    void Update()
    {
        if (Input.GetButton("Fire1") && canShoot && !playerScript.isDashing)
        {
            StartCoroutine(Shoot());
        }
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    void FixedUpdate()
    {
        if (playerScript.isDashing)
        {
            HideSprite();
        }
        else
        {
            sprite.enabled = true;
            RotateStaff();
        }

    }

    private IEnumerator Shoot()
    {
        canShoot = false;
        Instantiate(blastPrefab, firePoint.position, firePoint.rotation);
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }


    void RotateStaff()
    {
        Vector2 aimDir = mousePos - new Vector2(rb.position.x, rb.position.y);
        float aimAngle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, aimAngle);
    }

    void HideSprite()
    {
        sprite.enabled = false;
    }
}
