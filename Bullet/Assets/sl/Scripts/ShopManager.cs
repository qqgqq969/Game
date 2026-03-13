using UnityEngine;
using UnityEngine.UI; // 引入传统UI命名空间
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    // 商品预制体（从Project窗口拖入）
    public GameObject shopItemPrefab;
    // ScrollView的Content容器（从Hierarchy拖入）
    public Transform itemContentParent;
    // 货币显示文本（传统UI Text，从Hierarchy拖入）
    public Text currencyText;

    // 商品数据列表（拖入你的ShopItemSO文件）
    public List<ShopItemSO> shopItems;
    // 玩家初始货币
    private int playerCurrency = 1000;

    void Start()
    {
        // 重置所有商品的购买状态（每次运行游戏都重置）
        foreach (var item in shopItems)
        {
            item.isPurchased = false;
        }

        LoadShopItems();
        UpdateCurrencyUI();
    }

    // 加载所有商品UI
    void LoadShopItems()
    {
        // 清空旧的商品UI
        foreach (Transform child in itemContentParent)
        {
            Destroy(child.gameObject);
        }

        // 生成新的商品UI
        foreach (ShopItemSO item in shopItems)
        {
            CreateShopItem(item);
        }
    }

    // 创建单个商品UI
    void CreateShopItem(ShopItemSO item)
    {
        // 实例化商品预制体
        GameObject itemObj = Instantiate(shopItemPrefab, itemContentParent);

        // 绑定商品图标（如果有）
        Image iconImage = itemObj.transform.Find("IconImage")?.GetComponent<Image>();
        if (iconImage != null && item.itemIcon != null)
        {
            iconImage.sprite = item.itemIcon;
        }

        // 绑定商品名称
        Text nameText = itemObj.transform.Find("NameText")?.GetComponent<Text>();
        if (nameText != null)
        {
            nameText.text = item.itemName;
        }

        // 绑定商品价格
        Text priceText = itemObj.transform.Find("PriceText")?.GetComponent<Text>();
        if (priceText != null)
        {
            priceText.text = $"￥{item.price}";
        }

        // 绑定购买按钮
        Button buyButton = itemObj.transform.Find("BuyButton")?.GetComponent<Button>();
        if (buyButton != null)
        {
            // 捕获当前商品，避免循环变量问题
            ShopItemSO currentItem = item;
            buyButton.onClick.AddListener(() => BuyItem(currentItem));

            //// 如果商品已购买，禁用按钮
            //if (currentItem.isPurchased)
            //{
            //    buyButton.interactable = false;
            //    buyButton.GetComponentInChildren<Text>().text = "已购买";
            //}
        }
    }

    // 购买商品逻辑
    void BuyItem(ShopItemSO item)
    {
        // 注释掉已购判断
        // if (item.isPurchased)
        // {
        //     Debug.Log($"{item.itemName} 已购买过！");
        //     return;
        // }

        if (playerCurrency >= item.price)
        {
            playerCurrency -= item.price;
            // 注释掉标记已购的代码
            // item.isPurchased = true;
            UpdateCurrencyUI();
            LoadShopItems(); // 可以只更新UI，不需要重建列表
            Debug.Log($"购买成功：{item.itemName}，剩余货币：{playerCurrency}");
        }
        else
        {
            Debug.Log($"货币不足！需要{item.price}，当前只有{playerCurrency}");
        }
    }

    // 更新货币显示文本
    void UpdateCurrencyUI()
    {
        if (currencyText != null)
        {
            currencyText.text = $"货币：{playerCurrency}";
        }
    }
}