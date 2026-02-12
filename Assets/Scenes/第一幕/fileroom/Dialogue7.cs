using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue7 : MonoBehaviour
{
    public string DialogueID = "Dialogue007";
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
    public GameObject ToDoor;
    void Start()
    {
        if (!SimpleStateManager.Instance.LoadBool("Dialogue006", "isRead", false))
        {
            this.enabled = false;
        }
        bool isRead = SimpleStateManager.Instance.LoadBool(DialogueID, "isRead", false);
        if (isRead)
        {
            // Destroy(gameObject);
            this.enabled = false;
        }
        else
        {
            SetBegin();
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
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "好神奇......竟然还可以这样。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann观察着自己的手。他的手臂失去了基色，取而代之的是奇异的蓝——上面还覆盖了一层并不算细密的网点。他变成了和周围事物相似的点阵构造体的样子。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（可惜这里没有镜子，不然还真想看看跟这个世界同质化后的自己是什么模样。Neumann这样想着，试着活动了一下双手。和平时没有什么两样，只不过身体外观上的变化一时间让他感觉难以适应。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（同时，不知道为什么，Neumann总感觉心中有一股隐约的不安感。）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你的本质原来是这个样子。感觉怎么样？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "没有什么不舒服的地方......但不知道为什么，心里感觉很不安。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊。忘了提醒你了。",
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
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你只能维持这个状态一小段时间。时间太长的话，你的结构会崩溃——换句话说，你在现实中的身体会消散。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "怎么不早说？！很危险欸！",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselSmile,
                characterPosition = CharacterPosition.Right,
                dialogue = "看你的状态，只要在大概......五分钟吧，保守一些。五分钟内变回去就好。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "......好。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（几乎是一刻也不敢多等，Neumann立刻让自己的身体从点阵化的状态中脱离了出来。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann把手放在箱子上，晃了一晃，然后轻轻地一推。箱子被打开了。他探头往里面看去，然后从箱子里拿出了一小叠纸。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "这是什么......报告？竟然还保存得这么好。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "上面写的什么？可以拜托你念给我听听吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "你......对哦。你说过你看不到现实世界的。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "所以拜托你了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。稍等一下，我看看上面写的什么......是古文明关于点阵世界的研究报告。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "上面说了什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "......大概的意思是说，这座废墟曾经所属的城市正在尝试从点阵世界的角度入手，构建一个行星防御系统，以此来应对'很快就要降临的大灾难'。古文明似乎很擅长运用点阵世界的知识来构建他们的城市。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "但看得出来这项研究失败了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "Damsel，你对古文明的了解有多少？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "只记得它们是这个宇宙里唯一的文明。并且它已经灭亡了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我对古文明的了解也很少，但我很奇怪为什么这样一个拥有极高科技水平的文明会被毁灭。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你真是为了寻找这个答案而来到这里的吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。我想知道古文明灭绝的答案，在这个答案背后的、关于这个宇宙的奥秘。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselSmile,
                characterPosition = CharacterPosition.Right,
                dialogue = "原来你还是个志向远大的旅行家。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "并没有多伟大的志向，我四处旅行的根本目的是寻找自己关于过去的记忆。但是我感觉古文明灭绝的真相跟我的记忆会有关系，所以才在追寻它。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "原来是这样。你也是一个失忆的人。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "为什么说'也'？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "因为我也记不得以前发生的事了——虽然我并不知道所谓的过去到底存不存在。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "那，你也是为了寻求记忆而来到这里的吗？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯？不是。我是在寻找让我回到现实世界中的办法。虽然没有依据......但我总觉得这个宇宙里有一个地方可以让我回到现实中来。",
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
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann从地上站起身来，将那叠报告叠起来收好。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "要一起吗？一起找。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我说——要一起旅行吗？就是成为同伴的意思。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "同伴是什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "能够在彼此相重合的旅途轨迹上向对方伸出援手的人。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "'向对方伸出援手'吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "对，就像刚才那样。你教我打开这个箱子，我把有用的信息念给你听。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselSmile,
                characterPosition = CharacterPosition.Right,
                dialogue = "听上去是个很不错的提议。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "所以要一起吗？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯......还请多多关照。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（蓝玫瑰的花朵朝着Neumann垂了一下，似乎是Damsel向Neumann轻轻地鞠了一躬。见状，Neumann也朝着蓝玫瑰鞠了一躬，作为回礼。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "好哦。今后也请多多关照。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "不过，我有一个疑问。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯？什么问题？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你是怎么在这个宇宙里旅行的？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "这个嘛......你等下就可以知道了。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "另外我帮你把储藏室的门打开了，咱们可以进去看看",
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        ToDoor.SetActive(true);
        this.enabled = false;
    }

}
