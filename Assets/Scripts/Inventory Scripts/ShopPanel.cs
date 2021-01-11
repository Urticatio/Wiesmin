using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopPanel : ItemPanel
{
    public override void OnClick(int id, ItemContainer container)
    {
        GameManager.instance.shopController.OnClick(inventory.slots[id], container);
        Show();
    }
}
