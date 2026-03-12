using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class Aatar : MonoBehaviour
{
    public Button Button;
    public GameObject Panel;

    void Start()
    {
        // 初始化：弹窗默认隐藏（Profile初始状态为关闭）
        if (Panel != null)
        {
            Panel.SetActive(false);
        }

        // 绑定点击事件：点击Avatar按钮，只显示Profile弹窗（无法关闭）
        if (Button != null)
        {
            Button.onClick.AddListener(ShowProfileOnly);
        }
        else
        {
            Debug.LogError("请绑定按钮！");
        }
    }

    /// <summary>
    /// 只显示面板的核心方法（点击后只会打开，不会关闭）
    /// </summary>
    void ShowProfileOnly()
    {
        if (Panel != null)
        {
            // 强制设置为显示状态（不管当前是显示还是隐藏，点击后都只显示）
            Panel.SetActive(true);
        }
        else
        {
            Debug.LogError("请绑定面板！");
        }
    }


    void Update()
    {

    }
}