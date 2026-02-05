using UnityEngine;
using System.Collections.Generic;

public class DialogueTester : MonoBehaviour
{
    [Header("测试数据")]
    public Sprite heroSprite;
    public Sprite npcSprite;
    public AudioClip testVoice;

    [Header("自动测试")]
    public bool autoStart = true;
    public float delay = 1f;

    void Start()
    {
        if (autoStart)
        {
            Invoke("TestDialogue", delay);
        }
    }

    void Update()
    {
        // 快捷键测试
        if (Input.GetKeyDown(KeyCode.F1))
        {
            TestSingleLine();
        }

        if (Input.GetKeyDown(KeyCode.F2))
        {
            TestMultiLine();
        }

        if (Input.GetKeyDown(KeyCode.F3))
        {
            TestLongDialogue();
        }
    }

    public void TestSingleLine()
    {
        DialogueLine line = new DialogueLine()
        {
            characterName = "主角",
            characterSprite = heroSprite,
            characterPosition = CharacterPosition.Left,
            dialogue = "你好，世界！",
            expression = CharacterExpression.Happy,
            voiceClip = testVoice
        };

        DialogueManager.Instance.StartDialogue(line);
    }

    public void TestMultiLine()
    {
        List<DialogueLine> dialogue = new List<DialogueLine>()
        {
            new DialogueLine()
            {
                characterName = "主角",
                characterSprite = heroSprite,
                characterPosition = CharacterPosition.Left,
                dialogue = "这里发生了什么？为什么大家都这么紧张？",
                expression = CharacterExpression.Surprised
            },
            new DialogueLine()
            {
                characterName = "村民",
                characterSprite = npcSprite,
                characterPosition = CharacterPosition.Right,
                dialogue = "有怪物在附近出没！我们已经有好几个人失踪了。",
                expression = CharacterExpression.Angry
            },
            new DialogueLine()
            {
                characterName = "主角",
                characterSprite = heroSprite,
                characterPosition = CharacterPosition.Left,
                dialogue = "不用担心，我会处理这个问题。",
                expression = CharacterExpression.Happy
            }
        };

        DialogueManager.Instance.StartDialogue(dialogue);
    }

    public void TestLongDialogue()
    {
        DialogueLine longLine = new DialogueLine()
        {
            characterName = "旁白",
            characterSprite = null,
            characterPosition = CharacterPosition.None,
            dialogue = "这是一个非常长的对话文本，用来测试自动换行功能。" +
                      "这段文字会超过对话框的宽度，系统会自动将其分割成多行显示。" +
                      "如果行数超过最大显示行数，还会自动分页，玩家可以点击继续阅读。" +
                      "这是一个完整的多行文本测试示例，包含标点符号和长句子。",
            expression = CharacterExpression.Normal
        };

        DialogueManager.Instance.StartDialogue(longLine);
    }

    public void TestDialogue()
    {
        TestMultiLine();
    }

    // 在UI按钮上调用
    public void StartTestDialogue()
    {
        TestMultiLine();
    }
}