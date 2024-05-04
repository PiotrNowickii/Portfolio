using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    public static InventoryScript Instance;
    public bool isEmpty = true;
    public string objectName;
    [SerializeField] private SpriteRenderer pillSlot;
    [SerializeField] private GameObject tomatoPill;
    [SerializeField] private GameObject meatPill;
    [SerializeField] private GameObject cheesePill;
    [SerializeField] private GameObject pastaPill;
    [SerializeField] private GameObject eggPill;
    [SerializeField] private GameObject breadPill;
    [SerializeField] private Sprite bologneseSprite;
    [SerializeField] private Sprite carbonaraSprite;
    [SerializeField] private Sprite sandwichSprite;
    [SerializeField] private Sprite burgerSprite;
    [SerializeField] private Sprite macNcheeseSprite;
    private GameObject currHeld;
    private void Awake()
    {
        Instance = this;
    }

    public void InventoryPut(string type)
    {
        switch (type)
        {
            case "Tomato":
                objectName = "Tomato";
                currHeld = Instantiate(tomatoPill, pillSlot.transform);
                isEmpty = false;
                break;
            case "Bread":
                objectName = "Bread";
                currHeld = Instantiate(breadPill, pillSlot.transform);
                isEmpty = false;
                break;
            case "Cheese":
                objectName = "Cheese";
                currHeld = Instantiate(cheesePill, pillSlot.transform);
                isEmpty = false;
                break;
            case "Meat":
                objectName = "Meat";
                currHeld = Instantiate(meatPill, pillSlot.transform);
                isEmpty = false;
                break;
            case "Egg":
                objectName = "Egg";
                currHeld = Instantiate(eggPill, pillSlot.transform);
                isEmpty = false;
                break;
            case "Pasta":
                objectName = "Pasta";
                currHeld = Instantiate(pastaPill, pillSlot.transform);
                isEmpty = false;
                break;
            case "Melee":
                objectName = "Melee";
                isEmpty = false;
                break;
            case "Burger":
                objectName = "Burger";
                pillSlot.sprite = burgerSprite;
                isEmpty = false;
                break;
            case "MacAndCheese":
                objectName = "MacAndCheese";
                pillSlot.sprite = macNcheeseSprite;
                isEmpty = false;
                break;
            case "Bolognese":
                objectName = "Bolognese";
                pillSlot.sprite = bologneseSprite;
                isEmpty = false;
                break;
            case "Carbonara":
                objectName = "Carbonara";
                pillSlot.sprite = carbonaraSprite;
                isEmpty = false;
                break;
            case "Sandwich":
                objectName = "Sandwich";
                pillSlot.sprite = sandwichSprite;
                isEmpty = false;
                break;
        }
    }

    public void InventoryPull()
    {
        Destroy(currHeld);
        pillSlot.sprite = null;
        isEmpty = true;
        objectName = null;
    }
}
