using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [System.Serializable]
    public class GameArea
    {
        public float width = 19.2f;
        public float height = 10.7f;
        public Vector2 center = Vector2.zero; // 游戏区域中心位置

        public Bounds GetBounds()
        {
            return new Bounds(new Vector3(center.x, center.y, 0), new Vector3(width, height, 0));
        }

        public float Left => center.x - width / 2;
        public float Right => center.x + width / 2;
        public float Bottom => center.y - height / 2;
        public float Top => center.y + height / 2;
    }

    [Header("游戏区域设置")]
    public GameArea gameArea = new GameArea();
    public bool showGameAreaGizmos = true;
    public Color gameAreaColor = Color.cyan;

    [Header("跟随设置")]
    public Transform target;
    public Vector3 offset = new Vector3(0, 0, -10);
    [Range(0.1f, 20f)]
    public float smoothSpeed = 5f;
    public bool followX = true;
    public bool followY = true;

    [Header("边界限制")]
    public bool clampToGameArea = true;
    [Tooltip("摄像机超出边界时是否停止移动")]
    public bool hardClamp = true;

    private Camera cam;
    private Vector3 currentVelocity;
    private Bounds cameraBounds;

    void Awake()
    {
        cam = GetComponent<Camera>();
        cameraBounds = gameArea.GetBounds();
    }

    void Start()
    {
        // 自动查找主角
        if (target == null)
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
                Debug.Log($"摄像机自动绑定到: {player.name}");
            }
        }

        // 初始化摄像机位置到主角位置
        if (target != null)
        {
            Vector3 startPos = target.position + offset;
            if (clampToGameArea)
            {
                startPos = ClampCameraPosition(startPos);
            }
            transform.position = startPos;
        }
    }

    void LateUpdate()
    {
        if (target == null) return;

        FollowTarget();
    }

    void FollowTarget()
    {
        // 计算目标位置
        Vector3 targetPosition = target.position + offset;

        // 应用轴跟随限制
        if (!followX) targetPosition.x = transform.position.x;
        if (!followY) targetPosition.y = transform.position.y;

        // 平滑移动
        Vector3 newPosition = Vector3.SmoothDamp(
            transform.position,
            targetPosition,
            ref currentVelocity,
            1f / smoothSpeed
        );

        // 应用边界限制
        if (clampToGameArea)
        {
            newPosition = ClampCameraPosition(newPosition);
        }

        transform.position = newPosition;
    }

    Vector3 ClampCameraPosition(Vector3 position)
    {
        // 计算摄像机视口大小
        float cameraHeight = cam.orthographicSize * 2;
        float cameraWidth = cameraHeight * cam.aspect;

        // 计算摄像机边界
        float halfWidth = cameraWidth / 2;
        float halfHeight = cameraHeight / 2;

        // 如果游戏区域小于摄像机视口，将摄像机居中
        if (cameraWidth > gameArea.width)
        {
            position.x = gameArea.center.x;
        }
        else
        {
            float minX = gameArea.Left + halfWidth;
            float maxX = gameArea.Right - halfWidth;
            position.x = Mathf.Clamp(position.x, minX, maxX);
        }

        if (cameraHeight > gameArea.height)
        {
            position.y = gameArea.center.y;
        }
        else
        {
            float minY = gameArea.Bottom + halfHeight;
            float maxY = gameArea.Top - halfHeight;
            position.y = Mathf.Clamp(position.y, minY, maxY);
        }

        return position;
    }

    // 外部调用：设置新的游戏区域
    public void SetGameArea(float width, float height, Vector2? center = null)
    {
        gameArea.width = width;
        gameArea.height = height;
        if (center.HasValue)
            gameArea.center = center.Value;

        cameraBounds = gameArea.GetBounds();
    }

    // 外部调用：设置跟随目标
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        currentVelocity = Vector3.zero;
    }

    // 获取当前摄像机视口的世界边界
    public Bounds GetCameraViewBounds()
    {
        float height = cam.orthographicSize * 2;
        float width = height * cam.aspect;

        return new Bounds(transform.position, new Vector3(width, height, 0));
    }

    // 检查点是否在摄像机视口内
    public bool IsPointInView(Vector3 worldPoint)
    {
        Bounds viewBounds = GetCameraViewBounds();
        return viewBounds.Contains(worldPoint);
    }

    // 摄像机震动效果
    public void Shake(float duration = 0.5f, float intensity = 0.1f)
    {
        StartCoroutine(ShakeCoroutine(duration, intensity));
    }

    private IEnumerator ShakeCoroutine(float duration, float intensity)
    {
        Vector3 originalPos = transform.position;
        float elapsed = 0f;

        while (elapsed < duration)
        {
            Vector3 shakeOffset = Random.insideUnitSphere * intensity;
            shakeOffset.z = 0; // 保持Z轴不变

            transform.position = originalPos + shakeOffset;

            elapsed += Time.deltaTime;
            yield return null;
        }

        transform.position = originalPos;
    }

    #region Gizmos
    void OnDrawGizmos()
    {
        if (!showGameAreaGizmos) return;

        // 绘制游戏区域
        Gizmos.color = gameAreaColor;
        Bounds bounds = gameArea.GetBounds();
        Gizmos.DrawWireCube(bounds.center, bounds.size);

        // 绘制中心点
        Gizmos.color = Color.white;
        Gizmos.DrawSphere(bounds.center, 0.1f);
    }

    void OnDrawGizmosSelected()
    {
        if (cam == null) cam = GetComponent<Camera>();

        // 绘制摄像机当前视口
        Gizmos.color = new Color(1, 1, 0, 0.3f);
        float height = cam.orthographicSize * 2;
        float width = height * cam.aspect;
        Gizmos.DrawCube(transform.position, new Vector3(width, height, 0));

        // 绘制摄像机边界
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(transform.position, new Vector3(width, height, 0));

        // 如果启用了边界限制，显示可移动范围
        if (clampToGameArea)
        {
            float halfWidth = width / 2;
            float halfHeight = height / 2;

            float minX = Mathf.Max(gameArea.Left + halfWidth, gameArea.Left);
            float maxX = Mathf.Min(gameArea.Right - halfWidth, gameArea.Right);
            float minY = Mathf.Max(gameArea.Bottom + halfHeight, gameArea.Bottom);
            float maxY = Mathf.Min(gameArea.Top - halfHeight, gameArea.Top);

            // 确保值有效
            if (maxX > minX && maxY > minY)
            {
                Vector3 center = new Vector3((minX + maxX) / 2, (minY + maxY) / 2, 0);
                Vector3 size = new Vector3(maxX - minX, maxY - minY, 0);

                Gizmos.color = new Color(1, 0, 0, 0.5f);
                Gizmos.DrawWireCube(center, size);
            }
        }
    }
    #endregion
}