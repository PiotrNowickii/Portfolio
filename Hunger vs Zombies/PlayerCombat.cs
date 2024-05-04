using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{


    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private GameObject attackAreaTop;
    [SerializeField] private GameObject attackAreaBot;
    [SerializeField] private GameObject attackAreaLeft;
    [SerializeField] private GameObject attackAreaRight;
    private string _currArea;
    private bool _isAttacking;
    private float _timer = 0f;
    [SerializeField] private float timeToAttack = 0.5f;
    [SerializeField] private Animator _animator;
    private void Update()
    {
        if (_isAttacking)
        {
            _timer += Time.deltaTime;
            if (_timer >= timeToAttack)
            {
                _timer = 0;
                _isAttacking = false;
                _animator.SetBool("isAttacking", false);
                switch (_currArea)
                {
                    case "Top":
                        attackAreaTop.SetActive(_isAttacking);
                        _currArea = "";
                        break;
                    case "Bot":
                        attackAreaBot.SetActive(_isAttacking);
                        _currArea = "";
                        break;
                    case "Left":
                        attackAreaLeft.SetActive(_isAttacking);
                        _currArea = "";
                        break;
                    case "Right":
                        attackAreaRight.SetActive(_isAttacking);
                        _currArea = "";
                        break;
                }
                
            }
        }
        if (!Input.GetKeyDown(KeyCode.F) || InventoryScript.Instance.objectName != "Melee") return;
        
        Attack();
        
    }

    private void Attack()
    {
        if (_isAttacking) return;
        _isAttacking = true;
        _animator.SetBool("isAttacking", true);
        if (playerMovement.isFacingUp)
        {
            _currArea = "Top";
            attackAreaTop.SetActive(_isAttacking);
            return;
        }
        if (playerMovement.isFacingDown)
        {
            _currArea = "Bot";
            attackAreaBot.SetActive(_isAttacking);
            return;
        }
        if (playerMovement.isFacingLeft)
        {
            _currArea = "Left";
            attackAreaLeft.SetActive(_isAttacking);
            return;
        }
        if (playerMovement.isFacingRight)
        {
            _currArea = "Right";
            attackAreaRight.SetActive(_isAttacking);
            return;
        }

        
    }
}
