using UnityEngine;

public class SimpleLockedDoor : MonoBehaviour
{
    public GameObject passwordLockPrefab; // 拖入密码锁预制体
    public string doorPassword = "513";
    public bool isInRange;
    private bool inLock = false;
    public DoorTeleporter doorTeleporter;
    private GameObject currentLockInstance;

    public GameObject Background1;
    public GameObject Background2;
    private SpriteRenderer Background1Sprite;
    private SpriteRenderer Background2Sprite;

    public string LockDoorID = "LockDoor_001";
    public Behaviour dialogue9;
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
        currentLockInstance = Instantiate(passwordLockPrefab);
        SimplePasswordLock lockScript = currentLockInstance.GetComponent<SimplePasswordLock>();

        // 2. 设置密码
        lockScript.SetPassword(doorPassword);

        // 3. 打开锁
        lockScript.OpenLock();

        // 4. 监听解锁事件
        lockScript.OnUnlock += () =>
        {
            Debug.Log("门已解锁！");
            Unlock();
        };
    }

    void Unlock()
    {
        doorTeleporter.enabled = true;
        Background1Sprite.enabled = false;
        Background2Sprite.enabled = true;
        Destroy(currentLockInstance);
        currentLockInstance = null;
        SimpleStateManager.Instance.SaveBool(LockDoorID, "isOpen", true);
        dialogue9.enabled = true;
        this.enabled = false;
    }

    void Start()
    {
        doorTeleporter = GetComponent<DoorTeleporter>();
        doorTeleporter.enabled = false;
        Background1Sprite = Background1.GetComponent<SpriteRenderer>();
        Background2Sprite = Background2.GetComponent<SpriteRenderer>();
        bool isOpen = SimpleStateManager.Instance.LoadBool(LockDoorID, "isOpen", false);
        if (isOpen)
        {
            Unlock();
        }
    }

    void Update()
    {
        if (!inLock && Input.GetKeyDown(KeyCode.F) && isInRange)
        {
            useLock();
            inLock = true;
        }
        if (inLock && Input.GetKeyDown(KeyCode.Escape))
        {
            inLock = false;
            if (currentLockInstance != null)
            {
                Destroy(currentLockInstance);
                currentLockInstance = null;
            }
        }
    }
}