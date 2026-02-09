using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;
    public static bool IsCoreSceneReady { get; private set; } = false;

    [Header("场景设置")]
    [SerializeField] private string persistentSceneName = "CoreScene";
    [SerializeField] private string firstSceneToLoad = "Home";

    [Header("加载界面")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private UnityEngine.UI.Image progressBar;
    [SerializeField] private UnityEngine.UI.Text progressText;

    private List<string> loadedScenes = new List<string>();
    private AsyncOperation loadingOperation;
    private bool isLoading = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 获取当前场景名
            string currentScene = SceneManager.GetActiveScene().name;
            Debug.Log($"SceneLoader初始化 - 当前场景: {currentScene}");

            // 检查是否是第一次启动
            if (currentScene == persistentSceneName)
            {
                Debug.Log("当前已在CoreScene中，直接初始化");
                IsCoreSceneReady = true;

                // 延迟一帧初始化，确保所有Awake都执行完毕
                StartCoroutine(InitializeAfterCoreScene());
            }
            else
            {
                Debug.Log($"当前在 {currentScene}，需要加载CoreScene");
                StartCoroutine(LoadCoreSceneFirst());
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private IEnumerator LoadCoreSceneFirst()
    {
        Debug.Log("第一步：加载CoreScene");

        // 显示加载界面
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        // 加载CoreScene（单例模式，卸载当前场景）
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(persistentSceneName, LoadSceneMode.Single);
        loadOp.allowSceneActivation = true;

        // 更新加载进度
        while (!loadOp.isDone)
        {
            if (progressBar != null)
                progressBar.fillAmount = loadOp.progress;

            if (progressText != null)
                progressText.text = $"加载核心系统... {Mathf.Round(loadOp.progress * 100)}%";

            yield return null;
        }

        // 等待一帧让CoreScene中的组件初始化
        yield return null;

        IsCoreSceneReady = true;
        Debug.Log("CoreScene加载完成");

        // 然后加载第一个游戏场景
        yield return StartCoroutine(LoadFirstScene());
    }

    private IEnumerator InitializeAfterCoreScene()
    {
        // 等待一帧确保所有Awake执行完毕
        yield return null;

        // 等待SimpleStateManager初始化
        yield return WaitForStateManager();

        Debug.Log("CoreScene初始化完成");

        // 然后加载第一个游戏场景
        yield return StartCoroutine(LoadFirstScene());
    }

    private IEnumerator WaitForStateManager()
    {
        int maxAttempts = 30;
        int attempts = 0;

        while (SimpleStateManager.Instance == null && attempts < maxAttempts)
        {
            attempts++;
            Debug.Log($"等待状态管理器初始化... ({attempts}/{maxAttempts})");
            yield return new WaitForSeconds(0.1f);
        }

        if (SimpleStateManager.Instance == null)
        {
            Debug.LogError("状态管理器初始化失败！");
        }
        else
        {
            Debug.Log("状态管理器已找到");
        }
    }

    private IEnumerator LoadFirstScene()
    {
        if (!string.IsNullOrEmpty(firstSceneToLoad) && firstSceneToLoad != persistentSceneName)
        {
            Debug.Log($"加载第一个场景: {firstSceneToLoad}");

            // 等待一帧，确保SceneLoader完全初始化
            yield return null;

            // 加载第一个场景
            yield return StartCoroutine(LoadSceneAsyncAdditive(firstSceneToLoad, true));

            // 隐藏加载界面
            if (loadingScreen != null)
                loadingScreen.SetActive(false);
        }
    }

    // ========== 场景加载方法 ==========

    // 加载场景（叠加模式，不卸载当前场景）
    public void LoadSceneAdditive(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) || sceneName == persistentSceneName)
            return;

        if (!loadedScenes.Contains(sceneName) && !isLoading)
        {
            StartCoroutine(LoadSceneAsyncAdditive(sceneName));
        }
    }

    // 切换场景（卸载其他，加载新场景）
    public void SwitchScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) || sceneName == persistentSceneName)
            return;

        if (!isLoading)
        {
            StartCoroutine(SwitchSceneAsync(sceneName));
        }
    }

    // 卸载场景
    public void UnloadScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) || sceneName == persistentSceneName)
            return;

        if (loadedScenes.Contains(sceneName))
        {
            SceneManager.UnloadSceneAsync(sceneName);
            loadedScenes.Remove(sceneName);
            Debug.Log($"已卸载场景: {sceneName}");
        }
    }

    // ========== 协程加载 ==========

    private IEnumerator LoadSceneAsyncAdditive(string sceneName, bool setAsActive = false)
    {
        isLoading = true;

        // 等待CoreScene准备就绪
        if (!IsCoreSceneReady)
        {
            Debug.Log($"等待CoreScene准备就绪...");
            yield return new WaitUntil(() => IsCoreSceneReady);
        }

        Debug.Log($"开始加载场景: {sceneName}");

        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        // 开始异步加载
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        operation.allowSceneActivation = false;

        // 更新加载界面
        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            if (progressBar != null)
                progressBar.fillAmount = progress;

            if (progressText != null)
                progressText.text = $"加载 {sceneName}... {Mathf.Round(progress * 100)}%";

            // 当加载到90%时，等待点击或自动继续
            if (operation.progress >= 0.9f)
            {
                if (progressBar != null)
                    progressBar.fillAmount = 1f;

                if (progressText != null)
                    progressText.text = "按任意键继续...";

                if (Input.anyKeyDown)
                {
                    operation.allowSceneActivation = true;
                }
            }

            yield return null;
        }

        // 加载完成
        loadedScenes.Add(sceneName);
        Debug.Log($"场景加载完成: {sceneName}");

        // 设置新场景为活动场景
        Scene loadedScene = SceneManager.GetSceneByName(sceneName);
        if (loadedScene.IsValid() && setAsActive)
        {
            SceneManager.SetActiveScene(loadedScene);
            Debug.Log($"设置活动场景: {sceneName}");
        }

        // 隐藏加载界面
        if (loadingScreen != null)
            loadingScreen.SetActive(false);

        isLoading = false;
    }

    private IEnumerator SwitchSceneAsync(string sceneName)
    {
        isLoading = true;

        // 显示加载界面
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        Debug.Log($"切换场景到: {sceneName}");

        // 卸载所有非核心场景
        List<AsyncOperation> unloadOperations = new List<AsyncOperation>();
        List<string> scenesToUnload = new List<string>();

        foreach (string loadedScene in loadedScenes.ToArray())
        {
            if (loadedScene != persistentSceneName)
            {
                scenesToUnload.Add(loadedScene);
            }
        }

        // 批量卸载场景
        foreach (string sceneToUnload in scenesToUnload)
        {
            Debug.Log($"卸载场景: {sceneToUnload}");
            AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(sceneToUnload);
            unloadOperations.Add(unloadOp);
        }

        // 等待所有卸载完成
        foreach (AsyncOperation op in unloadOperations)
        {
            while (!op.isDone)
                yield return null;
        }

        // 清理已加载场景列表
        loadedScenes.Clear();
        loadedScenes.Add(persistentSceneName);

        // 加载新场景
        yield return StartCoroutine(LoadSceneAsyncAdditive(sceneName, true));

        isLoading = false;
    }

    // ========== 工具方法 ==========

    public bool IsSceneLoaded(string sceneName)
    {
        return loadedScenes.Contains(sceneName);
    }

    public List<string> GetLoadedScenes()
    {
        return new List<string>(loadedScenes);
    }

    public void ReloadCurrentScene()
    {
        Scene currentScene = SceneManager.GetActiveScene();
        if (currentScene.name != persistentSceneName)
        {
            SwitchScene(currentScene.name);
        }
    }

    // 获取当前活动场景（非CoreScene）
    public string GetCurrentGameScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name != persistentSceneName)
        {
            return activeScene.name;
        }
        return string.Empty;
    }

    // 强制设置活动场景
    public void SetActiveScene(string sceneName)
    {
        Scene scene = SceneManager.GetSceneByName(sceneName);
        if (scene.IsValid())
        {
            SceneManager.SetActiveScene(scene);
            Debug.Log($"已设置活动场景: {sceneName}");
        }
    }
}