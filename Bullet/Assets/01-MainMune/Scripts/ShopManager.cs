using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class ShopManager : MonoBehaviour
{
    [Header("UI引用")]
    public Transform itemContentParent; // 商品项父物体（ItemContent）
    public GameObject shopItemPrefab;   // 商品项预制体
    public TextMeshProUGUI currencyText;// 货币显示文本
    public int playerCurrency = 1000;   // 玩家初始货币

    [Header("商品数据")]
    public List<ShopItemSO> shopItems;  // 商店商品列表（手动拖入创建的ShopItemSO）

    void Start()
    {
        UpdateCurrencyUI(); // 初始化货币显示
        LoadShopItems();    // 加载所有商品
    }

    // 加载商店所有商品
    void LoadShopItems()
    {
        // 清空已有商品项
        foreach (Transform child in itemContentParent)
        {
            Destroy(child.gameObject);
        }

        // 遍历商品列表，生成每个商品项
        foreach (ShopItemSO item in shopItems)
        {
            GameObject itemObj = Instantiate(shopItemPrefab, itemContentParent);
            // 获取预制体中的UI组件
            Image iconImage = itemObj.transform.Find("IconImage").GetComponent<Image>();
            TextMeshProUGUI nameText = itemObj.transform.Find("NameText").GetComponent<TextMeshProUGUI>();
            TextMeshProUGUI priceText = itemObj.transform.Find("PriceText").GetComponent<TextMeshProUGUI>();
            Button buyBtn = itemObj.transform.Find("BuyButton").GetComponent<Button>();

            // 赋值商品信息
            iconImage.sprite = item.itemIcon;
            nameText.text = item.itemName;
            priceText.text = $"价格：{item.price}";

            // 绑定购买按钮事件（使用闭包避免循环变量问题）
            ShopItemSO currentItem = item;
            buyBtn.onClick.AddListener(() => BuyItem(currentItem));

            // 如果商品已购买，禁用按钮
            if (currentItem.isPurchased)
            {
                buyBtn.interactable = false;
                buyBtn.GetComponentInChildren<TextMeshProUGUI>().text = "已购买";
            }
        }
    }

    // 购买商品逻辑
    void BuyItem(ShopItemSO item)
    {
        // 检查是否已购买
        if (item.isPurchased)
        {
            Debug.Log($"{item.itemName}已购买！");
            return;
        }

        // 检查货币是否足够
        if (playerCurrency >= item.price)
        {
            // 扣除货币
            playerCurrency -= item.price;
            UpdateCurrencyUI();

            // 标记商品为已购买
            item.isPurchased = true;

            // 刷新商店界面
            LoadShopItems();

            Debug.Log($"成功购买{item.itemName}！剩余货币：{playerCurrency}");
            // 这里可扩展：添加购买成功的提示、解锁道具等逻辑
        }
        else
        {
            Debug.Log("货币不足！");
            // 可添加货币不足的UI提示
        }
    }

    // 更新货币显示UI
    void UpdateCurrencyUI()
    {
        currencyText.text = $"货币：{playerCurrency}";
    }

    // 关闭商店（示例方法，绑定到CloseButton）
    public void CloseShop()
    {
        gameObject.SetActive(false);
    }
}