using UnityEngine;


public class CollectCollectible : MonoBehaviour
{
    [SerializeField] private int _val = 1;
    [SerializeField] private AudioSource collectAudioSource;
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.CompareTag("Player"))
        {
            collectAudioSource.Play();
            _animator.SetBool("IsCollected", true);
            
            switch (gameObject.tag)
            {
                case "GoldCoin":
                    CollectibleCounter.instance.IncreaseCount(_val, 'g');
                    break;
                case "SilverCoin":
                    CollectibleCounter.instance.IncreaseCount(_val, 's');
                    break;
                case "Diamond":
                    CollectibleCounter.instance.IncreaseCount(_val, 'd');
                    break;
                case "Key":
                    CollectibleCounter.instance.IncreaseCount(_val, 'k');
                    break;
            }
            
        }
    }

    private void DestroyMe()
    {
        Destroy(gameObject);
    }
}
