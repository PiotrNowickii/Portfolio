using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodOutScript : MonoBehaviour
{
    private bool _inRange;
    public bool _isEmpty = true;
    public string cookingResult = "";
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
        if (InventoryScript.Instance.isEmpty && !_isEmpty)
        {
            InventoryScript.Instance.InventoryPut(cookingResult);
            _animator.SetBool("isHolding", true);
            cookingResult = "";
            _isEmpty = true;
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
