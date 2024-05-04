using UnityEngine;


public class StrengthPotion : MonoBehaviour
{
    public PlayerCombat playerCombat;
    private Animator _animator;
    private static readonly int IsUsed = Animator.StringToHash("IsUsed");
    [SerializeField] private AudioSource collectSound;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;

        playerCombat.potionTime = 15;
        Use();
    }

    private void Use()
    {
        collectSound.Play();
        //Boost strength
        playerCombat.StrengthBoost = 1.3f;
        _animator.SetBool(IsUsed, true);
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}