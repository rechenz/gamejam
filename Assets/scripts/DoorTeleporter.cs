using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

[RequireComponent(typeof(BoxCollider2D))]
public class DoorTeleporter : MonoBehaviour
{
    [Header("传送设置")]
    [Tooltip("目标场景名称")]
    public string targetScene = "NextLevel";

    [Tooltip("在目标场景中的重生位置")]
    public Vector2 spawnPosition = Vector2.zero;

    [Header("碰撞体设置")]
    [Tooltip("碰撞体偏移")]
    public Vector2 colliderOffset = Vector2.zero;

    [Tooltip("碰撞体大小")]
    public Vector2 colliderSize = new Vector2(0.8f, 1.8f);

    [Header("触发设置")]
    [Tooltip("需要触发的标签")]
    public string triggerTag = "Player";

    [Tooltip("是否只允许从特定方向进入")]
    public bool directionalTrigger = false;

    [Tooltip("允许进入的方向")]
    public EnterDirection allowedDirection = EnterDirection.Any;

    [Header("效果设置")]
    [Tooltip("传送延迟时间")]
    public float teleportDelay = 0f;

    [Tooltip("传送时是否播放音效")]
    public bool playSound = true;

    [Tooltip("传送音效")]
    public AudioClip teleportSound;

    [Header("调试")]
    [Tooltip("显示调试信息")]
    public bool showDebug = true;

    [Tooltip("传送门颜色")]
    public Color gizmoColor = new Color(0.2f, 0.8f, 1f, 0.5f);

    [Header("是否在传送门范围内")]
    public bool isInRange = false;

    [Header("角色对象")]
    public GameObject player;
    public enum EnterDirection
    {
        Any,    // 任何方向
        Left,   // 只能从左边进入
        Right,  // 只能从右边进入
        Bottom, // 只能从下面进入
        Top     // 只能从上面进入
    }

    // 组件引用
    private BoxCollider2D triggerCollider;
    private bool isTeleporting = false;
    private Coroutine teleportCoroutine;

    void Awake()
    {
        // 获取碰撞体组件
        triggerCollider = GetComponent<BoxCollider2D>();

        // 配置碰撞体
        SetupCollider();

        // 验证设置
        ValidateSettings();
    }

    void SetupCollider()
    {
        if (triggerCollider == null)
        {
            triggerCollider = gameObject.AddComponent<BoxCollider2D>();
        }

        // 确保是触发器
        triggerCollider.isTrigger = true;

        // 设置碰撞体大小和偏移
        triggerCollider.offset = colliderOffset;
        triggerCollider.size = colliderSize;
    }

    void ValidateSettings()
    {
        if (string.IsNullOrEmpty(targetScene))
        {
            Debug.LogError($"{gameObject.name}: 未设置目标场景！", this);
            enabled = false;
            return;
        }

        if (string.IsNullOrEmpty(triggerTag))
        {
            triggerTag = "Player";
            if (showDebug)
            {
                Debug.LogWarning($"{gameObject.name}: 未设置触发标签，使用默认值 'Player'", this);
            }
        }

        // 确保碰撞体大小有效
        colliderSize.x = Mathf.Max(0.1f, colliderSize.x);
        colliderSize.y = Mathf.Max(0.1f, colliderSize.y);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (isTeleporting || !enabled) return;

        // 检查标签
        if (!other.CompareTag(triggerTag)) return;

        // 检查方向
        if (directionalTrigger && !CheckEnterDirection(other.transform.position))
        {
            if (showDebug)
            {
                Debug.Log($"{gameObject.name}: 玩家从错误方向接近", this);
            }
            return;
        }
        Debug.Log("玩家接近传送门");
        isInRange = true;
        player = other.gameObject;
        // 开始传送
        // teleportCoroutine = StartCoroutine(TeleportCoroutine(other.gameObject));
    }

    void OnTriggerExit2D(Collider2D other)
    {
        isInRange = false;
        // 如果玩家在传送前离开，取消传送
        if (isTeleporting && other.CompareTag(triggerTag))
        {
            CancelTeleport();
        }
    }

