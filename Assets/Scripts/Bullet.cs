using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float m_Lifetime = 2f;
    [SerializeField] EntityType m_TargetType;
    Camera mainCamera;

    void Start()
    {
        Destroy(gameObject, m_Lifetime);
        mainCamera = Camera.main;
    }

    void Update()
    {
        CheckOutOfBounds();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.GetComponent<CharacterController>() && m_TargetType == EntityType.ENEMY) ||
            (other.GetComponent<EnemyController>() && m_TargetType == EntityType.PLAYER))
        {
            BasicController basicController = other.GetComponent<BasicController>();
            basicController.TakeDamage(1); // Notify the basicController that the bullet hit it; also 1 is hardcoded
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