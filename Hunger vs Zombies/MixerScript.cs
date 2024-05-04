using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MixerScript : MonoBehaviour
{
    private bool _inRange;
    public bool hasCheese;
    public bool hasEgg;
    public bool hasTomato;
    public bool hasBread;
    public bool hasPasta;
    public bool hasMeat;
    public bool _isCooking;
    public string _currDish = "";
    private float _timer = 0f;
    [SerializeField] private float timeToCook = 5f;
    [SerializeField] private FoodOutScript FoodOutArea;
    [SerializeField] private Animator _animator;
    
    
    private void Update()
    {
        
        if (_isCooking)
        {
            hasMeat = false;
            hasCheese = false;
            hasEgg = false;
            hasPasta = false;
            hasTomato = false;
            hasBread = false;
            _timer += Time.deltaTime;
            if (_timer >= timeToCook)
            {
                _timer = 0;
                _isCooking = false;
                FoodOutArea.cookingResult = _currDish;
                FoodOutArea._isEmpty = false;
                _currDish = "";
            }
        }
        CheckForCombo();
        if (_inRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
                Interact();
        }
    }
    
    private void Interact()
    {
        if (_isCooking) return;
        if (!FoodOutArea._isEmpty) return;
        if (!InventoryScript.Instance.isEmpty && InventoryScript.Instance.objectName != "Melee")
        {
            switch (InventoryScript.Instance.objectName)
            {
                case "Cheese":
                    if (!hasCheese)
                    {
                        hasCheese = true;
                        InventoryScript.Instance.InventoryPull();
                        _animator.SetBool("isHolding", false);
                    }
                    break;
                case "Egg":
                    if (!hasEgg)
                    {
                        hasEgg = true;
                        InventoryScript.Instance.InventoryPull();
                        _animator.SetBool("isHolding", false);
                    }
                    break;
                case "Tomato":
                    if (!hasTomato)
                    {
                        hasTomato = true;
                        InventoryScript.Instance.InventoryPull();
                        _animator.SetBool("isHolding", false);
                    }
                    break;
                case "Bread":
                    if (!hasBread)
                    {
                        hasBread = true;
                        InventoryScript.Instance.InventoryPull();
                        _animator.SetBool("isHolding", false);
                    }
                    break;
                case "Pasta":
                    if (!hasPasta)
                    {
                        hasPasta = true;
                        InventoryScript.Instance.InventoryPull();
                        _animator.SetBool("isHolding", false);
                    }
                    break;
                case "Meat":
                    if (!hasMeat)
                    {
                        hasMeat = true;
                        InventoryScript.Instance.InventoryPull();
                        _animator.SetBool("isHolding", false);
                    }
                    break;
            }
        }
    }

    private void CheckForCombo()
    {
        if (hasBread && hasMeat && !hasPasta && !hasEgg && !hasCheese && !hasTomato)
        {
            _isCooking = true;
            _currDish = "Burger";
            return;
        }
        if (!hasBread && !hasMeat && hasPasta && !hasEgg && hasCheese && !hasTomato)
        {
            _isCooking = true;
            _currDish = "MacAndCheese";
            return;
        }
        if (!hasBread && hasMeat && hasPasta && !hasEgg && !hasCheese && hasTomato)
        {
            _isCooking = true;
            _currDish = "Bolognese";
            return;
        }
        if (!hasBread && !hasMeat && hasPasta && hasEgg && !hasCheese && !hasTomato)
        {
            _isCooking = true;
            _currDish = "Carbonara";
            return;
        }
        if (hasBread && !hasMeat && !hasPasta && !hasEgg && hasCheese && hasTomato)
        {
            _isCooking = true;
            _currDish = "Sandwich";
            return;
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
