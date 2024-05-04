using UnityEngine;

public class SwordScript : MonoBehaviour
{
    public PlayerAnimationController playerAnimationController;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        
        playerAnimationController.IsSworded = true;
        Destroy(gameObject);
    }
}