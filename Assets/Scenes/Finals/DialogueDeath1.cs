using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DialogueDeath1 : MonoBehaviour
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
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "滋——"
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselNormal,
                characterPosition = CharacterPosition.Left,
                dialogue = "怎么了？"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Right,
                dialogue = "不知道，感觉不是很妙。"
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselSilent,
                characterPosition = CharacterPosition.Left,
                dialogue = "喂！你的身体——"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannPuzzled,
                characterPosition = CharacterPosition.Right,
                dialogue = "怎么了？"
            },
            new DialogueLine
            {
                characterName = "Damsel",
                characterSprite = DamselSilent,
                characterPosition = CharacterPosition.Left,
                dialogue = "你的点阵正在破碎——"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "声音骤然变得模糊不清。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "Neumann像是脑后挨了一记重锤一般，眼前猛地黑了一下，然后视野迅速地变成了全白。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "在意识和视野一样什么都不剩下之前，Neumann低下头，看向自己的手，却只看见了一团正在迅速解构的、变得混乱无序的点。"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "再往后他就什么也不知道了。因为能够支撑他思考的器官已经再也不能以器官的形式存在。很快，Neumann的存在会变成宇宙中的一团无人在意的原子，一点一点地逸散进整个宇宙当中。"
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
