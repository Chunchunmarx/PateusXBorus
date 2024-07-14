using System.Collections;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float chaseSpeed = 3f;
    public int health = 1;
    public Transform[] waypoints;
    public GameObject bulletPrefab;
    public Transform bulletSpawnPoint;
    public float bulletSpeed = 5f;
    public float fireRate = 1f;

    private int waypointIndex = 0;
    private bool isChasing = false;
    private Transform player;
    private float nextFireTime = 0f;

    private Rigidbody2D rb;
   

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (isChasing)
        {
            ChasePlayer();
            if (Time.time > nextFireTime)
            {
                Shoot();
            }
            return;
        }
        else
        {
            Patrol();
            DetectPlayer();
        }
    }

    void Patrol()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[waypointIndex];
        Vector2 direction = (targetWaypoint.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * moveSpeed, rb.velocity.y);

        if (Vector2.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            waypointIndex = (waypointIndex + 1) % waypoints.Length;
        }
    }

    void DetectPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) <= detectionRange)
        {
            isChasing = true;
        }
    }

    void ChasePlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        rb.velocity = new Vector2(direction.x * chaseSpeed, rb.velocity.y);

        if (Vector2.Distance(transform.position, player.position) > detectionRange)
        {
            isChasing = false;
        }
    }

    void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, Quaternion.identity);
        Vector2 direction = (player.position - bulletSpawnPoint.position).normalized;
        bullet.GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        nextFireTime = Time.time + fireRate;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Bullet"))
        {
            TakeDamage(1);
            Destroy(other.gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {

        // Add death animation or effects here
        Destroy(gameObject);
    }

}
