using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPassword : MonoBehaviour
{
    public GameObject passwordLockPrefab; // 拖入密码锁预制体
    public string doorPassword = "20040101215";
    public bool isInRange;
    private bool inLock = false;
    private GameObject currentLockInstance;
    public Dialogue22 dialogue;
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
        dialogue.StartDialogue();
        Destroy(currentLockInstance);
        currentLockInstance = null;
        this.enabled = false;
    }

    void Start()
    {

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