    bool CheckEnterDirection(Vector3 playerPosition)
    {
        Vector3 direction = playerPosition - GetColliderWorldCenter();

        switch (allowedDirection)
        {
            case EnterDirection.Left:
                return direction.x < 0; // 玩家在门的左边

            case EnterDirection.Right:
                return direction.x > 0; // 玩家在门的右边

            case EnterDirection.Bottom:
                return direction.y < 0; // 玩家在门的下方

            case EnterDirection.Top:
                return direction.y > 0; // 玩家在门的上方

            default:
                return true;
        }
    }

    IEnumerator TeleportCoroutine(GameObject player)
    {
        isTeleporting = true;

        if (showDebug)
        {
            Debug.Log($"{gameObject.name}: 开始传送玩家到 {targetScene}", this);
        }

        // 播放音效
        if (playSound && teleportSound != null)
        {
            AudioSource.PlayClipAtPoint(teleportSound, transform.position, 1f);
        }

        // 禁用玩家控制
        DisablePlayer(player);

        // 等待传送延迟
        if (teleportDelay > 0)
        {
            yield return new WaitForSeconds(teleportDelay);
        }

        // // 检查玩家是否还在触发区域内
        // if (!IsPlayerInTrigger(player))
        // {
        //     Debug.Log($"{gameObject.name}: 玩家已离开传送区域，取消传送", this);
        //     EnablePlayer(player);
        //     isTeleporting = false;
        //     yield break;
        // }

        // 保存重生位置
        SaveSpawnPosition();

        // 加载目标场景
        LoadTargetScene();
    }

    void CancelTeleport()
    {
        if (teleportCoroutine != null)
        {
            StopCoroutine(teleportCoroutine);
            teleportCoroutine = null;
        }
        isTeleporting = false;

        if (showDebug)
        {
            Debug.Log($"{gameObject.name}: 传送已取消", this);
        }
    }

    bool IsPlayerInTrigger(GameObject player)
    {
        if (player == null) return false;

        Collider2D playerCollider = player.GetComponent<Collider2D>();
        if (playerCollider == null) return false;

        return triggerCollider.bounds.Intersects(playerCollider.bounds);
    }

