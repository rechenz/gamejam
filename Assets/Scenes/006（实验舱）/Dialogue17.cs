using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue17 : MonoBehaviour
{
    public string DialogueID = "Dialogue017";
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
    public GameObject Learner;

    void Start()
    {
        if (!SimpleStateManager.Instance.LoadBool("Dialogue016", "isRead", false))
        {
            Destroy(Learner);
            this.enabled = false;
            return;
        }
        bool isRead = SimpleStateManager.Instance.LoadBool(DialogueID, "isRead", false);
        if (isRead)
        {
            // Destroy(gameObject);
            this.enabled = false;
            return;
        }
        else
        {
            StartDialogue();
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
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "到了！就是这里。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "好小的实验室，但感觉比以前遇到的那些精密得多。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然。就目前我发现的资料来看，这个实验室是古文明用来研究'末日'的。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "'末日'？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "你不知道吗？古文明在灭亡之前就发现了会导致这场灭亡的灾难迹象，并一直在寻找让文明从那场不知名的灾难中幸存下来的方法。这其中当然也包括了你刚才解锁那块终端所使用的、能够影响点阵的世界的能力。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "你知道点阵世界的存在？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然。但我很少能获得点阵的视野。你遇到我的时候，我就是在因为没办法发现那个被我捧在手里的密码而抓狂。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "......很不容易呢。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "也还好啦。毕竟我每次获得点阵的视野都能把它维持很久。这个时候我能够发现古文明留下来的许多资料......闲话少说，等我一下。我把那块终端重新接入这个实验舱。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "这里的供电设施竟然还在正常运作吗？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。就连防御系统都没有失效，只不过那个被我关闭了。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（考古学家跑到操作台前忙活了起来，不一会儿，挂在墙壁上的屏幕亮起了并不显眼的光。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（趁这个空档，Neumann观察起了这个并不大的实验舱。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "咦，这里还有一块终端。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯，但是那块拆下来以后没办法独立运作。所以我只带走了被你破解了的那一块。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "原来是这样。咦，这个......",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯，它还是处于被锁定的状态。能摆脱你把它解锁一下吗？就像刚才那样。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我试试看。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "【Neumann解开了终端上显示的谜题。】",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "好了。比刚才的那个要轻松一些。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "辛苦了！我这边也弄好了。稍微等我一下。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "（低声）她看起来好有激情。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "毕竟是自己喜欢的工作嘛。啊，有了。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（伴随着一阵轻微的嗡鸣声，大屏幕上亮起了一个看起来很像三维地形图的模型。其中的一个位置被用橘色的点标记上了，考古学家使用操作台将那个区域在荧幕上放大了些，然后死死地盯着那个点，以及那个点所对应的宇宙坐标。）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这个坐标......不知道为什么，感觉有一些熟悉。那是哪里？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "不知道，我看不懂古文明的空间坐标编码体系。等下去问问她好了。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "但是比起这个......我想先读一下这份资料。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "资料？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。等我一下。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann说着，操弄起了被连接在操作台上的、他刚刚解锁的那台小型终端。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "啊，这是......实验报告。古文明意图利用点阵世界躲避灾难的报告。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "通过点阵世界......他们好像确实有这个能力。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。这一则报告是这个实验舱最后一名研究员留下来的。报告里说，这个实验舱被用来在模拟出的灾难中做了一场实验。但是实验因为某些原因出了一些偏差，这个实验舱提前开始了在宇宙中漂流的经历、直到最后也没能返回古文明所在的星球。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "但是从结果来说，他们的试验成功了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "对。这个实验舱几乎没有受到什么外力损坏。但很可惜这些研究员没能把研究数据发送回他们的母星。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "有些可惜。啊，那那个坐标会不会是......",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "应该是了。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "喂！在自言自语些什么呢？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "啊，没什么。你那边有什么发现吗？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "有！如果我没推断错的话，那个坐标指向的应该是古文明的母星。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "跟我想的差不多欸。还有什么发现吗？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "有。这里好像还有一则关于古文明被毁灭的报告。报告里大概描述了古文明被毁灭的过程。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "你过来看吧。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann将注意力转向大屏幕。然后他看到了令他终生难忘的一幕。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（大屏幕上的那颗行星正在缓缓破裂、解体。原本呈现为类椭圆体的行星一点点地碎成了无数碎块。随后画面一点点拉远，行星的碎片慢慢地远离它们原本所在的位置——）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（然后一道冲击波将画面清空了。大屏幕回到了一无所有的状态。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "这就是......古文明的末日。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "它原来是这样覆灭的。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（脑袋上传来一阵轻轻的压力，Neumann知道Damsel也看到了古文明灭绝的图像演示。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "不知道为什么，感觉心里有些闷。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "我也有点。可能是因为我们刚才看到了古文明的终末吧。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（直到现在，古文明的废墟碎片依然在宇宙中无序地漂流着。一想到这些，Neumann的心里就有些压抑。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（仅仅是因为他看到了古文明的结局吗？他不知道。但Neumann隐约觉得，让他感到压抑的应该并不只是因为这个。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我出去透透气。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。别走太远。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann于是和Damsel走到了实验舱的舱外。舱外的宇宙依然一片漆黑，那里不再拥有古代科幻故事中的其他文明，也不会有故事里的太阳将它照亮。）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "在想些什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "不知道。不知道为什么......感觉心里很闷。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你曾经珍视过它吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "'珍视'？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我不知道为什么我会这么问。但我总感觉......失忆前的你会是一个很喜欢古文明的人；又或许是一个跟古文明关系很深的人。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "是吗？这样说或许会很合理。那我以前又是谁呢？我本来只是以为，我只是一个在探索古文明遗迹的旅途中寻找自己的记忆的人......但是刚才看到古文明的结局以后，我突然发现我有些不知道自己应该是谁了。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯......你认为，生命是什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "生命吗？生命......像一个个孤立的点。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。文明就像一个巨大的点阵。你只是因为看到了这个巨大的点阵在你的眼前崩溃，而感到无所适从罢了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "或许吧。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "那你认为，一个点在网格上的旅途是什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "'旅途'.......",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "可以把它联想成生命游戏吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "生命游戏？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。在你的轨迹附近总会有规模巨大的点阵正在经历从繁荣到覆灭的生命游戏。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我好像明白你要说什么了。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯，你刚才经历的不过是这一场生命游戏中惊心动魄但也微不足道的一环。我并不是要你不能感到悲伤的意思......我只是希望你，在悲伤过后还能振作起来。因为这样的遭遇还有很多，但旅途还不会停止。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。我明白的。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "呼......我不太会安慰人。希望能够让你感到好受些。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "谢谢你的关心。我再缓一缓就好了。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（舱门传来一阵响动声。考古学家从里面跑了出来。）",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "喂！快来，有新的发现！",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "怎么了？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "看这里......一个全新的坐标。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（考古学家指着小型终端上的一个新出现的坐标。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "啊，这里是......",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "怎么了？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "不知道为什么，我感觉我应该去到那里。坐标我可以复制一份吗？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "谢谢你。我似乎得准备动身了。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "就要离开了吗？我打算再在这里研究一段时间。你刚才解锁的那台终端里有着很珍贵的报告，我需要把它整理一下。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "是那则由这个实验舱的最后一个研究员留下的报告吗？那个我已经看过了。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。但是我得把它整理一下，毕竟这也算是我的工作。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "那，之后再见吧。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。一路顺风。",
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        this.enabled = false;
    }

}
