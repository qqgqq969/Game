using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // 新增：场景管理命名空间
using System.Collections.Generic;

public class CharSelectUI : MonoBehaviour
{
    [System.Serializable]
    public class CharData
    {
        public Sprite charImage;
        public string charName;
        [TextArea] public string charDesc;
    }

    // 原有角色选择相关变量
    public Image charBigImage;
    public Text charNameText;
    public Text charDescText;
    public List<CharData> charDataList;
    public List<Button> charBtnList;
    public Color normalColor = Color.white;
    public Color selectedColor = Color.yellow;

    // 新增：场景跳转按钮变量
    public Button btnBack;       // 返回上一场景按钮
    public Button btnStartGame;  // 开始游戏按钮
    public int gameSceneIndex = 2; // 游戏界面场景的BuildIndex（可自行修改）
    public int menuSceneIndex = 0; // 主菜单场景的BuildIndex（可自行修改）

    void Start()
    {
        // 原有：初始化角色选择按钮事件
        for (int i = 0; i < charBtnList.Count; i++)
        {
            int index = i;
            charBtnList[i].onClick.AddListener(() => OnCharBtnClick(index));
        }
        // 默认显示第一个角色
        OnCharBtnClick(0);

        // 新增：绑定场景跳转按钮事件
        if (btnBack != null)
            btnBack.onClick.AddListener(GoBackToMenu);
        if (btnStartGame != null)
            btnStartGame.onClick.AddListener(GoToGameScene);
    }

    // 原有：角色按钮点击逻辑
    void OnCharBtnClick(int index)
    {
        charBigImage.sprite = charDataList[index].charImage;
        charNameText.text = charDataList[index].charName;
        charDescText.text = charDataList[index].charDesc;

        foreach (var btn in charBtnList)
        {
            btn.image.color = normalColor;
        }
        charBtnList[index].image.color = selectedColor;
    }

    // 新增：返回上一场景（主菜单）
    void GoBackToMenu()
    {
        SceneManager.LoadScene(menuSceneIndex);
    }

    // 新增：跳转到游戏界面
    void GoToGameScene()
    {
        SceneManager.LoadScene(gameSceneIndex);
    }
}