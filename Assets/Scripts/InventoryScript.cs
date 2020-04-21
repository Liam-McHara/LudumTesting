using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryScript : MonoBehaviour
{
    GameController gc;
    Text t;

    void Start()
    {
        gc = FindObjectOfType<GameController>();
        t = GetComponent<Text>();
    }

    public void UpdateInventory()
    {
        t.text = ""; // Start with an empty inventory

        if (gc.itemBarricade) t.text += "-baricade\n";
        if (gc.itemChocolate) t.text += "-chocolate\n";
        if (gc.itemCrowbar) t.text += "-crowbar\n";
        if (gc.itemFlowers) t.text += "-flowers\n";
        if (gc.itemGun) t.text += "-gun\n";
        if (gc.itemPoison) t.text += "-poison\n";
        if (gc.itemSandWich) t.text += "-sandwich\n";
        if (gc.itemSchoolKey) t.text += "-school key\n";
        // if (gc.) t.text += "\n";
    }
}
