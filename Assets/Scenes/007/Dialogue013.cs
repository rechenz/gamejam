using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue013 : MonoBehaviour
{
    public string DialogueID = "Dialogue013";
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
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "呼！又搞定一个。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "辛苦了。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "我看看，储备还剩下一些。等我修完你们遇到的那些，我就得去回收一些资源来作为备用了。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "资源？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "嗯。就是太空里的无主小行星呀、小块的陨石呀、古文明留下来的太空垃圾呀，都是我需要的资源。因为修复宇宙漏洞需要很多的物质，所以经常要去专门寻找这些。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "原来是这样。之前你追着我们的小行星，也是想把它回收以后用作修补宇宙漏洞吧？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "当然。它们也可以用来做一些工艺品。我喜欢把合适的太空垃圾解构以后重组成花的样子。陨石如果形状合适的话，也可以直接用小刀来雕刻。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "很有趣的爱好呢。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "这么说起来，你们俩都有些什么爱好？我都把我的告诉你们了，让我听听你们的不过分吧？",
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "爱好吗？我的应该是在虚空里跳转圈舞。",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "感觉是个很符合你的身份的爱好。Neumann，你呢？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Left,
                dialogue = "呃，计算这个宇宙的大小算吗？",
            },
            new DialogueLine
            {
                characterName = "维护员",
                characterSprite = ProtecterSmile,
                characterPosition = CharacterPosition.Right,
                dialogue = "真是只有数学家才会有的爱好呢。",
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
        SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
        Done();
        this.enabled = false;
    }

}
