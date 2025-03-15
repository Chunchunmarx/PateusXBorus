using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicController : MonoBehaviour
{
    [Header("Base Stats")]
    [SerializeField] int m_Health = 3;


    public void TakeDamage(int damage)
    {
        m_Health -= damage;
        if (m_Health <= 0)
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
