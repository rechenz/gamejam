using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue2 : MonoBehaviour
{
    public string DialogueID = "Dialogue002";
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
            // Destroy(gameObject);
            this.enabled = false;
        }
        else
        {
            SetBegin();
            StartDialogue();

            SimpleStateManager.Instance.SaveBool(DialogueID, "isRead", true);
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

    void StartDialogue()
    {
        List<DialogueLine> Dialogue = new List<DialogueLine>()
        {
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.Center,
                dialogue = "......早安。",
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（Neumann朝着城市的断壁残垣挥了挥手。他其实并不知道现在到底是不是“早晨”，毕竟古文明的时钟已经派不上用场了，这座废墟的昼夜模拟装置又早已失效。）"
            },
            new DialogueLine
            {
                characterName = "旁白",
                characterSprite = null,
                characterPosition = CharacterPosition.None,
                dialogue = "（他只是习惯性地向着这座废墟问候了一声。哪怕这座城市里的人都已经随着遥远的古文明变成了历史。他抬起头，古文明文献中的太阳并不在天空上。这里只是一处古文明破灭以后剩下的一小块浮岛，它原本的模样已经无从考据了。）"
            },
            new DialogueLine
            {
                characterName = "Neumann",
                characterSprite = NeumannNormal,
                characterPosition = CharacterPosition.None,
                dialogue = "......"
            }
        };
        DialogueManager.Instance.StartDialogue(Dialogue);
    }
}
