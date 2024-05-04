using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private int dmg;
    [SerializeField] private AudioSource punchAudioSource;
    private GameObject player;

    private void Start()
    {
        player = GameObject.FindWithTag("Player");
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.GetComponent<BasicPlayerMovement>().knockbackTimer = player.GetComponent<BasicPlayerMovement>().knockbackTotal;
            if (other.transform.position.x <= transform.position.x)
                player.GetComponent<BasicPlayerMovement>().knockbackRight = true;
            else
            {
                player.GetComponent<BasicPlayerMovement>().knockbackRight = false;
            }
            punchAudioSource.Play();
            HealthSystem.Instance.TakeDamage(dmg);
        }
    }
}
