using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue014 : MonoBehaviour
{
    public string DialogueID = "Dialogue014";
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
    public GameObject Bug;
    // Start is called before the first frame update
    void Start()
    {
        if (!SimpleStateManager.Instance.LoadBool("Dialogue012", "isRead", false))
        {
            this.enabled = false;
            return;
        }
        bool isRead = SimpleStateManager.Instance.LoadBool(DialogueID, "isRead", false);
        if (isRead)
        {
            Done();
            this.enabled = false;
        }
        else
        {
            SetBegin();
            StartDialogue();
        }
    }

    void Done()
    {
        Destroy(Bug);
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
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "第三个了。辛苦了。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "没事，本来就是我的工作。说起来，你们知道关于这个宇宙的事吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "知道得不是很多。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "只知道它已经千疮百孔了。到处都是宇宙漏洞。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "的确是这样......",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "不过，说到这个，这个宇宙里还有其他人存在吗？虽然它并不大，但总应该有几个像我们这样的人还存在着。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然有。不过像Damsel这样的应该是唯一一个。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "唔。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "真的还有其他人吗？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然。我认识其中的两个，一个是和你一样在到处旅行的考古学家——他很喜欢在这附近活动，这会儿应该是跑出去探索废墟了。另一位是个年纪很大的老人......那位老人是一位知道关于古文明很多事情的隐士。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "隐士？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。他隐居在一处很小的古文明废墟里，偶尔会在宇宙里四处逛逛，遇到人就拉着他下棋，遇不到人就自己琢磨棋路。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "感觉是一位很有意思的老人。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "对，他人很有意思的。我被他拉着下过两次棋，他一边下棋，一边告诉我这个宇宙里还有不少人生活着，只是彼此被时间和空间隔绝开了，联系不到一块。他还说，一个死去的文明其实就是这个样子的：承载文明的岛屿崩碎了，剩下的人们被宇宙隔离开来，再也没办法重新建立起一个新的文明......",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "知道很多古文明的事吗......",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "怎么了？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我只是在想，假如我们能遇到他的话，我想向他问一些问题。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这已经是最后一个了。你们应该可以继续旅行了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "谢谢你。你要离开了吗？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。宇宙垃圾的储备不够了，我得去离这里最近的小行星带回收一些。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "这样啊......",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterSmile,
                characterPosition = CharacterPosition.Right,
                dialogue = "没事啦，以后还会再见的。旅途愉快！",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯，旅途愉快。",
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        Done();
        this.enabled = false;
    }

}
