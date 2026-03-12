using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.UI;

public class Aatar : MonoBehaviour
{
    public Button Avatar;
    public GameObject Profile;

    void Start()
    {
        // 初始化：弹窗默认隐藏（Profile初始状态为关闭）
        if (Profile != null)
        {
            Profile.SetActive(false);
        }

        // 绑定点击事件：点击Avatar按钮，只显示Profile弹窗（无法关闭）
        if (Avatar != null)
        {
            Avatar.onClick.AddListener(ShowProfileOnly);
        }
        else
        {
            Debug.LogError("请绑定你命名为Avatar的按钮！");
        }
    }

    /// <summary>
    /// 只显示面板的核心方法（点击后只会打开，不会关闭）
    /// </summary>
    void ShowProfileOnly()
    {
        if (Profile != null)
        {
            // 强制设置为显示状态（不管当前是显示还是隐藏，点击后都只显示）
            Profile.SetActive(true);
        }
        else
        {
            Debug.LogError("请绑定你命名为Profile的面板！");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}