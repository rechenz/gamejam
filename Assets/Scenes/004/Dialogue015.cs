using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue015 : MonoBehaviour
{
    public string DialogueID = "Dialogue015";
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
        if (!SimpleStateManager.Instance.LoadBool("Seed", "hasSeed", false))
        {
            this.enabled = false;
        }
        bool isRead = SimpleStateManager.Instance.LoadBool(DialogueID, "isRead", false);
        if (isRead)
        {
            this.enabled = false;
        }
        else
        {
            SetBegin();
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
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "对了，这个给你。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这个是？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "不知道是什么植物的种子，我之前在一处古文明废墟里发现的。就当作是临别时的赠礼吧。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊，谢谢！我的确很喜欢植物......虽然我已经很久没有看见活着的植物了。不过，你为什么觉得我会喜欢植物呢？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯......你之前说过，你喜欢用各种各样的太空垃圾雕成花。大概是因为这个，我才猜测你喜欢花卉和植物。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你猜得确实很准。不瞒你说，我在这个宇宙里四处旅行的另一个目的是找到还存活着的花朵。但是我已经走过很多地方了，连前文明的书中记载的、可以在城市的路面上生长的草都没见过。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "你这么一说我才发现，我也没有见过。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "是啊。像这样的种子我也收集了一些，我也试着在一个比较稳定的废墟里把它们种下去过，但没有一个能够从土里冒出芽的。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "难怪你当时看到我会那么惊讶和沮丧。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你当时还吓了我一跳，宇宙幽灵小姐。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你也吓到我了，宇宙环卫工先生。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "你之后打算去哪儿？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "继续修补宇宙里的漏洞，顺便寻找那朵不知道存不存在的花吧。啊，说起来，我也送你们一件礼物好了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "什么？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你们还要接着旅行对吧？来，这个拿好——是让你拿在手里，不是让你拿到手就收起来。我现在要教你修补宇宙漏洞的办法。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "这个是？种子？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "对。我记得你也有影响那个世界的构造的能力吧——被你们叫作'点阵的世界'的那个。假如你们在旅途中空间漏洞的话，就捏着这个，然后慢慢地靠近那个漏洞。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "靠近漏洞——然后呢？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "想象你的面前是一个小土坑，你正在把一颗种子放进去——对，保持这样的状态。然后松开手后退。这样就可以了。只要等上一会儿，宇宙漏洞就会自动闭合。到那时你再上前去回收这颗种子就好。这是一种比较基础的漏洞修补方法，虽然会有漏洞重新破开的风险，但那至少要等上——嗯，十几个古文明年的时间。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "这样啊......我大概明白了。谢谢。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "不用谢。你们在旅途中遇到宇宙漏洞的话也能方便一些，至少不会被挡住路。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（你现在可以按E来修复漏洞了）"
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        SimpleStateManager.Instance.SaveBool("Player", "AbleToKillBugs", true);
        this.enabled = false;
    }

}
