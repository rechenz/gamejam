using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dialogue16 : MonoBehaviour
{
    public string DialogueID = "Dialogue016";
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
    // Start is called before the first frame update
    void Start()
    {
        bool isRead = SimpleStateManager.Instance.LoadBool(DialogueID, "isRead", false);
        if (isRead)
        {
            Destroy(Learner);
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
                dialogue = "咦，前面好像有人。要上去看看吗？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我也看到了。啊，她的手里......",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "你看到了什么？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "她拿着的东西背面刻着很奇怪的密码。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "密码......会不会是古文明留下来的东西？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "应该是。过去看看吧。",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "......唉。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "你好，那个......",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "噫——！是谁？！",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "（小声）你吓到她了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannHelpless,
                characterPosition = CharacterPosition.Left,
                dialogue = "呃，那个......不好意思吓到你了。",
            },
            new DialogueLine
            {
                characterName = "？？？",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊......是生面孔。没关系的，只是拜托下次不要从背后叫我了......",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "非常抱歉，我还没在这个宇宙里遇到过几次人，所以刚才有些唐突了......请问你是？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "我的话，姑且算是一个宇宙考古学家吧。你是？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我叫Neumann，是一个路过这里的旅行家。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊，你是旅行家吗？",
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
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "那你是在寻找古文明的遗迹吗？不对，我该这样问：你有没有成功破解过古文明留下来的谜题？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "破解过一些，也得到过一些关于古文明的信息。你需要帮助吗？我看你好像很苦恼的样子。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。你能不能帮我看看这个？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "这个是，终端？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。这是我在一个很小的古文明太空实验舱里找到的，但是我没办法解锁它。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯......我来看看吧。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "【玩家接过了终端，并解开了上面的谜题。】",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（伴随着轻微的嗡鸣声，终端上显示的谜题变成光粒消散开。原本被谜题所保护着的信息也通过投影的形式出现在了Neumann的面前。）",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊！真的解开了！",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "能帮上忙真的是太好了。",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "（低声）上面说了什么？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我看看......好像是一个坐标？但我没办法辨认出这个坐标具体是在哪个位置。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "对，是一个坐标，但编码的方式不是我们现在用的形式。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "会不会是古文明自己的编码体系？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "很有可能。啊，我有一个提议。你要听吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "请说。",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "我准备带着它回到发现它的地方，这样或许可以弄明白这个坐标指的是哪里。我有一种预感，这个坐标很可能跟古文明的灭亡有关。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "感觉是一个可行的办法。但为什么会这样觉得？",
            },
            new DialogueLine
            {
                characterName = "考古学家",
                characterSprite = null,
                characterPosition = CharacterPosition.Right,
                dialogue = "你就当这是我们考古学家的预感吧。走吧！我带你去那里。到时候可能还需要你的帮助。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "回到太空实验舱，Neumann和考古学家一起离开了。"
            }
        };
        DialogueManager.Instance.OnDialogueEnd += OnDialogueFinished;
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        this.enabled = false;
    }
    private void OnDialogueFinished()
    {
        // 取消注册，防止内存泄漏
        DialogueManager.Instance.OnDialogueEnd -= OnDialogueFinished;

        // ✅ 在这里加载场景
        SceneManager.LoadScene("006");
    }

}
