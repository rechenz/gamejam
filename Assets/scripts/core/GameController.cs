using UnityEngine;
using System.Collections.Generic;

public class SimpleStateManager : MonoBehaviour
{
    public static SimpleStateManager Instance;

    // 存储所有物体状态：物体ID -> 状态字典
    private Dictionary<string, Dictionary<string, object>> objectStates =
        new Dictionary<string, Dictionary<string, object>>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            Debug.Log("SimpleStateManager已初始化");

            // 标记脚本已加载
            if (LoadingScreenManager.Instance != null)
            {
                LoadingScreenManager.Instance.MarkScriptLoaded("SimpleStateManager");
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        Debug.Log("SimpleStateManager完全就绪");
    }

    private System.Collections.IEnumerator NotifyReady()
    {
        // 等待一帧确保完全初始化
        yield return null;
        Debug.Log("SimpleStateManager完全就绪");
    }

    // ========== 基础状态操作 ==========

    /// <summary>
    /// 保存一个物体的状态
    /// </summary>
    /// <param name="objectId">物体唯一ID</param>
    /// <param name="stateName">状态名称（如："isOpened", "isActive"）</param>
    /// <param name="value">状态值</param>
    public void SaveState(string objectId, string stateName, object value)
    {
        if (!objectStates.ContainsKey(objectId))
        {
            objectStates[objectId] = new Dictionary<string, object>();
        }

        objectStates[objectId][stateName] = value;
        Debug.Log($"已保存状态: {objectId}.{stateName} = {value}");
    }

    /// <summary>
    /// 读取一个物体的状态
    /// </summary>
    public object LoadState(string objectId, string stateName)
    {
        if (objectStates.ContainsKey(objectId) &&
            objectStates[objectId].ContainsKey(stateName))
        {
            return objectStates[objectId][stateName];
        }
        return null;
    }

    /// <summary>
    /// 读取状态（带默认值）
    /// </summary>
    public T LoadState<T>(string objectId, string stateName, T defaultValue = default)
    {
        object value = LoadState(objectId, stateName);

        if (value != null && value is T)
        {
            return (T)value;
        }

        return defaultValue;
    }

    /// <summary>
    /// 检查是否有某个状态
    /// </summary>
    public bool HasState(string objectId, string stateName)
    {
        return objectStates.ContainsKey(objectId) &&
               objectStates[objectId].ContainsKey(stateName);
    }

    // ========== 常用状态快捷方法 ==========

    // 布尔状态（用于门、宝箱、开关等）
    public void SaveBool(string objectId, string stateName, bool value)
    {
        SaveState(objectId, stateName, value);
    }

    public bool LoadBool(string objectId, string stateName, bool defaultValue = false)
    {
        return LoadState<bool>(objectId, stateName, defaultValue);
    }

    // 整数状态（用于血量、数量、次数等）
    public void SaveInt(string objectId, string stateName, int value)
    {
        SaveState(objectId, stateName, value);
    }

    public int LoadInt(string objectId, string stateName, int defaultValue = 0)
    {
        return LoadState<int>(objectId, stateName, defaultValue);
    }

    // 字符串状态（用于密码、对话ID等）
    public void SaveString(string objectId, string stateName, string value)
    {
        SaveState(objectId, stateName, value);
    }

    public string LoadString(string objectId, string stateName, string defaultValue = "")
    {
        return LoadState<string>(objectId, stateName, defaultValue);
    }

    // ========== 存档/读档 ==========

    /// <summary>
    /// 保存所有状态到PlayerPrefs
    /// </summary>
    public void SaveToFile()
    {
        // 转换为JSON字符串
        string json = JsonUtility.ToJson(new SerializableStateData(objectStates));
        PlayerPrefs.SetString("GameState", json);
        PlayerPrefs.Save();

        Debug.Log("游戏状态已保存到文件");
    }

    /// <summary>
    /// 从PlayerPrefs加载状态
    /// </summary>
    public void LoadFromFile()
    {
        if (PlayerPrefs.HasKey("GameState"))
        {
            string json = PlayerPrefs.GetString("GameState");
            SerializableStateData data = JsonUtility.FromJson<SerializableStateData>(json);

            // 转换回字典
            objectStates = data.ToDictionary();

            Debug.Log("游戏状态已从文件加载");
        }
        else
        {
            Debug.Log("没有找到存档文件");
        }
    }

    /// <summary>
    /// 删除存档
    /// </summary>
    public void DeleteSave()
    {
        PlayerPrefs.DeleteKey("GameState");
        objectStates.Clear();
        Debug.Log("存档已删除");
    }

    /// <summary>
    /// 清空所有状态（不删除存档文件）
    /// </summary>
    public void ClearStates()
    {
        objectStates.Clear();
        Debug.Log("内存中的状态已清空");
    }

    /// <summary>
    /// 打印所有保存的状态（调试用）
    /// </summary>
    public void PrintAllStates()
    {
        Debug.Log("=== 所有保存的状态 ===");

        if (objectStates.Count == 0)
        {
            Debug.Log("（无状态）");
            return;
        }

        foreach (var objectPair in objectStates)
        {
            string objectId = objectPair.Key;
            Dictionary<string, object> states = objectPair.Value;

            Debug.Log($"物体: {objectId}");

            foreach (var statePair in states)
            {
                Debug.Log($"  {statePair.Key}: {statePair.Value}");
            }
        }
    }
}

// 辅助类：用于JSON序列化
[System.Serializable]
public class SerializableStateData
{
    [System.Serializable]
    public class StateEntry
    {
        public string key;
        public string value;
        public string type;
    }

    [System.Serializable]
    public class ObjectState
    {
        public string objectId;
        public List<StateEntry> states = new List<StateEntry>();
    }

    public List<ObjectState> objectStates = new List<ObjectState>();

    public SerializableStateData(Dictionary<string, Dictionary<string, object>> original)
    {
        foreach (var objectPair in original)
        {
            ObjectState objState = new ObjectState();
            objState.objectId = objectPair.Key;

            foreach (var statePair in objectPair.Value)
            {
                StateEntry entry = new StateEntry
                {
                    key = statePair.Key,
                    value = statePair.Value.ToString(),
                    type = statePair.Value.GetType().ToString()
                };
                objState.states.Add(entry);
            }

            objectStates.Add(objState);
        }
    }

    public Dictionary<string, Dictionary<string, object>> ToDictionary()
    {
        Dictionary<string, Dictionary<string, object>> result =
            new Dictionary<string, Dictionary<string, object>>();

        foreach (ObjectState objState in objectStates)
        {
            Dictionary<string, object> states = new Dictionary<string, object>();

            foreach (StateEntry entry in objState.states)
            {
                // 根据类型转换值（简化版）
                object value = entry.value;
                if (entry.type.Contains("Boolean"))
                {
                    value = bool.Parse(entry.value);
                }
                else if (entry.type.Contains("Int32"))
                {
                    value = int.Parse(entry.value);
                }
                else if (entry.type.Contains("Single")) // float
                {
                    value = float.Parse(entry.value);
                }

                states[entry.key] = value;
            }

            result[objState.objectId] = states;
        }

        return result;
    }
}