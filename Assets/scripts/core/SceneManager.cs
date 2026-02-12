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

    private List<string> loadedScenes = new List<string>();
    private bool isLoading = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            string currentScene = SceneManager.GetActiveScene().name;
            Debug.Log($"SceneLoader初始化 - 当前场景: {currentScene}");

            if (currentScene == persistentSceneName)
            {
                Debug.Log("当前已在CoreScene中，直接初始化");
                IsCoreSceneReady = true;
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

        // 直接加载CoreScene，无加载界面
        AsyncOperation loadOp = SceneManager.LoadSceneAsync(persistentSceneName, LoadSceneMode.Single);
        loadOp.allowSceneActivation = true;

        while (!loadOp.isDone)
        {
            yield return null;
        }

        yield return null;

        IsCoreSceneReady = true;
        Debug.Log("CoreScene加载完成");

        yield return StartCoroutine(LoadFirstScene());
    }

    private IEnumerator InitializeAfterCoreScene()
    {
        yield return null;
        yield return WaitForStateManager();
        Debug.Log("CoreScene初始化完成");
        yield return StartCoroutine(LoadFirstScene());
    }

    private IEnumerator WaitForStateManager()
    {
        int maxAttempts = 30;
        int attempts = 0;

        while (SimpleStateManager.Instance == null && attempts < maxAttempts)
        {
            attempts++;
            yield return new WaitForSeconds(0.1f);
        }

        if (SimpleStateManager.Instance == null)
        {
            Debug.LogError("状态管理器初始化失败！");
        }
    }

    private IEnumerator LoadFirstScene()
    {
        if (!string.IsNullOrEmpty(firstSceneToLoad) && firstSceneToLoad != persistentSceneName)
        {
            Debug.Log($"加载第一个场景: {firstSceneToLoad}");
            yield return null;
            yield return StartCoroutine(LoadSceneAsyncAdditive(firstSceneToLoad, true));
        }
    }

    // ========== 场景加载方法 ==========

    public void LoadSceneAdditive(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) || sceneName == persistentSceneName)
            return;

        if (!loadedScenes.Contains(sceneName) && !isLoading)
        {
            StartCoroutine(LoadSceneAsyncAdditive(sceneName));
        }
    }

    public void SwitchScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) || sceneName == persistentSceneName)
            return;

        if (!isLoading)
        {
            StartCoroutine(SwitchSceneAsync(sceneName));
        }
    }

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

        if (!IsCoreSceneReady)
        {
            yield return new WaitUntil(() => IsCoreSceneReady);
        }

        Debug.Log($"开始加载场景: {sceneName}");

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        operation.allowSceneActivation = true; // ✅ 直接激活，不等待输入

        while (!operation.isDone)
        {
            yield return null;
        }

        loadedScenes.Add(sceneName);
        Debug.Log($"场景加载完成: {sceneName}");

        Scene loadedScene = SceneManager.GetSceneByName(sceneName);
        if (loadedScene.IsValid() && setAsActive)
        {
            SceneManager.SetActiveScene(loadedScene);
            Debug.Log($"设置活动场景: {sceneName}");
        }

        isLoading = false;
    }

    private IEnumerator SwitchSceneAsync(string sceneName)
    {
        isLoading = true;
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

        foreach (string sceneToUnload in scenesToUnload)
        {
            Debug.Log($"卸载场景: {sceneToUnload}");
            AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(sceneToUnload);
            if (unloadOp != null)
                unloadOperations.Add(unloadOp);
        }

        foreach (AsyncOperation op in unloadOperations)
        {
            while (!op.isDone)
                yield return null;
        }

        loadedScenes.Clear();
        loadedScenes.Add(persistentSceneName);

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

    public string GetCurrentGameScene()
    {
        Scene activeScene = SceneManager.GetActiveScene();
        if (activeScene.name != persistentSceneName)
        {
            return activeScene.name;
        }
        return string.Empty;
    }

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