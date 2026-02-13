using UnityEngine;

public class SimpleStoneTablet : MonoBehaviour
{
    public GameObject canvas;
    public KeyCode interactionKey = KeyCode.F;
    private bool playerInRange = false;

    [Header("提示设置")]
    public bool showDebugMessage = true;
    public string interactionMessage = "按 F 查看石碑";

    void Start()
    {
        if (canvas != null)
            canvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            if (showDebugMessage)
                Debug.Log(interactionMessage);
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (canvas != null)
                canvas.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            ToggleCanvas();
        }
    }

    public void ToggleCanvas()
    {
        if (canvas != null)
        {
            bool shouldActivate = !canvas.activeSelf;
            canvas.SetActive(shouldActivate);

            // 可选：暂停游戏时间
            // Time.timeScale = shouldActivate ? 0 : 1;
        }
    }

    public void ShowCanvas()
    {
        if (canvas != null)
            canvas.SetActive(true);
    }

    public void HideCanvas()
    {
        if (canvas != null)
            canvas.SetActive(false);
    }
}