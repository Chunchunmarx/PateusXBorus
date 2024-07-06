using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifetime = 2f;
    private Camera mainCamera;

    void Start()
    {
        Destroy(gameObject, lifetime);
        mainCamera = Camera.main;
    }

    void Update()
    {
        CheckOutOfBounds();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            Destroy(other.gameObject); // Destroy the enemy
            Destroy(gameObject); // Destroy the bullet
        }
    }

    void CheckOutOfBounds()
    {
        Vector3 screenPosition = mainCamera.WorldToViewportPoint(transform.position);
        if (screenPosition.x < 0 || screenPosition.x > 1 || screenPosition.y < 0 || screenPosition.y > 1)
        {
            Destroy(gameObject);
        }
    }
}