using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewShopItem", menuName = "Shop/Shop Item")]
public class ShopItemSO : ScriptableObject
{
    // 在这里定义商品数据字段
    public string itemName;          // 商品名称
    public Sprite itemIcon;          // 商品图标
    public int price;                // 商品价格
    public int itemID;               // 商品唯一ID
    public bool isPurchased = false; // 是否已购买
    public string itemDesc;          // 商品描述
}
