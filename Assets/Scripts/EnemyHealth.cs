using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int health = 10;
    [SerializeField] int damagePerHit = 2;
    Enemy enemy;

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        health -= damagePerHit;
        if (health <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
            Debug.Log("DAME GUITA QUE MATE A UN LOCO");
        }
    }
}