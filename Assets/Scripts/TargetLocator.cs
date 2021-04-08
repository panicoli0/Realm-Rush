using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetLocator : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] Transform target;
    [SerializeField] ParticleSystem projectile;
    [SerializeField] float range = 15;

    // Update is called once per frame
    void Update()
    {
        FindClosesTarget();
        AimWeapon();
    }

    void FindClosesTarget()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform closesTarget = null;
        float maxDistance = Mathf.Infinity; //podrias poner 99999999 

        foreach (Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position); //Metodo Distance calcula la pos del player(torre) en relacion al enemy/target
            if (targetDistance < maxDistance)
            {
                closesTarget = enemy.transform; //closesTarget ahora es la pos del enemy
                maxDistance = targetDistance; //la maxDistance ahora es targetDistance
            }
        }
        target = closesTarget;
    }

    void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.transform.position);

        weapon.LookAt(target);

        if (targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }    
    }

    void Attack(bool isActive)
    {
        var emissionModule = projectile.emission;
        emissionModule.enabled = isActive;
    }       
}
