// EdgeGlow2D_Fixed.cs - 修复版本
using UnityEngine;

public class EdgeGlow2D_Fixed : MonoBehaviour
{
    [Header("外观设置")]
    public Color glowColor = new Color(0, 1, 1, 0.5f);
    public float pulseSpeed = 1.5f;
    public float minAlpha = 0.3f;
    public float maxAlpha = 0.8f;

    [Header("边缘设置")]
    public float edgeLength = 5f;
    public float edgeThickness = 0.1f;

    [Header("方向设置")]
    public bool isHorizontal = true; // 是否为水平边缘
    public float rotationAngle = 0f; // 自定义旋转角度

    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        // 设置渲染顺序
        spriteRenderer.sortingLayerName = "Effects";
        spriteRenderer.sortingOrder = 5;

        // 初始颜色
        spriteRenderer.color = glowColor;

        // 重置旋转，确保正确朝向
        ResetTransform();

        // 调整大小
        ApplyEdgeSize();
    }

    void ResetTransform()
    {
        // 确保没有奇怪的旋转
        transform.rotation = Quaternion.identity;

        // 如果需要水平放置，旋转90度
        if (isHorizontal)
        {
            // 水平边缘（X轴方向）
            transform.rotation = Quaternion.Euler(0, 0, 90f);
        }
        else
        {
            // 垂直边缘（Y轴方向）
            transform.rotation = Quaternion.Euler(0, 0, 0f);
        }

        // 应用自定义旋转
        if (rotationAngle != 0f)
        {
            transform.rotation *= Quaternion.Euler(0, 0, rotationAngle);
        }
    }

    void ApplyEdgeSize()
    {
        if (isHorizontal)
        {
            // 水平边缘：长边在X轴，厚边在Y轴
            transform.localScale = new Vector3(edgeThickness, edgeLength, 1);
        }
        else
        {
            // 垂直边缘：长边在Y轴，厚边在X轴
            transform.localScale = new Vector3(edgeLength, edgeThickness, 1);
        }
    }

    void Update()
    {
        // 呼吸效果
        float pulse = Mathf.PingPong(Time.time * pulseSpeed, 1f);
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, pulse);

        Color color = glowColor;
        color.a = alpha;
        spriteRenderer.color = color;
    }

    // 编辑器工具：重新对齐
    [ContextMenu("重新对齐边缘")]
    void RealignEdge()
    {
        ResetTransform();
        ApplyEdgeSize();
    }

    // 设置边缘方向
    public void SetEdgeOrientation(bool horizontal, float length, float thickness)
    {
        isHorizontal = horizontal;
        edgeLength = length;
        edgeThickness = thickness;

        ResetTransform();
        ApplyEdgeSize();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = glowColor;
        Gizmos.matrix = Matrix4x4.TRS(transform.position, transform.rotation, Vector3.one);
        Gizmos.DrawWireCube(Vector3.zero, transform.localScale);
    }
}