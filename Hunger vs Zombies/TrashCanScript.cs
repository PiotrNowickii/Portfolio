using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashCanScript : MonoBehaviour
{
    private bool _inRange;
    [SerializeField] private Animator _animator;
    void Update()
    {
        if (_inRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
                Interact();
        }
    }
    private void Interact()
    {
        if (!InventoryScript.Instance.isEmpty && InventoryScript.Instance.objectName != "Melee")
        {
            InventoryScript.Instance.InventoryPull();
            _animator.SetBool("isHolding", false);
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
