using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileLeft : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private GameObject player;

   
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        _rb.velocity = -transform.right * _speed;
        player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<BasicPlayerMovement>().knockbackTimer = player.GetComponent<BasicPlayerMovement>().knockbackTotal;
            player.GetComponent<BasicPlayerMovement>().knockbackRight = true;
            HealthSystem.Instance.TakeDamage(10);
        }
            
        if (!other.CompareTag("Enemy") && !other.CompareTag("CameraConf") && !other.CompareTag("Boat"))
            Destroy(gameObject);
        
    }
    
}
