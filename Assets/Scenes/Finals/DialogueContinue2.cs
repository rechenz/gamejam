using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueContinue2 : MonoBehaviour
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
                dialogue = "我当然知道你所说的千疮百孔指的是什么。但我也知道，在这个宇宙里，有一个人——一个你的朋友编写的程序——一位我在旅途中结识的朋友，正在为修补好这个宇宙而四处奔走。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（大屏幕闪烁了几下。Neumann知道这位过去的他自己正在陷入深思。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann当然也知道自己想要做出选择并不需要说服这位自己。但他也想说服正准备做出选择的Neumann，他想向自己回答一个问题。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（'你为什么要做出这样的选择？'）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "你知道的吧？你当然知道，这个宇宙是在康威生命游戏的基础上运作的。几个像素点在网格阵列中相遇，它们之间产生了交互、进行了交流......随后出现了新的可能性。新的像素点随之被激活，开始向四周辐射出自己的影响力。在像素点个体生与死的变化中，点阵在网格中绽放出了规则的图案。一个文明随之诞生了。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我当然知道。你想说什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "后来，这个点阵在运算过程中不可避免地陷入了死循环。漏洞和灾难随之诞生，文明成为了历史，宇宙也因此被暂停，因为继续运算下去毫无意义。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "但是，在这个被暂停的死循环阵列中，仍然有许多'点'正在继续他们的旅途。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "把宇宙想象成一个还在呼吸的生命，把生命想作一场生命游戏......我相信你能够明白我的意思。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你变得不像是一个死板的数学家了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "是吗？我还不知道以前的我有多死板。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这个比喻确实很有趣。但它真的能够说服你自己吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我不知道。但这样说的话，我开始愿意等待未来了。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（把宇宙想象成一个还在呼吸的生命，把生命想作一场生命游戏。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（生命像是一个行走在点阵里的点。在它的身旁总有巨大的点阵正在经历从诞生到灭亡的历程；在它的身后，生机与灭亡早就运算过了无数个循环。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（而在点的前面，还有无数的可能性在等待着：前面会是一片没有其他像素点亮着的空寂吗？还是说它将要穿过一个巨大的点阵，成为这个繁荣文明中的一员？）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（生命不知道它的未来。所以它会一直走下去。）",
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
                dialogue = "真是......美丽。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "想到了什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "那幅在宇宙实验舱里看到的、古文明被毁灭的演示图像。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你真的愿意将可能性交给无限的时间？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "当然。毕竟我已经做出选择了。我也不会再次在作出选择以后撒手离开了。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "接下来你有什么打算？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "留在这里，优化这个宇宙的模型。我想让新的文明更加平稳地诞生。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这很像是你会做的事。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "我姑且把你的这句话当作对我夸赞吧。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你可以这样认为。我也该走了，毕竟我只是一段过去的程序，而你是已经做出了选择的、新的Neumann。",
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
                dialogue = "（一段时间后。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "累死了......代码好难写啊。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（他刚刚完成对宇宙运行程序的优化，此刻正趴在桌上歇息。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（宇宙模型已经恢复运作有一段时间了。在这段时间里，他几乎一直呆在宇宙中控室里优化这个宇宙模型。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（在宇宙管理员的帮助下，修复模型在运行中产生的漏洞的压力也小了很多。漏洞产生的频率也越来越小了，这三天里他只遇到了一次报错，并且很快就修复好了它。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（等之后稍微闲了下来，或许可以出去走走......Neumann这样百无聊赖地想着。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（他实在是累昏了头，以至于宇宙中控室的大门被打开的时候他几乎没有察觉到门打开的声音。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（等他意识到中控室的大门被人打开了的时候，他已经能听到身后的人的呼吸声了）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "谁？",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "看起来你累得不行。你一直呆在这里吗？",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（声音熟悉得让Neumann感到不可置信。他回过头去，发现Damsel已经把脑袋凑到他的耳朵旁边、观察他好一阵子了。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "......我是不是累昏头了？明明我没有进入点阵视域。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "看起来你确实很累。去休息一会儿吧。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "不是假的......你真的回到现实里了？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。虽然经历了一些挫折，但我找到花园了。我就是在那里回到现实里来的。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "真好啊......咦，那你是怎么进到这里来的？宇宙中控室的大门应该只有我能打开。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你给过我授权。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "咦？什么时候？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "早在你刚开始运行这个宇宙模型之前。回到现实里的时候我也找回了之前的记忆，你还记得在你构建最初版的宇宙模型的时候，你闲着无聊编写的智能对话程序吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "当然记得......不会吧？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。那个程序就是我。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "怪不得......",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（这样一来，初遇Damsel时Neumann心里的那股莫名的熟悉感、Damsel会出现在点阵世界里的缘由，都清楚了。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（damsel本来就不存在于现实中。但是Neumann又把她编写进了这个宇宙模型里，还对她说——）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "——我希望你能成为这个宇宙的第一个生命。这是你当时对我说的话。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "这还真是......",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann已经不知道该说什么好。是该对这个奇迹表示惊讶？还是对Damsel回到现实中而表示欣喜？还是对故友重逢表示感动？）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（所有的这些情绪扭在了一起，Neumann张了张嘴，却什么话也说不出来了。）",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "先好好休息吧。看起来，之后还有很多工作要做。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "当然......还有很多事情等着我去弄。可以帮帮我吗？我一个人处理这些实在是有些太累。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselSmile,
                characterPosition = CharacterPosition.Right,
                dialogue = "乐意之至。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（简短的对话过后，中控室再次陷入了沉寂。Neumann趴回桌上睡了起来，而Damsel则坐在旁边托着腮观察着Neumann，像是她以前在小行星上、或是更久远的时候隔着液晶屏幕一样。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（而在中控室外，宇宙依然沉寂着，仿佛它也在进行午睡。但宇宙总有再次醒来的一天，它会在一个阳光明媚的下午再次开启旅程，向着那无限遥远的可能性。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（生命和旅途一样，都像是一场扮演着像素点、在名为时间的网格上行走的游戏。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（生命不息，旅途不止。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（我们终将与那个全新的可能性再次见面。）",
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
