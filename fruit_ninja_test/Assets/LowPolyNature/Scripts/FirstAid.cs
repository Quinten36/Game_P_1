using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstAid : InventoryItemBase
{
    public int HealthPoints = 20;

    public override void OnUse()
    {
        FALSE_GAME.Instance.Player.Rehab(HealthPoints);

        FALSE_GAME.Instance.Player.Inventory.RemoveItem(this);

        Destroy(this.gameObject);
    }
}
