using UnityEngine;
using TMPro;

public class CollectibleCounter : MonoBehaviour
{
    public static CollectibleCounter instance;
    public int gCoinCount;
    public int sCoinCount;
    public int dCount;
    public int kCount;

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
    }


    public void IncreaseCount(int val, char type)
    {
        switch (type)
        {
            case 'g':
                gCoinCount += val;
                break;
            case 's':
                sCoinCount += val;
                break;
            case 'd':
                dCount += val;
                break;
            case 'k':
                kCount += val;
                break;
        }
    }

    public void UseKey()
    {
        kCount--;
    }
}