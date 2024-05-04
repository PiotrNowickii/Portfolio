using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxInteract : MonoBehaviour
{
    public bool _isBoxEmpty = false;
    private bool _inRange;
    [SerializeField] private Animator _animator;

    private void Update()
    {
        if (_inRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
                Interact();
        }
    }
    
    private void Interact()
    {
        if (InventoryScript.Instance.isEmpty && !_isBoxEmpty)
        {
            InventoryScript.Instance.InventoryPut("Melee");
            _animator.SetBool("isArmed", true);
            _isBoxEmpty = true;
        }
        else if(InventoryScript.Instance.objectName == "Melee" && _isBoxEmpty)
        {
            InventoryScript.Instance.InventoryPull();
            _animator.SetBool("isArmed", false);
            _isBoxEmpty = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            _inRange = false;
        }
    }
}
