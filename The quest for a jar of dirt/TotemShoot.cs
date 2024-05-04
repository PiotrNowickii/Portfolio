using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TotemShoot : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private float waitBefore;
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private GameObject spawnPoint;
    [SerializeField] private AudioSource shootAudioSource;

    private Animator _animator;
    private bool playerInArea;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    
    

    public IEnumerator Shoot()
    {
        
        Instantiate(projectilePrefab, spawnPoint.transform.position, transform.rotation);
        shootAudioSource.Play();
        _animator.SetBool("Shoot", false);
        yield return new WaitForSeconds(cooldown);
        if (playerInArea)
            _animator.SetBool("Shoot", true);



    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = true;
            StartCoroutine(TriggerShoot());
        }
    }
    private IEnumerator TriggerShoot()
    {
        yield return new WaitForSeconds(waitBefore);
        if (playerInArea)
            _animator.SetBool("Shoot", true);
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInArea = false;
            _animator.SetBool("Shoot", false);
        }
    }
}
