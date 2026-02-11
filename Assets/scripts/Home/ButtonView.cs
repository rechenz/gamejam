using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartMenuButtons : MonoBehaviour
{
    [Header("按钮图片素材")]
    public Sprite startNormal;
    public Sprite startHover;
    public Sprite exitNormal;
    public Sprite exitHover;

    [Header("场景设置")]
    public string gameSceneName = "GameScene";

    [Header("按钮名称（请确保场景中有同名对象）")]
    public string startButtonName = "StartButton";
    public string exitButtonName = "ExitButton";

    void Start()
    {
        // 设置开始按钮
        SetupButton(startButtonName, startNormal, startHover, StartGame);

        // 设置退出按钮
        SetupButton(exitButtonName, exitNormal, exitHover, ExitGame);

        Debug.Log("✅ 开始菜单按钮初始化完成");
    }

    void SetupButton(string buttonName, Sprite normalSprite, Sprite hoverSprite, UnityEngine.Events.UnityAction onClickAction)
    {
        // 1. 查找按钮对象
        GameObject buttonObj = GameObject.Find(buttonName);
        if (buttonObj == null)
        {
            Debug.LogError($"❌ 找不到按钮对象: {buttonName}，请检查场景中是否有该对象");
            return;
        }

        // 2. 获取Button组件
        Button button = buttonObj.GetComponent<Button>();
        if (button == null)
        {
            Debug.LogError($"❌ 按钮 {buttonName} 上没有Button组件！");
            return;
        }

        // 3. 获取Image组件
        Image image = buttonObj.GetComponent<Image>();
        if (image == null)
        {
            Debug.LogError($"❌ 按钮 {buttonName} 上没有Image组件！");
            return;
        }

        // 4. 设置默认图片
        if (normalSprite != null)
        {
            image.sprite = normalSprite;
            image.preserveAspect = true; // 保持图片比例
        }
        else
        {
            Debug.LogWarning($"⚠️ 按钮 {buttonName} 的普通状态图片未设置");
        }

        // 5. 设置Button的Sprite Swap（图片切换）
        if (hoverSprite != null)
        {
            // 创建新的SpriteState
            SpriteState spriteState = new SpriteState();
            spriteState.highlightedSprite = hoverSprite; // 鼠标悬停
            spriteState.pressedSprite = hoverSprite;     // 鼠标按下
            spriteState.selectedSprite = normalSprite;   // 选中状态

            button.spriteState = spriteState;
            button.transition = Selectable.Transition.SpriteSwap;
        }
        else
        {
            Debug.LogWarning($"⚠️ 按钮 {buttonName} 的悬停状态图片未设置，将使用默认效果");
            button.transition = Selectable.Transition.ColorTint;
        }

        // 6. 绑定点击事件（先清除旧事件，避免重复绑定）
        button.onClick.RemoveAllListeners();
        button.onClick.AddListener(onClickAction);

        // 7. 添加点击音效（可选，如果没有AudioSource会静默失败）
        AudioSource audioSource = GetComponent<AudioSource>();
        if (audioSource != null && audioSource.clip != null)
        {
            button.onClick.AddListener(() => audioSource.Play());
        }

        Debug.Log($"✅ 按钮 {buttonName} 设置完成");
    }

    /// <summary>
    /// 开始游戏方法
    /// </summary>
    void StartGame()
    {
        Debug.Log($"🎮 开始游戏，加载场景: {gameSceneName}");
        Clear(); // 清理记忆项
        // 检查场景是否存在
        if (Application.CanStreamedLevelBeLoaded(gameSceneName))
        {
            SceneManager.LoadScene(gameSceneName);
        }
        else
        {
            Debug.LogError($"❌ 场景 {gameSceneName} 不存在！请在Build Settings中添加该场景");

            // 备用方案：尝试加载索引1的场景
#if UNITY_EDITOR
            if (SceneManager.sceneCountInBuildSettings > 1)
            {
                Debug.Log("尝试加载Build Settings中索引为1的场景");
                SceneManager.LoadScene(1);
            }
#endif
        }
    }

    /// <summary>
    /// 退出游戏方法
    /// </summary>
    void ExitGame()
    {
        Debug.Log("👋 退出游戏");

#if UNITY_EDITOR
        // 在编辑器中停止运行
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // 在构建版本中退出游戏
        Application.Quit();
#endif
    }

    /// <summary>
    /// 重新绑定按钮（可在需要时手动调用）
    /// </summary>
    [ContextMenu("重新绑定按钮")]
    public void RebindButtons()
    {
        SetupButton(startButtonName, startNormal, startHover, StartGame);
        SetupButton(exitButtonName, exitNormal, exitHover, ExitGame);
    }

    /// <summary>
    /// 测试开始按钮图片
    /// </summary>
    [ContextMenu("测试开始按钮图片")]
    public void TestStartButtonSprites()
    {
        if (startNormal != null && startHover != null)
        {
            Debug.Log("开始按钮图片测试 - 正常");
        }
        else
        {
            Debug.LogWarning("开始按钮图片未完全设置");
        }
    }

    /// <summary>
    /// 测试退出按钮图片
    /// </summary>
    [ContextMenu("测试退出按钮图片")]
    public void TestExitButtonSprites()
    {
        if (exitNormal != null && exitHover != null)
        {
            Debug.Log("退出按钮图片测试 - 正常");
        }
        else
        {
            Debug.LogWarning("退出按钮图片未完全设置");
        }
    }

    //额外方法，用于清理记忆项
    private void Clear()
    {
        SimpleStateManager.Instance.ClearStates();
    }
}