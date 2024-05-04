using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WheelScript : MonoBehaviour
{
    private bool inRange;
    private Animator _animator;
    [SerializeField] private BoatScript boat;

    private void Start()
    {
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (inRange && boat.isIdle && boat.isDone)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                _animator.SetTrigger("IsSpun");
                boat.isDone = false;
                boat.isIdle = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }
}
