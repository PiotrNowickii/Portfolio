using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class ChestInteract : MonoBehaviour
{
    // Start is called before the first frame update

    private bool inRange;
    [SerializeField] private OpenChest chest;
    
    
  
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(inRange)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                chest.Open();
               

            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            inRange = false;
        }
    }

   
}
