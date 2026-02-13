using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pointView : MonoBehaviour
{
    public bool isInpointView;
    [Header("常规显示列表")]
    public List<SpriteRenderer> pointViewList1 = new List<SpriteRenderer>();
    public List<Behaviour> pointVeiwActive1 = new List<Behaviour>();
    public List<GameObject> pointVeiwAct1 = new List<GameObject>();

    [Header("特殊显示列表")]
    public List<SpriteRenderer> pointViewList2 = new List<SpriteRenderer>();
    public List<Behaviour> pointVeiwActive2 = new List<Behaviour>();
    public List<GameObject> pointVeiwAct2 = new List<GameObject>();

    void Start()
    {
        isInpointView = false;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isInpointView = !isInpointView;
            ChangePointView();
        }
    }

    private void ChangePointView()
    {
        if (isInpointView)
        {
            // 关闭列表1
            SetListActive(pointViewList1, false);
            SetBehaviourListActive(pointVeiwActive1, false);
            SetGameObjectListActive(pointVeiwAct1, false);

            // 开启列表2
            SetListActive(pointViewList2, true);
            SetBehaviourListActive(pointVeiwActive2, true);
            SetGameObjectListActive(pointVeiwAct2, true);
        }
        else
        {
            // 开启列表1
            SetListActive(pointViewList1, true);
            SetBehaviourListActive(pointVeiwActive1, true);
            SetGameObjectListActive(pointVeiwAct1, true);

            // 关闭列表2
            SetListActive(pointViewList2, false);
            SetBehaviourListActive(pointVeiwActive2, false);
            SetGameObjectListActive(pointVeiwAct2, false);
        }
    }

    // ✅ 安全处理 SpriteRenderer 列表
    private void SetListActive(List<SpriteRenderer> list, bool active)
    {
        for (int i = list.Count - 1; i >= 0; i--)  // 从后往前遍历
        {
            if (list[i] == null)
            {
                list.RemoveAt(i);  // 移除空引用
                continue;
            }

            if (list[i] != null && list[i].gameObject != null)
            {
                list[i].enabled = active;
            }
            else
            {
                list.RemoveAt(i);  // 物体已销毁，移除引用
            }
        }
    }

    // ✅ 安全处理 Behaviour 列表（Collider、MonoBehaviour等）
    private void SetBehaviourListActive(List<Behaviour> list, bool active)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == null)
            {
                list.RemoveAt(i);
                continue;
            }

            if (list[i] != null && list[i].gameObject != null)
            {
                list[i].enabled = active;
            }
            else
            {
                list.RemoveAt(i);
            }
        }
    }

    // ✅ 安全处理 GameObject 列表
    private void SetGameObjectListActive(List<GameObject> list, bool active)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == null)
            {
                list.RemoveAt(i);
                continue;
            }

            if (list[i] != null)
            {
                list[i].SetActive(active);
            }
            else
            {
                list.RemoveAt(i);
            }
        }
    }

    // ✅ 可选：在 Inspector 中点击按钮清理空引用
    [ContextMenu("清理空引用")]
    private void CleanNullReferences()
    {
        CleanList(pointViewList1);
        CleanBehaviourList(pointVeiwActive1);
        CleanGameObjectList(pointVeiwAct1);

        CleanList(pointViewList2);
        CleanBehaviourList(pointVeiwActive2);
        CleanGameObjectList(pointVeiwAct2);

        Debug.Log("空引用清理完成！");
    }

    private void CleanList(List<SpriteRenderer> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == null) list.RemoveAt(i);
        }
    }

    private void CleanBehaviourList(List<Behaviour> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == null) list.RemoveAt(i);
        }
    }

    private void CleanGameObjectList(List<GameObject> list)
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if (list[i] == null) list.RemoveAt(i);
        }
    }
}