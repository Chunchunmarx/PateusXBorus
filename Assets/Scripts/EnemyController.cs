using System.Collections;
using UnityEngine;

public class EnemyController : BasicController
{
    [Header("Enemy Movement")]
    [SerializeField] float m_MoveSpeed = 2f;
    [SerializeField] float m_ChaseSpeed = 3f;
    [SerializeField] float m_DetectionRange = 5f;

    [Header("Enemy Attack")]
    [SerializeField] float m_BulletSpeed = 5f;
    [SerializeField] float m_FireRate = 1f;

    [Header("Prefabs/Refs")]
    [SerializeField] Transform[] m_Waypoints;
    [SerializeField] GameObject m_BulletPrefab;
    [SerializeField] Transform m_BulletSpawnPoint;
    Transform m_Player;

    int m_WaypointIndex = 0;
    bool m_IsChasing = false;
    float m_NextFireTime = 0f;
   

    void Start()
    {
        m_Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (m_IsChasing)
        {
            ChasePlayer();
            Shoot();
        }
        else
        {
            Patrol();
            DetectPlayer();
        }
    }

    void Patrol()
    {
        if (m_Waypoints.Length == 0) return;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Transform targetWaypoint = m_Waypoints[m_WaypointIndex];
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * m_MoveSpeed, rb.velocity.y);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            m_WaypointIndex = (m_WaypointIndex + 1) % m_Waypoints.Length;
        }
    }

    void DetectPlayer()
    {
        if (Vector2.Distance(transform.position, m_Player.position) <= m_DetectionRange)
        {
            m_IsChasing = true;
        }
    }

    void ChasePlayer()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        Vector2 direction = (m_Player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * m_ChaseSpeed, rb.velocity.y);

        if (Vector2.Distance(transform.position, m_Player.position) > m_DetectionRange)
        {
            m_IsChasing = false;
        }
    }

    void Shoot()
    {
        if (Time.time <= m_NextFireTime)
            return;
        GameObject bullet = Instantiate(m_BulletPrefab, m_BulletSpawnPoint.position, Quaternion.identity);
        Vector2 direction = (m_Player.position - m_BulletSpawnPoint.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * m_BulletSpeed;
        m_NextFireTime = Time.time + m_FireRate;
    }

    private void OnDrawGizmos()
    {
        //draw enemy detect distance
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, m_DetectionRange);
    }
}
