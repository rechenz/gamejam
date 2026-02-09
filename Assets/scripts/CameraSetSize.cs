using UnityEngine;

public class AdaptiveGameCamera : MonoBehaviour
{
    [System.Serializable]
    public class GameArea
    {
        public float width = 19.2f;
        public float height = 10.7f;
        public Color gizmoColor = Color.cyan;

        public float Aspect => width > 0 && height > 0 ? width / height : 1f;
    }

    [System.Serializable]
    public class AdaptiveSettings
    {
        [Range(0, 1)]
        public float horizontalFit = 0.5f;
        public bool showGameArea = true;
        public bool showSafeArea = true;
        public FitMode fitMode = FitMode.Adaptive;
    }

    public enum FitMode
    {
        FitToWidth,      // 保证宽度完全显示
        FitToHeight,     // 保证高度完全显示
        FitInside,       // 保证整个游戏区域在视野内
        FitOutside,      // 保证填充屏幕
        Adaptive         // 根据horizontalFit混合
    }

    [Header("游戏区域")]
    public GameArea gameArea = new GameArea();

    [Header("自适应设置")]
    public AdaptiveSettings settings = new AdaptiveSettings();

    [Header("安全区域")]
    public float safeAreaPadding = 0.5f;

    [Header("调试")]
    public bool showDebugInfo = false;

    private Camera cam;
    private Vector2Int lastScreenSize;

    void Awake()
    {
        cam = GetComponent<Camera>();
        if (cam == null)
        {
            Debug.LogError("AdaptiveGameCamera需要Camera组件！");
            enabled = false;
            return;
        }

        lastScreenSize = new Vector2Int(Screen.width, Screen.height);
        AdaptToScreen();
    }

    void Update()
    {
        Vector2Int currentSize = new Vector2Int(Screen.width, Screen.height);
        if (currentSize != lastScreenSize)
        {
            AdaptToScreen();
            lastScreenSize = currentSize;
        }
    }

    void OnValidate()
    {
        // 确保值有效
        gameArea.width = Mathf.Max(0.1f, gameArea.width);
        gameArea.height = Mathf.Max(0.1f, gameArea.height);
        safeAreaPadding = Mathf.Clamp(safeAreaPadding, 0, Mathf.Min(gameArea.width, gameArea.height) / 2);
    }

    void AdaptToScreen()
    {
        if (cam == null) return;

        float screenAspect = cam.aspect;
        float gameAspect = gameArea.Aspect;

        switch (settings.fitMode)
        {
            case FitMode.FitToWidth:
                FitToWidth(screenAspect);
                break;

            case FitMode.FitToHeight:
                FitToHeight();
                break;

            case FitMode.FitInside:
                FitInside(screenAspect, gameAspect);
                break;

            case FitMode.FitOutside:
                FitOutside(screenAspect, gameAspect);
                break;

            case FitMode.Adaptive:
                AdaptiveFit(screenAspect);
                break;
        }

        if (showDebugInfo)
        {
            Debug.Log($"[AdaptiveCamera] 模式: {settings.fitMode}, " +
                     $"大小: {cam.orthographicSize:F2}, " +
                     $"可见: {GetVisibleWidth():F1}×{GetVisibleHeight():F1}");
        }
    }

    #region 适配方法
    void FitToWidth(float screenAspect)
    {
        cam.orthographicSize = (gameArea.width / screenAspect) / 2f;
    }

    void FitToHeight()
    {
        cam.orthographicSize = gameArea.height / 2f;
    }

    void FitInside(float screenAspect, float gameAspect)
    {
        if (screenAspect > gameAspect)
        {
            FitToHeight();
        }
        else
        {
            FitToWidth(screenAspect);
        }
    }

    void FitOutside(float screenAspect, float gameAspect)
    {
        if (screenAspect > gameAspect)
        {
            FitToWidth(screenAspect);
        }
        else
        {
            FitToHeight();
        }
    }

    void AdaptiveFit(float screenAspect)
    {
        float sizeByHeight = gameArea.height / 2f;
        float sizeByWidth = (gameArea.width / screenAspect) / 2f;

        cam.orthographicSize = Mathf.Lerp(sizeByWidth, sizeByHeight, settings.horizontalFit);
    }
    #endregion

