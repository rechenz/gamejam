using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue012 : MonoBehaviour
{
    public string DialogueID = "Dialogue012";
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
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "奇怪。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "怎么了？这附近没有空间漏洞。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "不，我是说，好像有什么东西在追着我们。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "是别的小行星体吗？还是什么别的太空垃圾？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "不像。那个东西的目标性很强，似乎是朝着我们来的......我停下来看看那是什么吧。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "好。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（一段时间后。）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "是个构造很奇怪的点阵。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "好像是个人。",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "呼，终于抓到你了！...等等，这上面原来有人？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "你好，是你一直在跟着我们吗？",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你好！我追了这颗小行星追了好久。请问你是？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我是Neumann，算是半个旅行家。",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "旅行家？也就是说，这颗小行星是你的？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "当然。它有名字的，叫F-646。",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这样啊......我还以为它是一颗无主的小行星，准备来回收它的。白忙活了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "说起来，我还不知道你是谁。",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊，很抱歉，我没有名字。你可以直接叫我维护员。我正在回收宇宙中的小行星和太空垃圾，并用它们来修复宇宙空间。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "修复宇宙空间......你能修补宇宙中的漏洞？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然。这个是我的工作。你应该知道吧？这个宇宙里到处都是空间漏洞。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "也是最近才知道的。他们竟然能被修补吗？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然。就像这样。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（维护员说着，从披风里掏出一块拳头大的太空陨石，并把它捏在手里。伴随着一阵并不起眼的光芒，陨石在他的手中消失了，什么都没有剩下。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann惊奇地盯着维护员的手，发现他的手掌中的空间在微微地扭动——也就在这时，Neumann感受到了来自头顶的一股压力。）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "......奇怪的人。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "怎么了？你在观察他？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "他很可怕......就在刚才，这个人把那一小块不知道是什么的物体扭碎了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "维护员先生确实让一块陨石凭空消失在了他手里。等等，你说'扭碎'？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "对。他把那一块陨石的点阵构造完全扭碎了。现在陨石成了被他封锁在手里的、一团无序的点。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "咦，谁在说话？我好像听到了其他人的声音。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "什么声音？这里应该只有我们两个人才对。你听错了吧。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "等等，您头上的花......玫瑰？！是真实的玫瑰吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "什么玫瑰？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "您头上有一朵玫瑰，您不知道吗？一朵蓝色的、叶片还在微微颤抖着的玫瑰。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "啊，那个是......",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann正打算解释，他头顶上的花——Damsel突然从他的头顶落到了肩膀上，然后在半空中漂浮了起来。）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "还是只能借用这么短的时间......",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterAngry,
                characterPosition = CharacterPosition.Right,
                dialogue = "呜啊！玫瑰花在说话？！",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "请先冷静下来......",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann看了一眼身边的Damsel，叹了一口气。看样子是瞒不下去了。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "她不是玫瑰花，也不是鬼......她是我的朋友，只不过并不在现实里存在——我知道这样说很难理解，但我也解释不清楚她为什么会这样——总之您知道她是一个不会对您造成危险的女孩子就是了。刚才她只是在通过我的眼睛观察你。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊、啊，不是鬼，但也不是玫瑰花啊......",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "总之请先冷静下来吧。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann发现维护员的脸上有非常明显的失落感，他本来想询问维护员发生了什么，但话到了嘴边，他还是没能把疑问说出口，而是静静地等待维护员从惊魂未定的状态中缓过来。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "您好些了吗？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "好了一点......她为什么会变成这样？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我也不知道。我并没有留在现实中的记忆......我叫Damsel。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "Damsel是我在废墟里认识的朋友。她正在寻找回到现实里的办法，所以现在才和我一起四处旅行。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "原来是这样。我还是第一次听说这个宇宙里有不存在于现实中的生命存在。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "被吓了一大跳呢。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "是啊。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "话说回来，您刚才说的修复宇宙漏洞的办法，就是把其他物质的点阵构造扭碎成无序的状态、并用它们直接填补在漏洞上吗？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "点阵构造......那是什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "您不知道吗？我们每个人、每个存在都是一个点阵。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "虽然不明白你在说什么......我可不可以把你所说的点阵理解成物理学概念上的原子构造？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "咦？啊，好像确实可以这么理解。在点阵视域的概念里，所有存在都是特定结构的、很直观的点阵构造体。Damsel的本体被困在点阵的世界里了，我也只能借助点阵的视角观察到她的真实模样。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "原来如此。那这朵花——这枝蓝色的玫瑰，是你在现实世界的投影？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。虽然也可以变成其他的花，但是玫瑰的形象最容易维持。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "可惜啊。要是你是一朵真正的花该多好。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "为什么这么说？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你们不是想知道我是怎么样修补宇宙漏洞的吗？跟我来吧。我修补几个给你们看以后，你们俩就知道了。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "看！那里有一个。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "啊。这是我们之前遇到的那个。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "真是有够好运的......看好咯。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（维护员说着，让Neumann和Damsel停下，自己捏着两块拳头大小的陨石慢慢地靠近那个漏洞。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann好奇地看着维护员的动作：他先是和之前一样，让那两块陨石在他手里慢慢地消失掉，然后举起双手，原本空无一物的手掌中突然多出了一些白色的、正在交流涌动着的气流。）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "像网。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann不动声色地运用起了观察点阵世界的能力。在这个视域下，维护员确实像是在编织一张由无序的点重构成的织网。他看着维护员小心翼翼地让'网'落在宇宙漏洞上，随后，奇异的一幕出现了：那张'网'在落到宇宙漏洞的表面上后并没有被它吸走，而是拖拽着漏洞平滑的圆形表面，将它一点点地拉扯、扭曲；最后被拉扯开的地方一点点地闭合上了，这个宇宙漏洞在Neumann的视野里变成了一片只是略微有些起伏的空间。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "......好厉害。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "怎么样？现在明白我是怎么修复它的了吧？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯，大概明白了。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "大概弄明白了就行。哦，对了。你们来的路上是不是还遇到了其他的漏洞？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。我没记错的话，算上这个一共遇到了三个。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "那麻烦你带一下路咯。你们想看的话还可以接着看，我正好也去完成一下我的本职工作。",
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        Done();
        this.enabled = false;
    }

}
