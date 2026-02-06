using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;

public class PasswordLockManager : MonoBehaviour
{
    public static PasswordLockManager Instance { get; private set; }

    [Header("预制体设置")]
    public GameObject passwordLockPrefab; // 在Inspector中设置

    [Header("备选方案")]
    [Tooltip("如果未设置预制体，将从Resources加载")]
    public string resourcesPath = "Prefabs/SimplePasswordLock"; // Resources文件夹路径

    [Header("摄像头设置")]
    [Tooltip("如果不指定，会自动使用Main Camera")]
    public Camera targetCamera;
    public bool useScreenSpaceCamera = true;
    public float canvasDistance = 100f; // Canvas离摄像头的距离

    // 当前活动的密码锁
    private SimplePasswordLock currentLock;
    private GameObject currentLockInstance;
    private Canvas passwordLockCanvas;

    void Awake()
    {
        // 单例模式
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeCanvas();
            LoadPasswordLockPrefab(); // 确保加载预制体
            Debug.Log("PasswordLockManager 初始化完成");
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        // 确保Canvas在场景切换时正确更新
        UnityEngine.SceneManagement.SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// 加载密码锁预制体
    /// </summary>
    void LoadPasswordLockPrefab()
    {
        // 如果已经在Inspector中设置了，就直接使用
        if (passwordLockPrefab != null)
        {
            Debug.Log("使用Inspector中设置的密码锁预制体");
            return;
        }

        // 否则从Resources文件夹加载
        if (!string.IsNullOrEmpty(resourcesPath))
        {
            passwordLockPrefab = Resources.Load<GameObject>(resourcesPath);
            if (passwordLockPrefab != null)
            {
                Debug.Log($"成功从Resources加载预制体: {resourcesPath}");
            }
            else
            {
                Debug.LogError($"无法从Resources加载预制体: {resourcesPath}");
                // 尝试加载默认路径
                passwordLockPrefab = Resources.Load<GameObject>("SimplePasswordLock");
            }
        }

        // 如果还是null，创建紧急备用预制体
        if (passwordLockPrefab == null)
        {
            Debug.LogWarning("创建紧急备用密码锁预制体");
            CreateEmergencyPrefab();
        }
    }

    /// <summary>
    /// 创建紧急备用预制体（防止预制体丢失）
    /// </summary>
    void CreateEmergencyPrefab()
    {
        // 创建一个简单的UI作为备用
        GameObject emergencyPrefab = new GameObject("EmergencyPasswordLock");

        // 添加UI组件
        Canvas canvas = emergencyPrefab.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        emergencyPrefab.AddComponent<CanvasScaler>();
        emergencyPrefab.AddComponent<GraphicRaycaster>();

        // 创建背景
        GameObject background = new GameObject("Background");
        background.transform.SetParent(emergencyPrefab.transform);
        Image bgImage = background.AddComponent<Image>();
        bgImage.color = new Color(0, 0, 0, 0.8f);

        RectTransform bgRect = background.GetComponent<RectTransform>();
        bgRect.anchorMin = Vector2.zero;
        bgRect.anchorMax = Vector2.one;
        bgRect.offsetMin = Vector2.zero;
        bgRect.offsetMax = Vector2.zero;

        // 添加文本显示
        GameObject textObj = new GameObject("DisplayText");
        textObj.transform.SetParent(background.transform);
        TMPro.TMP_Text text = textObj.AddComponent<TMPro.TMP_Text>();
        text.text = "密码锁加载失败\n请检查预制体设置";
        text.color = Color.white;
        text.alignment = TMPro.TextAlignmentOptions.Center;

        RectTransform textRect = textObj.GetComponent<RectTransform>();
        textRect.anchoredPosition = Vector2.zero;
        textRect.sizeDelta = new Vector2(400, 100);

        // 设置为预制体
        passwordLockPrefab = emergencyPrefab;
    }

    // ========== Canvas管理 ==========

    void InitializeCanvas()
    {
        // 如果已经存在Canvas，就使用现有的
        if (passwordLockCanvas != null)
        {
            return;
        }

        // 查找现有的Canvas
        Canvas existingCanvas = FindObjectOfType<Canvas>();
        if (existingCanvas != null && existingCanvas.name == "PasswordLockCanvas")
        {
            passwordLockCanvas = existingCanvas;
            DontDestroyOnLoad(passwordLockCanvas.gameObject);
            Debug.Log("找到现有PasswordLockCanvas");
            return;
        }

        // 创建新的Canvas
        CreatePasswordLockCanvas();
    }

    void CreatePasswordLockCanvas()
    {
        GameObject canvasObj = new GameObject("PasswordLockCanvas");
        passwordLockCanvas = canvasObj.AddComponent<Canvas>();

        // 设置Canvas
        SetupCanvasForCamera();

        // 添加必要组件
        CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        scaler.screenMatchMode = CanvasScaler.ScreenMatchMode.MatchWidthOrHeight;
        scaler.matchWidthOrHeight = 0.5f;

        canvasObj.AddComponent<GraphicRaycaster>();

        // 确保不会被销毁
        DontDestroyOnLoad(canvasObj);

        Debug.Log("密码锁专用Canvas已创建");
    }

    void SetupCanvasForCamera()
    {
        if (passwordLockCanvas == null) return;

        Camera camera = GetTargetCamera();

        if (useScreenSpaceCamera && camera != null)
        {
            passwordLockCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            passwordLockCanvas.worldCamera = camera;
            passwordLockCanvas.planeDistance = canvasDistance;
            passwordLockCanvas.sortingOrder = 1000;

            Debug.Log($"Canvas已绑定到摄像头: {camera.name}");
        }
        else
        {
            passwordLockCanvas.renderMode = RenderMode.ScreenSpaceOverlay;
            Debug.Log("Canvas使用Screen Space - Overlay模式");
        }
    }

    Camera GetTargetCamera()
    {
        // 优先使用指定的摄像头
        if (targetCamera != null)
        {
            return targetCamera;
        }

        // 查找Main Camera
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            return mainCamera;
        }

        // 查找任何激活的摄像头
        Camera[] cameras = FindObjectsOfType<Camera>();
        foreach (Camera cam in cameras)
        {
            if (cam.gameObject.activeInHierarchy && cam.enabled)
            {
                return cam;
            }
        }

        Debug.LogWarning("场景中没有找到激活的摄像头！");
        return null;
    }

