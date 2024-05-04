using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class OpenChest : MonoBehaviour
{
    [SerializeField] private int dVal;
    [SerializeField] private int scVal;
    [SerializeField] private int gcVal;
    [SerializeField] private TMP_Text chestText;
    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    private bool isOpen;
    private Animator animator;
    public void Open()
    {
        if(!isOpen)
        {
            if (gameObject.CompareTag("LockedChest"))
            {
                if (CollectibleCounter.instance.kCount <= 0)
                    return;
                CollectibleCounter.instance.UseKey();
            }
            isOpen = true;
            animator.SetBool("IsOpen", isOpen);
            if (dVal > 0)
            {
                CollectibleCounter.instance.IncreaseCount(dVal, 'd');
                StartCoroutine(showText("diamond", dVal));
            }
            if (gcVal > 0)
            {
                CollectibleCounter.instance.IncreaseCount(gcVal, 'g');
                StartCoroutine(showText("gold coins", gcVal));
            }
            if (scVal > 0)
            { 
                CollectibleCounter.instance.IncreaseCount(scVal, 's');
                StartCoroutine(showText("silver coins", scVal));
            }
                
        }
    }

    private IEnumerator showText(string collectible, int amount)
    {
        yield return new WaitForSeconds(0.5f);
        chestText.text = "+" + amount + " " + collectible;
        yield return new WaitForSeconds(3f);
        chestText.text = "";
    }
}
