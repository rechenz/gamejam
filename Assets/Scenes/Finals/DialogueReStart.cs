using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueReStart : MonoBehaviour
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
                dialogue = "重启吧。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "真的要这样吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "嗯。这个宇宙已经不存在可能性了......让他从头开始吧。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（说出这句话的同时，Neumann按下了重启键。大屏幕随之黑了下去，四周的嗡鸣声也接连安静了下去。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（而伴随着这些变化，中控室轻微地震动了起来——Neumann也感到了一阵强烈的眩晕感。）",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你已经做出了抉择。但是在这之前，宇宙模拟机需要冷却一段时间。它需要整理出这一循环的数据，然后自动规避掉可能发生的错误，从头开始运行这个宇宙模型。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我知道。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "但你已经成为这个宇宙的一部分了。所以你的故事也会跟着重新启动一次。真的没问题吗？",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "我知道。没问题的。",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "你真的已经做好了一切的准备。不愧是Neumann。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannSmile,
                characterPosition = CharacterPosition.Left,
                dialogue = "我可以当作是你在自夸吗？",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "随意。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（眩晕感更强烈了一些。Neumann不得不扶住桌子避免摔倒。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（眼前的景象正在变黑。Neumann的意识也是。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（在他渐渐昏沉下去的脑海中，几样特殊的物件突然出现在了他的眼前：奇特的古文明遗物、被雕刻上花朵纹样的陨石，以及一朵缥缈的蓝色玫瑰。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（然后，这些东西一点点地淡出了他的脑海。）",
            },
            new DialogueLine
            {
                characterName = "过去的Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Right,
                dialogue = "再见，未来的我。",
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "......再见。未来再见。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（再见了。）",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（希望在下一个循环里，我能够看见一个并未被毁灭的、真正的文明。）",
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
