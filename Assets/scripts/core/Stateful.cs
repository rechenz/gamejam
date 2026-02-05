using UnityEngine;

public class StatefulObject : MonoBehaviour
{
    [Header("状态设置")]
    [Tooltip("物体的唯一ID，建议用英文")]
    public string objectId = "door_01";

    [Header("初始状态")]
    public bool initialState = false;
    public string stateName = "isActive";

    void Start()
    {
        // 自动生成ID（如果没设置）
        if (string.IsNullOrEmpty(objectId))
        {
            objectId = gameObject.name + "_" + transform.position.ToString();
        }

        // 加载保存的状态
        LoadObjectState();
    }

    /// <summary>
    /// 保存当前状态
    /// </summary>
    public void SaveState(bool stateValue)
    {
        SimpleStateManager.Instance.SaveBool(objectId, stateName, stateValue);
    }

    /// <summary>
    /// 加载保存的状态
    /// </summary>
    public void LoadObjectState()
    {
        bool savedState = SimpleStateManager.Instance.LoadBool(objectId, stateName, initialState);

        // 应用状态到物体
        ApplyState(savedState);
    }

    /// <summary>
    /// 应用状态到物体（需要根据具体物体重写）
    /// </summary>
    protected virtual void ApplyState(bool state)
    {
        // 基础实现：激活/禁用物体
        gameObject.SetActive(state);

        Debug.Log($"物体 {objectId} 状态已加载: {state}");
    }

    /// <summary>
    /// 改变状态并保存
    /// </summary>
    public void ChangeState(bool newState)
    {
        ApplyState(newState);
        SaveState(newState);
    }

    /// <summary>
    /// 切换状态（开/关）
    /// </summary>
    public void ToggleState()
    {
        bool currentState = SimpleStateManager.Instance.LoadBool(objectId, stateName, initialState);
        ChangeState(!currentState);
    }

    void OnDestroy()
    {
        // 如果需要，可以在这里保存状态
        // 但通常状态改变时就已保存
    }
}