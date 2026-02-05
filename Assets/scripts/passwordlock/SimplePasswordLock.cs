using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class SimplePasswordLock : MonoBehaviour
{
    [Header("密码设置")]
    [SerializeField] private string correctPassword = "1234";  // 正确密码
    [SerializeField] private int passwordLength = 4;           // 密码位数
    [SerializeField] private bool hidePassword = true;         // 是否隐藏输入

    [Header("UI引用")]
    [SerializeField] private GameObject lockPanel;             // 密码面板
    [SerializeField] private TMP_Text displayText;                // 显示输入
    [SerializeField] private TMP_Text statusText;                 // 状态提示
    [SerializeField] private Button[] numberButtons;          // 0-9数字按钮
    [SerializeField] private Button confirmButton;            // 确认按钮
    [SerializeField] private Button clearButton;              // 清除按钮

    [Header("解锁后")]
    [SerializeField] private GameObject[] unlockObjects;      // 解锁后显示
    [SerializeField] private GameObject[] lockObjects;        // 解锁后隐藏

    [Header("音效")]
    [SerializeField] private AudioClip buttonSound;
    [SerializeField] private AudioClip correctSound;
    [SerializeField] private AudioClip wrongSound;

    // 私有变量
    private string currentInput = "";
    private bool isUnlocked = false;
    private AudioSource audioSource;

    void Start()
    {
        // 初始化AudioSource
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
            audioSource = gameObject.AddComponent<AudioSource>();

        // 初始隐藏面板
        if (lockPanel != null)
            lockPanel.SetActive(false);

        // 设置按钮事件
        SetupButtons();

        // 更新状态显示
        UpdateStatus("请输入" + passwordLength + "位密码");
    }

    void SetupButtons()
    {
        // 设置数字按钮
        for (int i = 0; i < numberButtons.Length; i++)
        {
            int number = i; // 闭包需要局部变量
            numberButtons[i].onClick.AddListener(() => AddNumber(number));

            // 设置按钮文本
            TMP_Text btnText = numberButtons[i].GetComponentInChildren<TMP_Text>();
            if (btnText != null)
                btnText.text = i.ToString();
        }

        // 设置功能按钮
        if (confirmButton != null)
            confirmButton.onClick.AddListener(CheckPassword);

        if (clearButton != null)
            clearButton.onClick.AddListener(ClearInput);
    }

    // ========== 密码输入 ==========

    void AddNumber(int number)
    {
        if (isUnlocked || currentInput.Length >= passwordLength)
            return;

        currentInput += number.ToString();
        UpdateDisplay();
        PlaySound(buttonSound);

        // 如果输满了，自动检查
        if (currentInput.Length == passwordLength)
        {
            CheckPassword();
        }
    }

    void ClearInput()
    {
        currentInput = "";
        UpdateDisplay();
        PlaySound(buttonSound);
    }

    // ========== 密码验证 ==========

    void CheckPassword()
    {
        if (currentInput.Length != passwordLength)
        {
            UpdateStatus("请输入" + passwordLength + "位密码");
            return;
        }

        if (currentInput == correctPassword)
        {
            OnCorrectPassword();
        }
        else
        {
            OnWrongPassword();
        }
    }

    void OnCorrectPassword()
    {
        isUnlocked = true;
        PlaySound(correctSound);

        // 显示成功
        UpdateStatus("<color=green>✓ 解锁成功！</color>");
        UpdateDisplay();

        // 解锁效果
        StartCoroutine(SuccessEffect());

        // 执行解锁操作
        UnlockAction();

        // 3秒后关闭面板
        Invoke("CloseLock", 3f);
    }

    void OnWrongPassword()
    {
        PlaySound(wrongSound);

        // 显示错误
        UpdateStatus("<color=red>✗ 密码错误</color>");

        // 闪烁效果
        StartCoroutine(WrongEffect());

        // 2秒后清空重试
        Invoke("ClearInput", 2f);
    }

    // ========== UI更新 ==========

    void UpdateDisplay()
    {
        if (displayText == null) return;

        if (hidePassword)
        {
            // 显示为星号
            string hidden = "";
            for (int i = 0; i < currentInput.Length; i++)
            {
                hidden += "●";
                if (i < currentInput.Length - 1)
                    hidden += " ";
            }
            displayText.text = hidden;
        }
        else
        {
            // 显示数字
            displayText.text = currentInput;
        }

        // 解锁成功时变色
        if (isUnlocked)
        {
            displayText.color = Color.green;
        }
    }

    void UpdateStatus(string message)
    {
        if (statusText != null)
            statusText.text = message;
    }

    // ========== 视觉效果 ==========

    IEnumerator SuccessEffect()
    {
        if (displayText != null)
        {
            Color originalColor = displayText.color;

            for (int i = 0; i < 3; i++)
            {
                displayText.color = Color.green;
                yield return new WaitForSeconds(0.3f);
                displayText.color = originalColor;
                yield return new WaitForSeconds(0.3f);
            }

            displayText.color = Color.green;
        }
    }

    IEnumerator WrongEffect()
    {
        if (displayText != null)
        {
            Color originalColor = displayText.color;

            for (int i = 0; i < 3; i++)
            {
                displayText.color = Color.red;
                yield return new WaitForSeconds(0.2f);
                displayText.color = originalColor;
                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    // ========== 解锁操作 ==========

    void UnlockAction()
    {
        // 显示解锁对象
        foreach (GameObject obj in unlockObjects)
        {
            if (obj != null)
                obj.SetActive(true);
        }

        // 隐藏锁定对象
        foreach (GameObject obj in lockObjects)
        {
            if (obj != null)
                obj.SetActive(false);
        }

        // 触发解锁事件
        OnUnlock?.Invoke();
    }

    // ========== 公共方法 ==========

    public void OpenLock()
    {
        if (lockPanel != null)
        {
            lockPanel.SetActive(true);
            ResetLock();
        }
    }

    public void CloseLock()
    {
        if (lockPanel != null)
            lockPanel.SetActive(false);
    }

    public void ResetLock()
    {
        currentInput = "";
        isUnlocked = false;

        if (displayText != null)
            displayText.color = Color.white;

        UpdateDisplay();
        UpdateStatus("请输入" + passwordLength + "位密码");
    }

    public bool IsUnlocked()
    {
        return isUnlocked;
    }

    public void SetPassword(string newPassword)
    {
        correctPassword = newPassword;
        passwordLength = newPassword.Length;
        UpdateStatus("请输入" + passwordLength + "位密码");
    }

    // ========== 工具方法 ==========

    void PlaySound(AudioClip clip)
    {
        if (clip != null && audioSource != null)
        {
            audioSource.PlayOneShot(clip);
        }
    }

    // ========== 事件 ==========

    public System.Action OnUnlock;
}