using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    [Header("需要绑定的对象")]
    public Button targetButton; // 你要点击的按钮
    public GameObject targetPanel; // 你要隐藏的面板（Panel）

    void Start()
    {
        // 安全校验：防止没绑定对象导致报错
        if (targetButton == null)
        {
            Debug.LogError("请在Inspector中绑定要点击的按钮！");
            return;
        }
        if (targetPanel == null)
        {
            Debug.LogError("请在Inspector中绑定要隐藏的面板！");
            return;
        }

        // 绑定按钮点击事件：点击按钮就执行隐藏面板的方法
        targetButton.onClick.AddListener(HideTargetPanel);
    }

    /// <summary>
    /// 隐藏指定面板的核心方法
    /// </summary>
    void HideTargetPanel()
    {
        // 隐藏面板（SetActive(false) = 彻底隐藏，不占渲染资源）
        targetPanel.SetActive(false);
        Debug.Log($"面板 {targetPanel.name} 已隐藏");
    }

    // （可选）如果需要“显示面板”的功能，添加这个方法
    public void ShowTargetPanel()
    {
        targetPanel.SetActive(true);
        Debug.Log($"面板 {targetPanel.name} 已显示");
    }
}
