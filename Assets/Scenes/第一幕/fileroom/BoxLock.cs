using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxLock : MonoBehaviour
{
    public GameObject passwordLockPrefab; // 拖入密码锁预制体
    public string doorPassword = "137";
    public bool isInRange;
    private bool inLock = false;
    private GameObject currentLockInstance;

    public string LockBoxID = "LockBox001";

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

    public void Unlock()
    {
        Debug.Log("密码锁已解锁");
        SimpleStateManager.Instance.SaveBool(LockBoxID, "PasswordLock", true);
        Destroy(currentLockInstance);
        this.enabled = false;
    }

    public void useLock()
    {
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

    // Start is called before the first frame update
    void Start()
    {
        if (SimpleStateManager.Instance.LoadBool(LockBoxID, "PasswordLock", false))
        {
            Unlock();
        }
    }

    // Update is called once per frame
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
