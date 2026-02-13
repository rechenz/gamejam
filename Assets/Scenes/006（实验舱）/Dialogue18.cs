using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue18 : MonoBehaviour
{
    public string DialogueID = "Dialogue018";
    [Header("Neumann")]
    private Sprite NeumannAmazed;
    private Sprite NeumannNormal;
    private Sprite NeumannHelpless;
    private Sprite NeumannPuzzled;
    private Sprite NeumannSmile;
    private Sprite NeumannWounded;
    [Header("Damsel")]
    private Sprite DamselNormal;
    private Sprite DamselSilent;
    private Sprite DamselSmile;
    [Header("宇宙维护员")]
    private Sprite ProtecterNormal;
    private Sprite ProtecterSmile;
    private Sprite ProtecterAngry;
    private Sprite ProtecterHappy;
    public DialogueSprites dialogueSprites;

    bool isInRange;

    void Start()
    {
        bool isRead = SimpleStateManager.Instance.LoadBool(DialogueID, "isRead", false);
        if (isRead)
        {
            // Destroy(gameObject);
            this.enabled = false;
            return;
        }
        else
        {
            SetBegin();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }


    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F))
        {
            StartDialogue();
        }
    }

    private void SetBegin()
    {
        NeumannAmazed = dialogueSprites.NeumannAmazed;
        NeumannNormal = dialogueSprites.NeumannNormal;
        NeumannHelpless = dialogueSprites.NeumannHelpless;
        NeumannPuzzled = dialogueSprites.NeumannPuzzled;
        NeumannSmile = dialogueSprites.NeumannSmile;
        NeumannWounded = dialogueSprites.NeumannWounded;
        DamselNormal = dialogueSprites.DamselNormal;
        DamselSilent = dialogueSprites.DamselSilent;
        DamselSmile = dialogueSprites.DamselSmile;
        ProtecterNormal = dialogueSprites.ProtecterNormal;
        ProtecterSmile = dialogueSprites.ProtecterSmile;
        ProtecterAngry = dialogueSprites.ProtecterAngry;
        ProtecterHappy = dialogueSprites.ProtecterHappy;
    }

    public void StartDialogue()
    {
        // 先播放主对话
        DialogueManager.Instance.StartDialogue(MainDialogue());

        // 检查是否需要播放秘密对话
        if (SimpleStateManager.Instance.LoadBool("Player", "AbleToKillBugs", false))
        {
            // 在主对话结束后自动播放秘密对话
            DialogueManager.Instance.OnDialogueEnd += PlaySecretDialogue;
            SimpleStateManager.Instance.SaveBool("Damsel", "isLeft", true);
        }

        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        this.enabled = false;
    }

    private List<DialogueLine> MainDialogue()
    {
        return new List<DialogueLine>()
        {
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "说起来，我有一个问题想问你。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "请说。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "你知道'花园'吗？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊，我曾经听一个会修补宇宙漏洞的维护员提起过。后来我也找到了一点关于它的记载。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "能告诉我吗？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "那则记载其实很隐晦......它只说在这个宇宙的最东边有一个能够让生命成为生命的花园。但我并不知道那句'让生命成为生命'是什么意思。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "宇宙的最东边吗......谢谢你。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "你在寻找它吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "算是吧。我的朋友正在寻找那个花园，所以我来帮她问问。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "这样啊。但很可惜我只能给你提供这么一点消息了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "没关系，这就已经足够了。谢谢你。",
            }
        };
    }

    private void PlaySecretDialogue()
    {
        // 取消注册，防止重复调用
        DialogueManager.Instance.OnDialogueEnd -= PlaySecretDialogue;

        // 播放秘密对话
        DialogueManager.Instance.StartDialogue(SecretDialogue());
    }

    private List<DialogueLine> SecretDialogue()
    {
        return new List<DialogueLine>()
        {
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "Neumann......有一件事我得对你说。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "怎么了？怎么用这么郑重的语气。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我得离开了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "咦？去哪？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "花园。我好像找到它的位置了。我必须去找到它才行。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "需要我跟你一起去吗？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "不太行。我有种预感，花园只会接纳我一个人......所以我们得暂时分别了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "......这样啊。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "很抱歉。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "没必要道歉......不过，我们还会再见的吧？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然。我找到答案以后会立马来找你的。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。假如我先找到我想要的答案的话，我也会在一切结束过后立马过来找你......保重，好朋友。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯，保重。祝我们都能够找到想要的答案......祝我们还能够在未来重逢。",
            }
        };
    }
}

