using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue22 : MonoBehaviour
{
    public string DialogueID = "Dialogue022";
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
                dialogue = "咚。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "一声轻响过后，终端的屏幕彻底亮了起来。随后，Neumann找到了他一直在寻找的东西。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "一些过往。他全部的过往。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "这个是......？"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "为什么这上面会有他的名字？那个被他记得死死的名字Conway也在上面？模拟宇宙实验是什么？"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannHelpless,
                characterPosition = CharacterPosition.Left,
                dialogue = "Neumann有些混乱。也就在这个时候，音响里响起了奇怪的声音。"
            },
            new DialogueLine
            {
                characterName = "???",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "啊，你回来了。欢迎回来。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "谁？！"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "Neumann下意识后退了两步，随后他发现音响里的声音和他自己的十分相似。这令他感到相当惊异，心里也多了一份将要抵达真相的紧张感。"
            },
            new DialogueLine
            {
                characterName = "???",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "你忘了吗？我是你，在来到这个宇宙前的你。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "我？"
            },
            new DialogueLine
            {
                characterName = "???",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "啊，是我忘了。你在进入这个宇宙之前把自己所有的记忆都留在了这里。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "进入这个宇宙之前？"
            },
            new DialogueLine
            {
                characterName = "???",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "当然。这个宇宙是我——是过去的你所创造的。你不是看到了吗？就在你面前的屏幕上，所有的记录都在这里。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Left,
                dialogue = "你是说，这上面的Neumann，真的是我......？"
            },
            new DialogueLine
            {
                characterName = "???",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "当然。不过准确的说，是我，也是过去的你。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "骗人的吧......"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "我为什么要骗你？我在这里等你已经很久了。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "为什么？"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "因为当你回来的时候，你就已经到了做出抉择的时候——你要怎么对待这个宇宙的未来？"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannHelpless,
                characterPosition = CharacterPosition.Left,
                dialogue = "......能跟我说说以前的事情吗？我现在的脑子好混乱。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "当然。你想知道什么？这个宇宙的由来？还是你的过去？"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "先说这个宇宙的由来吧。在我的记忆里，这个宇宙是被一个叫Conway的人创造的——但是我并不知道也没办法相信我也是这个宇宙的创造者。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "你当然是，Conway也是。在很久以前，Neumann提出了一个的宇宙模型。这个模型能够演化出文明发展的历程。随后Neumann的好朋友Conway与他合作，两个人将自己的全部心血投入了一场模拟实验，并真正模拟出了那个宇宙模型——也就是你脚下的那个小小的宇宙。这个宇宙的真正创造者其实是你，因为你最先构建了它的框架，随后模拟并创造出了这个宇宙的文明。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "那我为什么会到这里来？"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "我想你应该知道为什么。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "是因为外面的那些宇宙漏洞？"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "当然。在模型运行了一段时间后，Neumann发现这个宇宙模型开始报错——尽管他第一时间便开始了修复工作，但后来这样的报错越来越多，模拟出的宇宙也变得千疮百孔。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "再到后来的某一天，Neumann和Conway发现，这个模拟宇宙中的那个已经很发达的文明，突然灭亡了。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "......"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "这场灭亡来得猝不及防，因为在原先的预想中，宇宙模型中出现的漏洞虽然会影响它的运转，但并不能导致模拟文明的直接灭亡。Neumann在实验台前几乎崩溃得大喊了出来，Conway则反应迅速地按下了暂停键，让宇宙模型暂停在了模拟文明毁灭后的第三秒。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "随后Neumann做出了一个决定。一个疯狂的决定。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "他决定把自己编译进这个宇宙模型中，去寻找在这个模拟出来的宇宙中，能够让文明安宁地生存下来的办法。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "......"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "现在Neumann知道为什么他在看到古文明灭亡时的图像模拟会感到莫名的心痛了。因为那曾经是他的毕生心血。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "做出这个决定很不容易。当时研究所的所有人都在极力阻止Neumann，只有Conway在听了Neumann的计划后一言不发，连续加班几天研究出了模拟宇宙的自主修复程序、并将它编写进了这个宇宙模型里。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "在一切都安排妥当后，Neumann构建出了这个宇宙中控室，并把自己编译进了这个宇宙模型里。这就是Neumann的故事——你一直在寻找的过去。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "真是......悲哀的故事。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "Neumann不知道用什么样的词汇来形容此刻自己的心情。他是该感到悲哀还是荒诞呢？他不知道。因为他知道这些都是真的。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "古文明的灭亡是真的。宇宙变得千疮百孔是真的。他付之一炬的心血是真的，另外，他在悲哀中做出的疯狂决定也是真的。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "但在这些悲哀的真相面前，他反而不知道应该怎样才好了。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "在他的脚下，这个宇宙沉默着。没有太阳能照亮黑暗的银河，就像是古文明故事书上的所谓阳光再也不会落到古文明的废墟上。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "宇宙沉默着，他沉默着。他的沉默在他所创造的宇宙中渺小得不值一提。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "或许像现在这样傻傻地站在原地，拼尽全力去消化这些真相......才是此刻最合适的、也是他唯一能做出的应对方式。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "好了，我的故事讲完了。现在该轮到你作出选择了。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "选择.......？"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "如你所见，这个宇宙中的文明已经灭绝，再将这个宇宙模型运转下去已经毫无意义。但你已经用自己的双腿走过了这个宇宙，或许，你已经对它有了一些在期望之外的、别的感情。但时间已经不多，你已经遇到过那位在宇宙中四处修复漏洞的程序了吧？他应该告诉过你，这个宇宙中的漏洞依然在增加。即便对文明的模拟已经停止，但宇宙模型在自我运算的过程中依然在不断产生错误。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "你当然也有权暂时保持沉默。但是如果拖延太久，时间会替你做出选择。这个宇宙模型会崩溃。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannWounded,
                characterPosition = CharacterPosition.Left,
                dialogue = "......"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "所以，依照你在来到这个宇宙之前留下的协议，我把最终的选择权交到你的面前。"
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "是要让这个宇宙模型从头开始运算，还是就这样让它继续延续下去？"
            }
        };
        DialogueManager.Instance.OnDialogueEnd += ToChoice;
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        this.enabled = false;
    }

    private void ToChoice()
    {
        DialogueManager.Instance.OnDialogueEnd -= ToChoice;
        SceneManager.LoadScene("EndsChoice");
    }

}
