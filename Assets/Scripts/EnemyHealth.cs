using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealth : MonoBehaviour
{
    [SerializeField] int maxHP = 5;
    //[SerializeField] int damagePerHit = 2;

    [Tooltip("Add hp to the enemy when he dies")]
    public int difficultyRamp = 1;

    int currentHP;

    Enemy enemy;

    void OnEnable()
    {
        currentHP = maxHP;    
    }

    void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    void ProcessHit()
    {
        currentHP--;

        if (currentHP <= 0)
        {
            gameObject.SetActive(false);
            enemy.RewardGold();
            maxHP += difficultyRamp; //Aumenta la dificultad con cada muerte
            Debug.Log(maxHP);
        }

    }
}