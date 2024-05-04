using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnTurretScript : MonoBehaviour
{
    private bool _inRange;
    [SerializeField] private GameObject tower;
    [SerializeField] private GlobalMoney money;
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
        if (money.xDolce >= 100)
        {
            money.xDolce -= 400;
            GameObject Tower = Instantiate(tower, gameObject.transform);
            gameObject.transform.DetachChildren();
            Destroy(transform.parent.gameObject);
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
