using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackArea : MonoBehaviour
{
    [SerializeField] private int dmg = 5;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<EnemyHealthSystem>() != null)
        {
            EnemyHealthSystem health = other.GetComponent<EnemyHealthSystem>();
            health.GetHit(dmg);
        } 

    }
}
