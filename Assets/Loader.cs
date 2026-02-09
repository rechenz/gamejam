// CoreInitializer.cs (放在CoreScene中的空GameObject上)
using UnityEngine;
using System.Collections;

public class CoreInitializer : MonoBehaviour
{
    void Awake()
    {
        Debug.Log("CoreScene开始初始化");
        DontDestroyOnLoad(gameObject);
        StartCoroutine(InitializeCoreSystems());
    }

    IEnumerator InitializeCoreSystems()
    {
        // 第一步：确保LoadingScreenManager最先初始化
        if (LoadingScreenManager.Instance == null)
        {
            Debug.LogError("LoadingScreenManager未找到！请确保它在CoreScene中");
            yield break;
        }

        // 等待LoadingScreenManager显示界面
        yield return new WaitForEndOfFrame();

        // 更新加载状态
        LoadingScreenManager.Instance.UpdateProgress(0.2f, "初始化核心系统");

        // 第二步：等待SceneLoader初始化
        while (SceneLoader.Instance == null)
        {
            yield return null;
        }
        LoadingScreenManager.Instance.MarkScriptLoaded("SceneLoader");
        LoadingScreenManager.Instance.UpdateProgress(0.4f, "场景加载器就绪");

        // 第三步：等待SimpleStateManager初始化
        while (SimpleStateManager.Instance == null)
        {
            yield return null;
        }
        LoadingScreenManager.Instance.MarkScriptLoaded("SimpleStateManager");
        LoadingScreenManager.Instance.UpdateProgress(0.6f, "状态管理器就绪");

        // 第四步：等待其他核心系统
        // 可以在这里添加其他需要等待的脚本

        LoadingScreenManager.Instance.UpdateProgress(0.8f, "核心系统初始化完成");

        // 短暂延迟，让玩家看到加载完成
        yield return new WaitForSeconds(0.5f);

        Debug.Log("CoreScene初始化完成");

        // 通知LoadingScreenManager所有核心脚本已加载
        // LoadingScreenManager会自动隐藏界面，当SceneLoader加载完第一个场景后
    }
}