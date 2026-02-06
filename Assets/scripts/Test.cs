using UnityEngine;

public class PasswordLockDebugger : MonoBehaviour
{
    void Update()
    {
        // 测试快捷键
        if (Input.GetKeyDown(KeyCode.F1))
        {
            TestPasswordLock();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            if (PasswordLockManager.Instance != null)
            {
                bool isShowing = PasswordLockManager.Instance.IsLockShowing();
                Debug.Log($"密码锁是否显示: {isShowing}");
            }
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            PasswordLockManager.Close();
            Debug.Log("强制关闭密码锁");
        }
    }

    void TestPasswordLock()
    {
        Debug.Log("=== 测试密码锁 ===");

        // 测试正确密码
        PasswordLockManager.Show("1111", () =>
        {
            Debug.Log("✅ 测试成功！");
        });

        // 测试错误密码
        // PasswordLockManager.Show("9999", () => {
        //     Debug.Log("❌ 这行不应该执行");
        // });
    }

    [ContextMenu("检查管理器状态")]
    void CheckManagerStatus()
    {
        if (PasswordLockManager.Instance == null)
        {
            Debug.LogError("❌ PasswordLockManager 实例为null！");
            Debug.Log("请确保场景中有PasswordLockManager对象");
        }
        else
        {
            Debug.Log("✅ PasswordLockManager 实例存在");

            // 检查预制体
            var manager = PasswordLockManager.Instance;
            if (manager.passwordLockPrefab == null)
            {
                Debug.LogError("❌ 密码锁预制体未设置！");
            }
            else
            {
                Debug.Log("✅ 密码锁预制体已设置");
            }
        }
    }
}