using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodBoxInteractScript : MonoBehaviour
{
    [SerializeField] private string itemType;
    [SerializeField] private Animator _animator;
    private bool _inRange;
    void Update()
    {
        if (_inRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
                Interact(itemType);
        }
    }
    private void Interact(string type)
    {
        if (InventoryScript.Instance.isEmpty)
        {
            InventoryScript.Instance.InventoryPut(type);
            _animator.SetBool("isHolding", true);
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
