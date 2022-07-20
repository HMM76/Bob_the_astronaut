using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerControl : MonoBehaviour
{
    PlayerStats playerStats;


    public int speed = 2;
    public Rigidbody2D playerRB;
    float moveHor;
    float moveVer;
    bool isFacingRight = true;

    public bool isGrounded = false;
    public Transform groundCheck;
    public float groundCheckRadius = 0.2f;
    public LayerMask whatIsGround;

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletForce;

    void Start()
    {
        playerStats = gameObject.GetComponent<PlayerStats>();
    }

    void Update()
    {
        moveHor = CrossPlatformInputManager.GetAxis("Horizontal");
        //moveVer = Input.GetAxis("Vertical");
        if(Input.GetButtonDown("Jump") && isGrounded == true)
        {
            Jump();
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        if(moveHor > 0 && !isFacingRight)
        {
            Flip();
        }
        else if(moveHor < 0 && isFacingRight)
        {
            Flip();
        }
    }
    private void FixedUpdate()
    {
        playerRB.velocity = new Vector2(moveHor * speed, playerRB.velocity.y);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
    }
    private void Jump()
    {
        playerRB.AddForce(new Vector2(0, 300));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = new Color(1, 1, 0);
        Gizmos.DrawSphere(groundCheck.position, groundCheckRadius);
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D bulletRB = bullet.GetComponent<Rigidbody2D>();
        bullet.GetComponent<Bullet>().BulletDamage = playerStats.damage;
        bulletRB.AddForce(Vector2.right * bulletForce, ForceMode2D.Impulse);
        Destroy(bullet, 0.5f);
    }
    void Flip()
    {
        isFacingRight = !isFacingRight;
        Vector3 TheScale = transform.localScale;
        TheScale.x *= -1;
        transform.localScale = TheScale;
        bulletForce *= -1;
    }
}   