    #region Gizmos
    void OnDrawGizmos()
    {
        if (!settings.showGameArea) return;

        Camera drawingCam = cam;
        if (drawingCam == null && Application.isPlaying)
            drawingCam = Camera.main;
        if (drawingCam == null)
            drawingCam = GetComponent<Camera>();

        Vector3 center = transform.position;

        // 绘制游戏区域
        Gizmos.color = gameArea.gizmoColor;
        Vector3 gameSize = new Vector3(gameArea.width, gameArea.height, 0.1f);
        Gizmos.DrawWireCube(center, gameSize);

        // 绘制安全区域
        if (settings.showSafeArea)
        {
            Gizmos.color = Color.yellow;
            Vector3 safeSize = new Vector3(
                Mathf.Max(0, gameArea.width - safeAreaPadding * 2),
                Mathf.Max(0, gameArea.height - safeAreaPadding * 2),
                0.1f
            );
            Gizmos.DrawWireCube(center, safeSize);
        }

        // 绘制摄像机可见区域
        if (drawingCam != null && drawingCam.orthographic)
        {
            Gizmos.color = Color.green;
            float camHeight = drawingCam.orthographicSize * 2;
            float camWidth = camHeight * drawingCam.aspect;
            Vector3 camSize = new Vector3(camWidth, camHeight, 0.1f);
            Gizmos.DrawWireCube(center, camSize);
        }
    }
    #endregion

    #region 公共方法
    public void SetGameArea(float width, float height)
    {
        gameArea.width = Mathf.Max(0.1f, width);
        gameArea.height = Mathf.Max(0.1f, height);
        AdaptToScreen();
    }

    public void SetAdaptiveWeight(float weight)
    {
        settings.horizontalFit = Mathf.Clamp01(weight);
        if (settings.fitMode == FitMode.Adaptive)
            AdaptToScreen();
    }

    public void SetFitMode(FitMode mode)
    {
        settings.fitMode = mode;
        AdaptToScreen();
    }

    public float GetVisibleWidth()
    {
        if (cam == null) return 0;
        return cam.orthographicSize * 2 * cam.aspect;
    }

    public float GetVisibleHeight()
    {
        if (cam == null) return 0;
        return cam.orthographicSize * 2;
    }

    public Vector2 GetVisibleGameAreaPercentage()
    {
        if (cam == null) return Vector2.zero;

        float visibleWidth = GetVisibleWidth();
        float visibleHeight = GetVisibleHeight();

        return new Vector2(
            Mathf.Clamp01(visibleWidth / gameArea.width),
            Mathf.Clamp01(visibleHeight / gameArea.height)
        );
    }
    #endregion

    #region 调试GUI（仅在开发中使用）
    void OnGUI()
    {
        if (!showDebugInfo || !Application.isPlaying || cam == null) return;

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 14;
        style.padding = new RectOffset(10, 10, 10, 10);

        // 半透明背景
        Texture2D bgTex = new Texture2D(1, 1);
        bgTex.SetPixel(0, 0, new Color(0, 0, 0, 0.7f));
        bgTex.Apply();
        style.normal.background = bgTex;

        // 计算位置（右上角）
        float boxWidth = 320;
        float boxHeight = 180;
        float margin = 10;
        Rect boxRect = new Rect(Screen.width - boxWidth - margin, margin, boxWidth, boxHeight);

        GUILayout.BeginArea(boxRect);
        GUILayout.BeginVertical("Box");

        GUILayout.Label($"=== 自适应摄像机 ===", style);
        GUILayout.Space(5);

        GUILayout.Label($"模式: {settings.fitMode}", style);
        GUILayout.Label($"游戏区域: {gameArea.width:F1}×{gameArea.height:F1}", style);
        GUILayout.Label($"屏幕: {Screen.width}×{Screen.height} ({cam.aspect:F2})", style);
        GUILayout.Label($"摄像机大小: {cam.orthographicSize:F2}", style);

        var coverage = GetVisibleGameAreaPercentage();
        GUILayout.Label($"可见比例: 宽{coverage.x:P0} 高{coverage.y:P0}", style);

        if (settings.fitMode == FitMode.Adaptive)
        {
            GUILayout.Space(5);
            GUILayout.Label($"适配权重: {settings.horizontalFit:F2}", style);
        }

        GUILayout.EndVertical();
        GUILayout.EndArea();

        // 清理Texture2D防止内存泄漏
        if (Event.current.type == EventType.Repaint)
        {
            Destroy(bgTex);
        }
    }
    #endregion
}