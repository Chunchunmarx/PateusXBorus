using System.Collections;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    [Header("Player Movement")]
    [SerializeField] float m_MoveSpeed = 5f;
    [SerializeField] float m_JumpForce = 10f;
    [SerializeField] float m_DashSpeed = 20f;
    [SerializeField] float m_DashDuration = 0.2f;

    [Header("Player Attack")]
    [SerializeField]  float m_BulletSpeed = 10f;
    [SerializeField]  float m_FireRate = 0.2f;

    [Header("Prefabs")]
    [SerializeField] GameObject m_BulletPrefab;
    [SerializeField] Transform m_BulletSpawnPoint;

    bool m_IsDashing = false;
    bool m_IsGrounded = false;
    bool m_IsFacingRight = true;
    float m_NextFireTime = 0f;

    Vector2 m_DashDirection;

    void Update()
    {
        if (!m_IsDashing)
        {
            Move();
        }

        if (Input.GetButtonDown("Fire1") && Time.time > m_NextFireTime)
        {
            Shoot();
        }

        if (Input.GetButtonDown("Jump") && m_IsGrounded)
        {
            Jump();
        }

        if (Input.GetButtonDown("Dash") && !m_IsDashing)
        {
            StartCoroutine(Dash());
        }
    }

    void Move()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        float moveX = Input.GetAxis("Horizontal") * m_MoveSpeed;
        rb.velocity = new Vector2(moveX, rb.velocity.y);

        if ((moveX > 0 && !m_IsFacingRight) ||
            (moveX < 0 && m_IsFacingRight))
        {
            Flip();
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(m_BulletPrefab, m_BulletSpawnPoint.position, Quaternion.identity);
        bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(m_BulletSpeed * transform.localScale.x, 0);
        m_NextFireTime = Time.time + m_FireRate;
    }

    void Jump()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(rb.velocity.x, m_JumpForce);
        m_IsGrounded = false;
    }

    IEnumerator Dash()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        m_IsDashing = true;
        m_DashDirection = new Vector2(Input.GetAxis("Horizontal"), 0).normalized;
        rb.velocity = m_DashDirection * m_DashSpeed;
        yield return new WaitForSeconds(m_DashDuration);
        rb.velocity = Vector2.zero;
        m_IsDashing = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal.y > 0.5f)
        {
            m_IsGrounded = true;
        }
    }

    void Flip()
    {
        m_IsFacingRight = !m_IsFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }

  
   

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * 1.1f);
    }
}
