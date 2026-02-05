using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class SceneLoader : MonoBehaviour
{
    public static SceneLoader Instance;

    [Header("场景设置")]
    [SerializeField] private string persistentSceneName = "CoreScene";
    [SerializeField] private string firstSceneToLoad = "Home";

    [Header("加载界面")]
    [SerializeField] private GameObject loadingScreen;
    [SerializeField] private UnityEngine.UI.Image progressBar;
    [SerializeField] private UnityEngine.UI.Text progressText;

    private List<string> loadedScenes = new List<string>();
    private AsyncOperation loadingOperation;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);

            // 确保核心场景已加载
            EnsurePersistentScene();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        // 自动加载第一个场景
        if (!string.IsNullOrEmpty(firstSceneToLoad))
        {
            LoadSceneAdditive(firstSceneToLoad);
        }
    }

    void EnsurePersistentScene()
    {
        // 检查核心场景是否已加载
        bool isCoreLoaded = false;
        for (int i = 0; i < SceneManager.sceneCount; i++)
        {
            if (SceneManager.GetSceneAt(i).name == persistentSceneName)
            {
                isCoreLoaded = true;
                break;
            }
        }

        // 如果没加载，加载它
        if (!isCoreLoaded && !string.IsNullOrEmpty(persistentSceneName))
        {
            SceneManager.LoadScene(persistentSceneName, LoadSceneMode.Additive);
        }
    }

    // ========== 场景加载方法 ==========

    // 加载场景（叠加模式，不卸载当前场景）
    public void LoadSceneAdditive(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) || sceneName == persistentSceneName)
            return;

        if (!loadedScenes.Contains(sceneName))
        {
            StartCoroutine(LoadSceneAsyncAdditive(sceneName));
        }
    }

    // 切换场景（卸载其他，加载新场景）
    public void SwitchScene(string sceneName)
    {
        if (string.IsNullOrEmpty(sceneName) || sceneName == persistentSceneName)
            return;

        StartCoroutine(SwitchSceneAsync(sceneName));
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
        }
    }

    // ========== 协程加载 ==========

    private System.Collections.IEnumerator LoadSceneAsyncAdditive(string sceneName)
    {
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        // 开始异步加载
        loadingOperation = SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
        loadingOperation.allowSceneActivation = false;

        // 更新加载界面
        while (!loadingOperation.isDone)
        {
            float progress = Mathf.Clamp01(loadingOperation.progress / 0.9f);

            if (progressBar != null)
                progressBar.fillAmount = progress;

            if (progressText != null)
                progressText.text = $"加载中... {Mathf.Round(progress * 100)}%";

            // 当加载到90%时，等待点击或自动继续
            if (loadingOperation.progress >= 0.9f)
            {
                progressBar.fillAmount = 1f;
                progressText.text = "按任意键继续...";

                if (Input.anyKeyDown)
                {
                    loadingOperation.allowSceneActivation = true;
                }
            }

            yield return null;
        }

        // 加载完成
        loadedScenes.Add(sceneName);

        // 设置新场景为活动场景
        Scene loadedScene = SceneManager.GetSceneByName(sceneName);
        if (loadedScene.IsValid())
        {
            SceneManager.SetActiveScene(loadedScene);
        }

        // 隐藏加载界面
        if (loadingScreen != null)
            loadingScreen.SetActive(false);
    }

    private System.Collections.IEnumerator SwitchSceneAsync(string sceneName)
    {
        // 显示加载界面
        if (loadingScreen != null)
            loadingScreen.SetActive(true);

        // 卸载所有非核心场景
        List<AsyncOperation> unloadOperations = new List<AsyncOperation>();
        foreach (string loadedScene in loadedScenes.ToArray())
        {
            if (loadedScene != persistentSceneName)
            {
                AsyncOperation unloadOp = SceneManager.UnloadSceneAsync(loadedScene);
                unloadOperations.Add(unloadOp);
            }
        }

        // 等待所有卸载完成
        foreach (AsyncOperation op in unloadOperations)
        {
            while (!op.isDone)
                yield return null;
        }

        loadedScenes.Clear();
        loadedScenes.Add(persistentSceneName);

        // 加载新场景
        yield return StartCoroutine(LoadSceneAsyncAdditive(sceneName));
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
}