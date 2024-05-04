using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProjectileRight : MonoBehaviour
{
    
    [SerializeField] private float _speed;
    private Rigidbody2D _rb;
    private GameObject player;

    
    // Start is called before the first frame update
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
            _rb.velocity = transform.right * _speed;
            player = GameObject.FindWithTag("Player");
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            player.GetComponent<BasicPlayerMovement>().knockbackTimer = player.GetComponent<BasicPlayerMovement>().knockbackTotal;
            player.GetComponent<BasicPlayerMovement>().knockbackRight = false;
            HealthSystem.Instance.TakeDamage(10);
        }

        if (!other.CompareTag("Enemy") && !other.CompareTag("CameraConf") && !other.CompareTag("Boat"))
            Destroy(gameObject);

    }
    
}
