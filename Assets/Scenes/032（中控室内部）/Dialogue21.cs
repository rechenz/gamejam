using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue21 : MonoBehaviour
{
    public string DialogueID = "Dialogue021";
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
    // Start is called before the first frame update
    void Start()
    {
        bool isRead = SimpleStateManager.Instance.LoadBool(DialogueID, "isRead", false);
        if (isRead)
        {
            this.enabled = false;
        }
        else
        {
            SetBegin();
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !SimpleStateManager.Instance.LoadBool(DialogueID, "isRead", false))
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
        List<DialogueLine> Dialogue = new List<DialogueLine>()
        {
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "好熟悉。这是Neumann进到房间里的第一感受。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "明明是第一次来到这里，但Neumann却对这个房间的每一个配置都感到无比的熟悉。房间里的桌椅板凳、墙上挂着的巨大屏幕，他几乎有着即便闭上眼睛也能摸清楚这个房间配置的自信。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "这上面是......康威生命游戏？但是已经是死局了。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "Neumann抬头观察着墙上的巨大屏幕，画面定格在康威生命游戏进入死循环后的某一帧上。这一场演算已经结束了，但不知道是谁按下了暂停键——"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "他真的不知道按下暂停键的是谁吗？"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "！！"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannHelpless,
                characterPosition = CharacterPosition.Left,
                dialogue = "察觉到内心的疑问的瞬间，Neumann的头上冒出了几颗汗珠。他慢慢地走到操控台前，看了一眼终端上的屏幕。不出所料，终端被封锁了。用了一种比以往遇到的谜题还复杂得多的形式。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "Neumann观察了一会儿屏幕上的谜题，然后进入了点阵视域。不出他所料，操作台上贴着两张写着密码表的便签纸。但除了密码以外，便签纸上还写着一句话——"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "......\"\\\\欢迎回来\"\\\\。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "是谁留下的这两张便签纸？"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "......还是先把这台终端解锁了以后再说吧。说不定他的疑问能被终端里的信息所解答。"
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        this.enabled = false;
    }

}
