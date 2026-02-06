using UnityEngine;

public class SimpleLockedDoor : MonoBehaviour
{
    public GameObject passwordLockPrefab; // 拖入密码锁预制体
    public string doorPassword = "1111";
    public bool isInRange;
    private bool inLock = false;
    public DoorTeleporter doorTeleporter;
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("在密码锁范围内");
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    void useLock()
    {
        // 1. 创建密码锁
        GameObject lockInstance = Instantiate(passwordLockPrefab);
        SimplePasswordLock lockScript = lockInstance.GetComponent<SimplePasswordLock>();

        // 2. 设置密码
        lockScript.SetPassword(doorPassword);

        // 3. 打开锁
        lockScript.OpenLock();

        // 4. 监听解锁事件
        lockScript.OnUnlock += () =>
        {
            Debug.Log("门已解锁！");
            doorTeleporter.enabled = true;
            this.enabled = false;
            Destroy(lockInstance);
        };
    }

    void Start()
    {
        doorTeleporter = GetComponent<DoorTeleporter>();
        doorTeleporter.enabled = false;
    }

    void Update()
    {
        if (!inLock && Input.GetKeyDown(KeyCode.F) && isInRange)
        {
            useLock();
            inLock = true;
        }
    }
}