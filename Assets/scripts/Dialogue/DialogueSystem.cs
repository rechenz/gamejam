using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    [Header("UI 引用")]
    public GameObject dialoguePanel;
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public GameObject continueIcon;

    [Header("角色立绘")]
    public UnityEngine.UI.Image characterLeft;
    public UnityEngine.UI.Image characterCenter;
    public UnityEngine.UI.Image characterRight;

    [Header("设置")]
    public float textSpeed = 0.05f;
    public int maxVisibleLines = 3;
    public int maxCharsPerLine = 40;

    // 当前对话数据
    private Queue<DialogueLine> dialogueQueue = new Queue<DialogueLine>();
    private List<string> currentDialogueLines = new List<string>();
    private int currentLineIndex = 0;
    private bool isTyping = false;
    private Coroutine typingCoroutine;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        dialoguePanel.SetActive(false);
        HideAllCharacters();
    }

    void Update()
    {
        if (dialoguePanel.activeSelf && UnityEngine.Input.GetMouseButtonDown(0))
        {
            if (isTyping)
            {
                CompleteCurrentLine();
            }
            else
            {
                // 判断是否还有更多文本
                if (currentLineIndex + maxVisibleLines < currentDialogueLines.Count)
                {
                    ShowNextLineSegment();
                }
                else if (dialogueQueue.Count > 0)
                {
                    ShowNextDialogue();
                }
                else
                {
                    EndDialogue();
                }
            }
        }

        if (dialoguePanel.activeSelf && UnityEngine.Input.GetKeyDown(KeyCode.Escape))
        {
            EndDialogue();
        }
    }

    // ========== 公开方法 ==========

    public void StartDialogue(List<DialogueLine> lines)
    {
        dialogueQueue.Clear();

        foreach (var line in lines)
        {
            dialogueQueue.Enqueue(line);
        }

        dialoguePanel.SetActive(true);
        continueIcon.SetActive(false);

        ShowNextDialogue();
    }

    public void StartDialogue(DialogueLine singleLine)
    {
        dialogueQueue.Clear();
        dialogueQueue.Enqueue(singleLine);

        dialoguePanel.SetActive(true);
        continueIcon.SetActive(false);

        ShowNextDialogue();
    }

    // ========== 内部逻辑 ==========

    private void ShowNextDialogue()
    {
        if (dialogueQueue.Count == 0)
        {
            EndDialogue();
            return;
        }

        // 重置多行相关变量
        currentDialogueLines.Clear();
        currentLineIndex = 0;

        DialogueLine line = dialogueQueue.Dequeue();
        SetupCharacter(line);

        // 设置名字
        nameText.text = line.characterName;
        nameText.color = GetNameColor(line.characterName);

        // 处理多行文本
        ProcessMultiLineText(line.dialogue);

        // 开始显示文本
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        typingCoroutine = StartCoroutine(TypeTextWithLineBreaks());
    }

    private void ShowNextLineSegment()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        currentLineIndex += maxVisibleLines;
        typingCoroutine = StartCoroutine(TypeTextWithLineBreaks());
    }

    // ========== 文本处理 ==========

    private void ProcessMultiLineText(string fullText)
    {
        currentDialogueLines.Clear();

        if (fullText.Contains("\n"))
        {
            string[] manualLines = fullText.Split('\n');
            foreach (string line in manualLines)
            {
                if (!string.IsNullOrWhiteSpace(line))
                    currentDialogueLines.Add(line.Trim());
            }
        }
        else
        {
            currentDialogueLines = WrapText(fullText, maxCharsPerLine);
        }
    }

    private List<string> WrapText(string text, int charsPerLine)
    {
        List<string> lines = new List<string>();

        if (string.IsNullOrEmpty(text))
            return lines;

        // 简单的中文换行算法
        int startIndex = 0;
        while (startIndex < text.Length)
        {
            // 计算这一行能放多少字符
            int lineLength = Mathf.Min(charsPerLine, text.Length - startIndex);

            // 如果有剩余字符，尝试在标点处换行
            if (startIndex + lineLength < text.Length)
            {
                // 查找合适的断点
                int breakIndex = FindBreakPoint(text, startIndex, lineLength);
                if (breakIndex > startIndex)
                {
                    lineLength = breakIndex - startIndex + 1;
                }
            }

            lines.Add(text.Substring(startIndex, lineLength));
            startIndex += lineLength;
        }

        return lines;
    }

    private int FindBreakPoint(string text, int startIndex, int maxLength)
    {
        // 从后往前查找合适的断点
        for (int i = startIndex + maxLength - 1; i > startIndex; i--)
        {
            if (IsGoodBreakPoint(text[i]))
                return i;
        }

        // 没找到合适的断点，强制在maxLength处换行
        return startIndex + maxLength - 1;
    }

    private bool IsGoodBreakPoint(char c)
    {
        // 中文标点
        if (c == '。' || c == '，' || c == '、' || c == '；' || c == '！' || c == '？' ||
            c == '：' || c == '」' || c == '』' || c == '）' || c == '》' || c == '】')
            return true;

        // 英文标点
        if (c == '.' || c == ',' || c == ';' || c == '!' || c == '?' || c == ':' ||
            c == ')' || c == ']' || c == '}' || c == '>')
            return true;

        // 空格（处理中英文混合）
        if (c == ' ')
            return true;

        return false;
    }

    // ========== 协程 ==========

    private System.Collections.IEnumerator TypeTextWithLineBreaks()
    {
        isTyping = true;
        continueIcon.SetActive(false);

        // 计算要显示的行范围
        int startLine = currentLineIndex;
        int endLine = Mathf.Min(currentLineIndex + maxVisibleLines, currentDialogueLines.Count);

        // 构建要显示的文本
        System.Text.StringBuilder displayText = new System.Text.StringBuilder();
        for (int i = startLine; i < endLine; i++)
        {
            if (i > startLine) displayText.Append("\n");

            string lineText = currentDialogueLines[i];
            displayText.Append(lineText);

            // 如果不是最后一行，且还有更多内容，添加省略号
            if (i == endLine - 1 && endLine < currentDialogueLines.Count)
            {
                if (!lineText.EndsWith("..."))
                    displayText.Append("...");
            }
        }

        // 逐字显示
        dialogueText.text = "";
        string targetText = displayText.ToString();

        for (int i = 0; i < targetText.Length; i++)
        {
            dialogueText.text += targetText[i];

            if (targetText[i] == '\n')
            {
                yield return new WaitForSeconds(textSpeed * 2);
            }

            yield return new WaitForSeconds(textSpeed);
        }

        isTyping = false;
        continueIcon.SetActive(true);
    }

    private void CompleteCurrentLine()
    {
        if (typingCoroutine != null)
            StopCoroutine(typingCoroutine);

        // 显示当前页的完整文本
        int startLine = currentLineIndex;
        int endLine = Mathf.Min(currentLineIndex + maxVisibleLines, currentDialogueLines.Count);

        System.Text.StringBuilder displayText = new System.Text.StringBuilder();
        for (int i = startLine; i < endLine; i++)
        {
            if (i > startLine) displayText.Append("\n");

            string lineText = currentDialogueLines[i];
            displayText.Append(lineText);

            if (i == endLine - 1 && endLine < currentDialogueLines.Count)
            {
                if (!lineText.EndsWith("..."))
                    displayText.Append("...");
            }
        }

        dialogueText.text = displayText.ToString();
        isTyping = false;
        continueIcon.SetActive(true);
    }

    // ========== UI 控制 ==========

    private void SetupCharacter(DialogueLine line)
    {
        // 重置所有立绘透明度
        characterLeft.color = new Color(1, 1, 1, 0.3f);
        characterCenter.color = new Color(1, 1, 1, 0.3f);
        characterRight.color = new Color(1, 1, 1, 0.3f);

        // 设置当前立绘
        if (line.characterSprite != null && line.characterPosition != CharacterPosition.None)
        {
            UnityEngine.UI.Image targetImage = null;

            switch (line.characterPosition)
            {
                case CharacterPosition.Left:
                    targetImage = characterLeft;
                    break;
                case CharacterPosition.Center:
                    targetImage = characterCenter;
                    break;
                case CharacterPosition.Right:
                    targetImage = characterRight;
                    break;
            }

            if (targetImage != null)
            {
                targetImage.sprite = line.characterSprite;
                targetImage.color = new Color(1, 1, 1, 1);

                // 根据表情调整（可以扩展）
                ApplyExpression(targetImage, line.expression);
            }
        }
    }

    private void ApplyExpression(UnityEngine.UI.Image image, CharacterExpression expression)
    {
        // 这里可以添加表情特效
        // 例如：改变颜色、添加滤镜、切换材质等
        switch (expression)
        {
            case CharacterExpression.Angry:
                image.color = new Color(1, 0.8f, 0.8f, image.color.a);
                break;
            case CharacterExpression.Sad:
                image.color = new Color(0.8f, 0.8f, 1, image.color.a);
                break;
            case CharacterExpression.Happy:
                image.color = new Color(1, 1, 0.9f, image.color.a);
                break;
        }
    }

    private void HideAllCharacters()
    {
        characterLeft.color = new Color(1, 1, 1, 0);
        characterCenter.color = new Color(1, 1, 1, 0);
        characterRight.color = new Color(1, 1, 1, 0);
    }

    private UnityEngine.Color GetNameColor(string characterName)
    {
        // 预设角色颜色
        System.Collections.Generic.Dictionary<string, UnityEngine.Color> nameColors =
            new System.Collections.Generic.Dictionary<string, UnityEngine.Color>()
        {
            { "主角", UnityEngine.Color.cyan },
            { "玩家", UnityEngine.Color.cyan },
            { "英雄", UnityEngine.Color.cyan },
            { "NPC", UnityEngine.Color.yellow },
            { "村民", UnityEngine.Color.green },
            { "敌人", UnityEngine.Color.red },
            { "国王", UnityEngine.Color.magenta },
            { "系统", UnityEngine.Color.gray },
            { "旁白", UnityEngine.Color.gray }
        };

        if (nameColors.ContainsKey(characterName))
            return nameColors[characterName];

        // 生成随机但稳定的颜色
        return GenerateColorFromName(characterName);
    }

    private UnityEngine.Color GenerateColorFromName(string name)
    {
        // 使用名字的哈希值生成颜色
        int hash = name.GetHashCode();
        float r = (hash & 0xFF) / 255f;
        float g = ((hash >> 8) & 0xFF) / 255f;
        float b = ((hash >> 16) & 0xFF) / 255f;

        // 确保不太暗
        return new UnityEngine.Color(
            Mathf.Max(0.5f, r),
            Mathf.Max(0.5f, g),
            Mathf.Max(0.5f, b)
        );
    }

    // ========== 公共接口 ==========

    public void EndDialogue()
    {
        dialoguePanel.SetActive(false);
        HideAllCharacters();
        dialogueQueue.Clear();
        currentDialogueLines.Clear();
        currentLineIndex = 0;

        OnDialogueEnd?.Invoke();
    }

    public bool IsDialogueActive()
    {
        return dialoguePanel.activeSelf;
    }

    // 事件
    public System.Action OnDialogueEnd;
}