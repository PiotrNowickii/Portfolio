using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetMixerScript : MonoBehaviour
{
    private bool _inRange;
    [SerializeField] private MixerScript mixer;
    
    
    
    
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
        if (!mixer._isCooking)
        {
            mixer.hasBread = false;
            mixer.hasCheese = false;
            mixer.hasEgg = false;
            mixer.hasMeat = false;
            mixer.hasPasta = false;
            mixer.hasTomato = false;
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