    /// <summary>
    /// 更新Canvas的摄像头引用（场景切换时调用）
    /// </summary>
    public void UpdateCanvasCamera()
    {
        if (passwordLockCanvas == null)
        {
            CreatePasswordLockCanvas();
            return;
        }

        Camera camera = GetTargetCamera();
        if (camera != null)
        {
            passwordLockCanvas.worldCamera = camera;
            Debug.Log($"Canvas摄像头已更新为: {camera.name}");
        }
    }

    // ========== 密码锁管理 ==========

    SimplePasswordLock CreateLockInstance()
    {
        if (passwordLockPrefab == null)
        {
            LoadPasswordLockPrefab(); // 再次尝试加载
            if (passwordLockPrefab == null)
            {
                Debug.LogError("密码锁预制体未设置且无法加载！");
                return null;
            }
        }

        // 确保Canvas存在
        if (passwordLockCanvas == null)
        {
            CreatePasswordLockCanvas();
        }

        // 清除之前的实例
        if (currentLockInstance != null)
        {
            Destroy(currentLockInstance);
        }

        // 实例化到专用Canvas下
        currentLockInstance = Instantiate(passwordLockPrefab, passwordLockCanvas.transform);
        currentLockInstance.name = "PasswordLock_Instance";

        // 调整位置和大小
        RectTransform rt = currentLockInstance.GetComponent<RectTransform>();
        if (rt != null)
        {
            rt.anchoredPosition = Vector2.zero;
            rt.localScale = Vector3.one;
        }

        SimplePasswordLock lockScript = currentLockInstance.GetComponent<SimplePasswordLock>();
        if (lockScript == null)
        {
            Debug.LogError("预制体上没有SimplePasswordLock脚本！");
            lockScript = currentLockInstance.AddComponent<SimplePasswordLock>();
            Debug.Log("已添加SimplePasswordLock脚本组件");
        }

        return lockScript;
    }

    /// <summary>
    /// 显示密码锁
    /// </summary>
    public SimplePasswordLock ShowPasswordLock(string password, System.Action onUnlockCallback = null)
    {
        Debug.Log($"请求显示密码锁，密码: {password}");

        // 关闭当前锁（如果存在）
        if (currentLock != null)
        {
            CloseCurrentLock();
        }

        // 确保Canvas正确设置
        UpdateCanvasCamera();

        // 创建新锁
        currentLock = CreateLockInstance();
        if (currentLock == null)
        {
            Debug.LogError("无法创建密码锁实例！");
            return null;
        }

        // 配置密码
        currentLock.SetPassword(password);

        // 设置解锁回调
        if (onUnlockCallback != null)
        {
            currentLock.OnUnlock += onUnlockCallback;
        }

        // 打开锁界面
        currentLock.OpenLock();

        Debug.Log($"密码锁已显示，密码位数: {password.Length}");
        return currentLock;
    }

    public void CloseCurrentLock()
    {
        if (currentLock != null)
        {
            currentLock.CloseLock();
        }

        if (currentLockInstance != null)
        {
            Destroy(currentLockInstance);
            currentLockInstance = null;
        }

        currentLock = null;
    }

    // ========== 静态方法 ==========

    public static SimplePasswordLock Show(string password, System.Action onUnlock = null)
    {
        if (Instance == null)
        {
            Debug.LogError("PasswordLockManager实例不存在！请确保在CoreScene中初始化。");
            return null;
        }

        return Instance.ShowPasswordLock(password, onUnlock);
    }

    public static void Close()
    {
        if (Instance != null)
        {
            Instance.CloseCurrentLock();
        }
    }

    // ========== 场景切换处理 ==========

    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        Debug.Log($"场景切换: {scene.name}, 更新Canvas摄像头");

        // 更新摄像头引用
        UpdateCanvasCamera();

        // 如果有密码锁正在显示，重新居中
        if (currentLockInstance != null)
        {
            RectTransform rt = currentLockInstance.GetComponent<RectTransform>();
            if (rt != null)
            {
                rt.anchoredPosition = Vector2.zero;
            }
        }
    }

    // ========== 公共属性 ==========

    public bool IsLockShowing()
    {
        return currentLock != null && currentLockInstance != null;
    }

    public SimplePasswordLock GetCurrentLock()
    {
        return currentLock;
    }

    // ========== 生命周期 ==========

    void OnDestroy()
    {
        if (Instance == this)
        {
            Instance = null;
            UnityEngine.SceneManagement.SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }
}