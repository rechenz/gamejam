using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LoadingScreenManager : MonoBehaviour
{
    public static LoadingScreenManager Instance;

    [Header("UI组件")]
    [SerializeField] private CanvasGroup loadingScreen;
    [SerializeField] private Slider progressSlider;
    [SerializeField] private Text progressText;
    [SerializeField] private Text tipText;
    [SerializeField] private Image backgroundImage;
    [SerializeField] private GameObject loadingIcon;

    [Header("设置")]
    [SerializeField] private float fadeDuration = 0.5f;
    [SerializeField] private float minLoadingTime = 2.0f; // 最小加载时间（避免闪屏）
    [SerializeField] private bool showTips = true;

    [Header("加载提示")]
    [SerializeField]
    private string[] loadingTips = {
        "正在初始化游戏系统...",
        "加载场景资源...",
        "准备游戏对象...",
        "初始化脚本组件...",
        "请稍候..."
    };

    [Header("必须加载的脚本")]
    [SerializeField]
    private string[] requiredScripts = {
        "SimpleStateManager",
        "SceneLoader"
    };

    private List<string> loadedScripts = new List<string>();
    private float loadingStartTime;
    private bool isLoading = false;
    private Coroutine loadingCoroutine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            InitializeLoadingScreen();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void InitializeLoadingScreen()
    {
        if (loadingScreen != null)
        {
            loadingScreen.alpha = 0f;
            loadingScreen.gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 显示加载界面并等待所有脚本初始化
    /// </summary>
    public void ShowLoadingScreen(string loadingMessage = "加载中...")
    {
        if (isLoading) return;

        isLoading = true;
        loadingStartTime = Time.time;
        loadedScripts.Clear();

        if (loadingScreen != null)
        {
            loadingScreen.gameObject.SetActive(true);
            loadingCoroutine = StartCoroutine(FadeLoadingScreen(0f, 1f, fadeDuration));
        }

        // 开始检查脚本加载状态
        StartCoroutine(WaitForScriptsInitialization(loadingMessage));

        // 开始显示加载图标动画
        if (loadingIcon != null)
        {
            StartCoroutine(RotateLoadingIcon());
        }

        // 随机显示提示
        if (showTips && tipText != null && loadingTips.Length > 0)
        {
            int randomIndex = Random.Range(0, loadingTips.Length);
            tipText.text = loadingTips[randomIndex];
        }
    }

    /// <summary>
    /// 隐藏加载界面
    /// </summary>
    public void HideLoadingScreen()
    {
        if (!isLoading) return;

        if (loadingCoroutine != null)
        {
            StopCoroutine(loadingCoroutine);
        }

        StartCoroutine(CompleteLoading());
    }

    /// <summary>
    /// 更新加载进度
    /// </summary>
    public void UpdateProgress(float progress, string message = "")
    {
        if (!isLoading) return;

        // 确保至少显示最小时间
        float elapsedTime = Time.time - loadingStartTime;
        float timeProgress = Mathf.Clamp01(elapsedTime / minLoadingTime);

        // 结合时间进度和实际进度
        float displayProgress = Mathf.Lerp(timeProgress, progress, 0.7f);

        if (progressSlider != null)
        {
            progressSlider.value = displayProgress;
        }

        if (progressText != null)
        {
            if (!string.IsNullOrEmpty(message))
            {
                progressText.text = $"{message} {Mathf.Round(displayProgress * 100)}%";
            }
            else
            {
                progressText.text = $"{Mathf.Round(displayProgress * 100)}%";
            }
        }
    }

    /// <summary>
    /// 标记脚本已加载
    /// </summary>
    public void MarkScriptLoaded(string scriptName)
    {
        if (!loadedScripts.Contains(scriptName))
        {
            loadedScripts.Add(scriptName);
            UpdateLoadingStatus();
        }
    }

    /// <summary>
    /// 检查是否所有必需脚本都已加载
    /// </summary>
    public bool AreAllScriptsLoaded()
    {
        foreach (string script in requiredScripts)
        {
            if (!loadedScripts.Contains(script))
            {
                return false;
            }
        }
        return true;
    }

    private IEnumerator WaitForScriptsInitialization(string loadingMessage)
    {
        float totalProgress = 0f;
        int totalScripts = requiredScripts.Length;

        while (!AreAllScriptsLoaded())
        {
            // 计算已加载的脚本比例
            int loadedCount = loadedScripts.Count;
            float scriptProgress = (float)loadedCount / totalScripts;

            // 增加一些随机进度，让加载看起来更自然
            float randomFactor = 0.1f * Mathf.Sin(Time.time * 2f);
            totalProgress = Mathf.Clamp01(scriptProgress + randomFactor);

            // 更新进度显示
            UpdateProgress(totalProgress, loadingMessage);

            // 如果长时间没加载完，显示具体信息
            if (Time.time - loadingStartTime > 5f)
            {
                string missingScripts = "";
                foreach (string script in requiredScripts)
                {
                    if (!loadedScripts.Contains(script))
                    {
                        missingScripts += script + ", ";
                    }
                }

                if (progressText != null && !string.IsNullOrEmpty(missingScripts))
                {
                    progressText.text = $"等待脚本: {missingScripts.TrimEnd(',', ' ')}";
                }
            }

            yield return null;
        }

        // 所有脚本已加载，等待最小加载时间
        while (Time.time - loadingStartTime < minLoadingTime)
        {
            float timeProgress = Mathf.Clamp01((Time.time - loadingStartTime) / minLoadingTime);
            UpdateProgress(timeProgress, "准备进入游戏...");
            yield return null;
        }

        // 完成加载
        UpdateProgress(1f, "加载完成！");
        yield return new WaitForSeconds(0.5f);

        HideLoadingScreen();
    }

    private IEnumerator CompleteLoading()
    {
        // 淡出加载界面
        yield return StartCoroutine(FadeLoadingScreen(1f, 0f, fadeDuration));

        if (loadingScreen != null)
        {
            loadingScreen.gameObject.SetActive(false);
        }

        isLoading = false;

        Debug.Log("所有必需脚本已加载完成，进入游戏");
    }

    private IEnumerator FadeLoadingScreen(float fromAlpha, float toAlpha, float duration)
    {
        float elapsed = 0f;

        while (elapsed < duration)
        {
            elapsed += Time.deltaTime;
            float t = Mathf.Clamp01(elapsed / duration);

            if (loadingScreen != null)
            {
                loadingScreen.alpha = Mathf.Lerp(fromAlpha, toAlpha, t);
            }

            yield return null;
        }

        if (loadingScreen != null)
        {
            loadingScreen.alpha = toAlpha;
        }
    }

    private IEnumerator RotateLoadingIcon()
    {
        while (isLoading)
        {
            if (loadingIcon != null)
            {
                loadingIcon.transform.Rotate(0f, 0f, -180f * Time.deltaTime);
            }
            yield return null;
        }
    }

    private void UpdateLoadingStatus()
    {
        string status = $"已加载脚本: {loadedScripts.Count}/{requiredScripts.Length}\n";
        foreach (string script in loadedScripts)
        {
            status += $"✓ {script}\n";
        }

        // 可选：在调试时显示状态
        Debug.Log(status);
    }

    /// <summary>
    /// 检查游戏是否正在加载中
    /// </summary>
    public bool IsLoading()
    {
        return isLoading;
    }

    /// <summary>
    /// 获取加载进度
    /// </summary>
    public float GetProgress()
    {
        if (progressSlider != null)
        {
            return progressSlider.value;
        }
        return 0f;
    }
}