using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue010 : MonoBehaviour
{
    public string DialogueID = "Dialogue010";
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
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（咔哒。）\n（锁被打开了。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Center,
                dialogue = "但是......唔，打不开。怎么会这样？",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann试图寻找箱子上的其他机关，但失败了。这个箱子的构造并不允许它拥有多么复杂的锁定系统，或许是哪里还有一个简单但极其有效的锁？）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann晃了晃箱子。直接破坏是不可能的，古文明的材料科技相当发达，这个箱子的坚实程度恐怕跟这座建筑差不到哪去。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（但也就在这时，Neumann听到了不用知道从哪里传来的、相当遥远的声音。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Center,
                dialogue = "歌声......？从哪里传出来的？",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann抬起头来，四处寻找声音的来源。无奈那声音实在太过飘渺，他没有办法定位声音的源头方向。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（但也因为这一轮扫视，他发现了一个先前并没有在这个房间里、也不应该出现在这里的东西。）\n（一枝蓝色的、没有影子的玫瑰。）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Center,
                dialogue = "玫瑰？为什么能飘在空中？",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann仔细观察着这朵不同寻常的玫瑰。它是飘着的，但这座废墟的重力设施明明还在运作；此外它也没有落在地上的影子，仿佛它只是一个......）",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Center,
                dialogue = "......投影？但是，这个是什么的投影？",
            },
            new DialogueLine
            {
                characterName = "???",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "啊。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannAmazed,
                characterPosition = CharacterPosition.Center,
                dialogue = "为什么玫瑰会说话？",
            },
            new DialogueLine
            {
                characterName = "???",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你能看到我？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Center,
                dialogue = "你是谁？刚才是你在唱歌吗？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我是Damsel。既然你能进到这里来，就说明你肯定能看到我在的这个世界。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Center,
                dialogue = "你所在的世界......？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselSmile,
                characterPosition = CharacterPosition.Right,
                dialogue = "你能看到由点阵表达出来的世界吧？那个所有存在都是点阵构造体的世界。假如你真的能够从那个视角观察世界的话，不如试试从那个视角去观察你眼前的这朵玫瑰——这样你就能看到真正的我了。",
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
    }
}
