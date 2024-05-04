using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    [SerializeField] private enemyPatrol enemy;
    [SerializeField] private float speedIncrease;

    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy._animator.SetBool("IsChasing", true);
            enemy.speed += speedIncrease;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            enemy._animator.SetBool("IsChasing", false);
            enemy.speed -= speedIncrease;
        }
    }
}
