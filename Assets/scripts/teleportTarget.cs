using UnityEngine;

public class DoorSpawnPoint : MonoBehaviour
{
    [Header("重生设置")]
    public bool useDoorSpawnPosition = true;
    public Vector2 defaultPosition = Vector2.zero;

    void Start()
    {
        // 稍等一帧，确保场景完全加载
        Invoke(nameof(SpawnPlayerAtDoorPosition), 0.1f);
    }

    void SpawnPlayerAtDoorPosition()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player == null)
        {
            Debug.LogWarning("DoorSpawnPoint: 未找到玩家物体");
            return;
        }

        Vector2 spawnPos = useDoorSpawnPosition ?
            DoorTeleporter.GetDoorSpawnPosition() :
            (Vector2)transform.position + defaultPosition;

        // 如果从门传送来的位置为0，使用默认位置
        if (spawnPos == Vector2.zero)
        {
            spawnPos = (Vector2)transform.position + defaultPosition;
        }

        player.transform.position = spawnPos;
        Debug.Log($"玩家在位置 {spawnPos} 重生");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position + (Vector3)defaultPosition, 0.3f);

#if UNITY_EDITOR
        GUIStyle style = new GUIStyle();
        style.normal.textColor = Color.green;
        UnityEditor.Handles.Label(
            transform.position + Vector3.up * 0.5f,
            "门重生点",
            style
        );
#endif
    }
}