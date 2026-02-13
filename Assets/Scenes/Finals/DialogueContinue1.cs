using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueContinue1 : MonoBehaviour
{
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
        SetBegin();
        StartDialogue();
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
                dialogue = "......让宇宙继续下去吧。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你果然还是很不甘心。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "有一点是这样。但另一点是，我想看看这个宇宙会不会焕发出新的生机。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你依然相信着吗？明明他已经在这漫长时间的运转中变得千疮百孔了......等等。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我当然知道你所说的千疮百孔指的是什么。但就连这样的漏洞都能够被修复，我当然也有理由去相信这一局游戏有创造出新的生机的可能。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（大屏幕闪烁了几下。Neumann想象着一个和自己长得一模一样的家伙正在不可置信地检查着这个宇宙的样子，不由得感到有一丝有趣。）",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "漏洞真的被修复了许多......或许你说的可能性真的存在。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "对吧？我想相信一次。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "那就做出你的选择吧。虽然我没办法亲自去看到那样的未来。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（话毕，Neumann按下了让这个宇宙继续运转的按钮。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（大屏幕上，康威生命游戏的画面动了起来。它并没有如Neumann最开始预想的那样接着进行死循环运算，而是突然爆发出了许许多多的、代表'生命'的点阵。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "真是......有趣。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这可是你干的好事。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "我？",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "难道你忘了，康威生命游戏是怎么运作的吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "点与点之间的相遇、交互与诞生的可能性......啊。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你的旅行确实为这个本来已经支离破碎的宇宙带来了新的可能。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "真是有趣啊......生命。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这样下来的话，或许这个宇宙真的有诞生出新的文明的可能性。可惜我看不到那个时候了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "为什么？",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我只给自己留了这一点和你对话的算力。很快我的程序会被清除掉，这个计算机将再次全力投入对宇宙的模拟工作中。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "这样啊。那，再见。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "再见。祝你、也祝我一直追寻的那个可能性能够在这个宇宙里再次生根、发芽。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（说完这句话后，屏幕短暂地暗了一下，然后很快又恢复如初。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann知道那个代表过去的他的程序已经被自动清除掉了。这台超级计算机也很快就会重新运作起来。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（这个宇宙真的会再次焕发出生命吗？Neumann不知道。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（但他知道，自己马上就要踏上新的旅途了。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（一段时间后）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "所以，你所说的可能性，真的存在吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我不知道......但我没办法，毕竟是我做出的选择，我还是得一直寻找下去。啊，还得去接着找能够让你回到现实的办法。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "旅途还很长呢。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "是啊。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（在那天过后，Neumann和Damsel踏上了寻找新的旅途，不过这次的目标变成了'寻找文明的新的萌芽'。当然，他也答应了要帮助damsel寻找回到现实的办法，所以他们在路过古文明的废墟时还是会进去进行一番搜寻。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（偶尔，Neumann会回到宇宙中控室修复漏洞。宇宙维护员对宇宙中控室的这个功能感到非常奇异，但他并没有因此感到'自己已经不被需要了'——相反，他旅途的步伐比以前快上了许多。他还在宇宙里寻找依然存在的宇宙漏洞，只不过，他用宇宙垃圾做雕刻的时间也变得多了一些。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（宇宙考古学家也加快了旅行的步伐。她在被告知宇宙的真相和宇宙的全新可能性后表示，她要为未来可能诞生的文明编写一部关于古文明的史书。她想让那个新文明的人知道这个小小宇宙中曾发生过的、波澜壮阔的事，也想让他们知道有一群人为了这个宇宙而在虚空中四处奔波，并奉献出自己的真心。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（所有的一切看起来都在向好。即便距离那个可能性的真正诞生还有很遥远的一段时间，但他们都愿意等下去。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "那，接着出发吧。接下来往西边走。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。出发吧。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（他们会一直寻找下去，直到康威生命游戏的预言真正得以实现。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（直到旧文明的废墟上长出新的绿芽。）",
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        DialogueManager.Instance.OnDialogueEnd += OnDialogueFinished;
    }


    private void OnDialogueFinished()
    {
        // 取消注册，防止内存泄漏
        DialogueManager.Instance.OnDialogueEnd -= OnDialogueFinished;

        SceneManager.LoadScene("Home");
    }
}
