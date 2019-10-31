using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : InventoryItemBase
{
    public int FoodPoints = 20;

    public override void OnUse()
    {
        FALSE_GAME.Instance.Player.Eat(FoodPoints);

        FALSE_GAME.Instance.Player.Inventory.RemoveItem(this);

        Destroy(this.gameObject);
    }
}
