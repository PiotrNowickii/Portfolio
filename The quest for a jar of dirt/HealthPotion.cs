using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private Animator _animator;

    [SerializeField] private AudioSource collectSound;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
            Use();
    }

    private void Use()
    {
        collectSound.Play();
        HealthSystem.Instance.Heal(50);
        _animator.SetBool("IsUsed", true);
    }
    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
