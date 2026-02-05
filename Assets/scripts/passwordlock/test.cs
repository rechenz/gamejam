using UnityEngine;

public class TestPasswordLock : MonoBehaviour
{
    public SimplePasswordLock passwordLock;

    void Start()
    {
        if (passwordLock != null)
        {
            // 设置密码为 0420
            passwordLock.SetPassword("0420");

            // 监听解锁事件
            passwordLock.OnUnlock += () =>
            {
                Debug.Log("测试：解锁成功！");
            };
        }
    }

    void Update()
    {
        // 按空格键打开锁
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (passwordLock != null && !passwordLock.IsUnlocked())
            {
                passwordLock.OpenLock();
                Debug.Log("测试：打开了密码锁");
            }
        }
    }
}