    void DisablePlayer(GameObject player)
    {
        // 临时禁用玩家控制脚本
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script != null && script != this && script.enabled)
            {
                script.enabled = false;
            }
        }

        // 停止物理运动
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
            rb.simulated = false;
        }

        // 可选：隐藏玩家
        SpriteRenderer sprite = player.GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.enabled = false;
        }
    }

    void EnablePlayer(GameObject player)
    {
        if (player == null) return;

        // 重新启用玩家控制
        MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
        foreach (var script in scripts)
        {
            if (script != null && script != this)
            {
                script.enabled = true;
            }
        }

        // 启用物理
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.simulated = true;
        }

        // 显示玩家
        SpriteRenderer sprite = player.GetComponent<SpriteRenderer>();
        if (sprite != null)
        {
            sprite.enabled = true;
        }
    }

    void SaveSpawnPosition()
    {
        // 保存到PlayerPrefs（简单方法）
        PlayerPrefs.SetFloat("DoorSpawn_X", spawnPosition.x);
        PlayerPrefs.SetFloat("DoorSpawn_Y", spawnPosition.y);
        PlayerPrefs.SetString("DoorFromScene", SceneManager.GetActiveScene().name);
        PlayerPrefs.Save();

        if (showDebug)
        {
            Debug.Log($"{gameObject.name}: 保存重生位置 {spawnPosition}", this);
        }
    }

    void LoadTargetScene()
    {
        if (showDebug)
        {
            Debug.Log($"{gameObject.name}: 加载场景 {targetScene}", this);
        }

        try
        {
            SceneManager.LoadScene(targetScene);
        }
        catch (System.Exception e)
        {
            Debug.LogError($"{gameObject.name}: 加载场景失败 - {e.Message}", this);
            isTeleporting = false;
        }
    }

    // 静态方法：在其他场景中获取重生位置
    public static Vector2 GetDoorSpawnPosition()
    {
        if (PlayerPrefs.HasKey("DoorSpawn_X"))
        {
            float x = PlayerPrefs.GetFloat("DoorSpawn_X");
            float y = PlayerPrefs.GetFloat("DoorSpawn_Y");

            // 清除保存的数据（防止重复使用）
            PlayerPrefs.DeleteKey("DoorSpawn_X");
            PlayerPrefs.DeleteKey("DoorSpawn_Y");
            PlayerPrefs.DeleteKey("DoorFromScene");

            return new Vector2(x, y);
        }

        return Vector2.zero;
    }

    void OnDestroy()
    {
        // 清理协程
        if (teleportCoroutine != null)
        {
            StopCoroutine(teleportCoroutine);
        }
    }

    // 获取碰撞体的世界坐标中心
    Vector3 GetColliderWorldCenter()
    {
        if (triggerCollider == null) return transform.position;
        return transform.TransformPoint(triggerCollider.offset);
    }

    // 获取碰撞体的世界坐标尺寸（考虑缩放）
    Vector3 GetColliderWorldSize()
    {
        if (triggerCollider == null) return colliderSize;
        Vector3 lossyScale = transform.lossyScale;
        return new Vector3(
            colliderSize.x * lossyScale.x,
            colliderSize.y * lossyScale.y,
            0
        );
    }

    void Update()
    {
        if (isTeleporting) return;

        if (Input.GetKeyDown(KeyCode.F) && isInRange)
        {
            if (player != null)
            {
                Debug.Log($"准备传送玩家: {player.name}");
                teleportCoroutine = StartCoroutine(TeleportCoroutine(player));
            }
            else
            {
                Debug.LogError("玩家对象为空！");
            }
        }

        // 调试信息
        if (showDebug && Time.frameCount % 60 == 0) // 每秒一次
        {
            Debug.Log($"状态: isInRange={isInRange}, player={player != null}, isTeleporting={isTeleporting}");
        }
    }

    // 编辑器工具
    [ContextMenu("测试传送")]
    void TestTeleport()
    {
        if (!Application.isPlaying)
        {
            Debug.LogWarning("只能在运行模式下测试传送！", this);
            return;
        }

        GameObject player = GameObject.FindGameObjectWithTag(triggerTag);
        if (player != null && !isTeleporting)
        {
            teleportCoroutine = StartCoroutine(TeleportCoroutine(player));
        }
        else if (player == null)
        {
            Debug.LogError($"未找到标签为 '{triggerTag}' 的物体", this);
        }
    }

    [ContextMenu("设为向右的出口")]
    void SetAsRightExit()
    {
        directionalTrigger = true;
        allowedDirection = EnterDirection.Left; // 只能从左边进入（玩家向右走）
        colliderOffset = new Vector2(0.5f, 0);
        colliderSize = new Vector2(0.2f, 1.5f);

        // 更新碰撞体
        if (triggerCollider != null)
        {
            triggerCollider.offset = colliderOffset;
            triggerCollider.size = colliderSize;
        }

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif

        Debug.Log($"{gameObject.name}: 已设为向右的出口", this);
    }

    [ContextMenu("设为向左的出口")]
    void SetAsLeftExit()
    {
        directionalTrigger = true;
        allowedDirection = EnterDirection.Right; // 只能从右边进入（玩家向左走）
        colliderOffset = new Vector2(-0.5f, 0);
        colliderSize = new Vector2(0.2f, 1.5f);

        // 更新碰撞体
        if (triggerCollider != null)
        {
            triggerCollider.offset = colliderOffset;
            triggerCollider.size = colliderSize;
        }

#if UNITY_EDITOR
        UnityEditor.EditorUtility.SetDirty(this);
#endif

        Debug.Log($"{gameObject.name}: 已设为向左的出口", this);
    }

    // 在Scene视图中绘制
    void OnDrawGizmos()
    {
        if (!enabled) return;

        // 绘制半透明的门区域
        Gizmos.color = gizmoColor;

        // 使用正确的世界坐标
        Vector3 worldCenter = GetColliderWorldCenter();
        Vector3 worldSize = GetColliderWorldSize();

        Gizmos.DrawCube(worldCenter, worldSize);

        // 绘制门框
        Gizmos.color = new Color(gizmoColor.r, gizmoColor.g, gizmoColor.b, 1f);
        Gizmos.DrawWireCube(worldCenter, worldSize);
    }

    void OnDrawGizmosSelected()
    {
        if (!enabled) return;

        // 选中时绘制额外信息
        Vector3 worldCenter = GetColliderWorldCenter();
        Vector3 worldSize = GetColliderWorldSize();

        // 绘制方向箭头
        if (directionalTrigger)
        {
            Gizmos.color = Color.yellow;
            Vector3 arrowDirection = GetDirectionVector();

            // 调整箭头起点到碰撞体边缘
            Vector3 arrowStart = worldCenter + new Vector3(
                (arrowDirection.x * worldSize.x * 0.5f) * 0.8f,
                (arrowDirection.y * worldSize.y * 0.5f) * 0.8f,
                0
            );

            Gizmos.DrawLine(arrowStart, arrowStart + arrowDirection * 1f);

            // 绘制箭头头部
            Vector3 arrowHead = arrowStart + arrowDirection * 1f;
            Vector3 perpendicular = new Vector3(-arrowDirection.y, arrowDirection.x, 0) * 0.2f;
            Gizmos.DrawLine(arrowHead, arrowHead - arrowDirection * 0.3f + perpendicular);
            Gizmos.DrawLine(arrowHead, arrowHead - arrowDirection * 0.3f - perpendicular);
        }

        // 绘制目标位置
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere((Vector3)spawnPosition, 0.3f);

        // 如果spawnPosition是本地坐标，需要转换
        if (spawnPosition != Vector2.zero)
        {
            Gizmos.DrawLine(transform.position, spawnPosition);
        }

        // 显示目标场景名称
#if UNITY_EDITOR
        if (!string.IsNullOrEmpty(targetScene))
        {
            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.white;
            style.fontSize = 11;
            UnityEditor.Handles.Label(
                worldCenter + Vector3.up * (worldSize.y * 0.5f + 0.3f),
                $"→ {targetScene}\n延迟: {teleportDelay:F1}s",
                style
            );
        }
#endif
    }

    Vector3 GetDirectionVector()
    {
        switch (allowedDirection)
        {
            case EnterDirection.Left:
                return Vector3.right;
            case EnterDirection.Right:
                return Vector3.left;
            case EnterDirection.Bottom:
                return Vector3.up;
            case EnterDirection.Top:
                return Vector3.down;
            default:
                return Vector3.zero;
        }
    }

    void OnValidate()
    {
        // 确保碰撞体大小有效
        colliderSize.x = Mathf.Max(0.1f, colliderSize.x);
        colliderSize.y = Mathf.Max(0.1f, colliderSize.y);

        // 确保延迟不为负数
        teleportDelay = Mathf.Max(0, teleportDelay);

        // 更新碰撞体（如果在编辑器中）
        if (Application.isEditor && !Application.isPlaying)
        {
            BoxCollider2D col = GetComponent<BoxCollider2D>();
            if (col != null)
            {
                col.offset = colliderOffset;
                col.size = colliderSize;
                col.isTrigger = true;
            }
        }
    }

    // 添加一个可视化调试方法
    void OnGUI()
    {
        if (!showDebug || !Application.isPlaying) return;

        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.white;
        style.fontSize = 12;
        style.padding = new RectOffset(5, 5, 5, 5);

        Vector3 worldCenter = GetColliderWorldCenter();
        Vector3 worldSize = GetColliderWorldSize();

        string info = $"{gameObject.name}\n" +
                     $"世界中心: {worldCenter:F2}\n" +
                     $"世界尺寸: {worldSize:F2}\n" +
                     $"目标场景: {targetScene}\n" +
                     $"状态: {(isTeleporting ? "传送中" : "等待")}";

        Vector3 screenPos = Camera.main.WorldToScreenPoint(worldCenter);

        if (screenPos.z > 0) // 确保在屏幕内
        {
            Rect rect = new Rect(screenPos.x, Screen.height - screenPos.y, 200, 100);
            GUI.Box(rect, info, style);
        }
    }
}