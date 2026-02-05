// 在游戏中任何地方触发对话
// public void StartExampleDialogue()
// {
//     // 创建对话列表
//     List<DialogueLine> dialogueLines = new List<DialogueLine>()
//     {
//         new DialogueLine()
//         {
//             characterName = "主角",
//             characterSprite = Resources.Load<Sprite>("Sprites/Character_Hero"),
//             characterPosition = CharacterPosition.Left,
//             dialogue = "这里发生了什么？",
//             expression = CharacterExpression.Surprised
//         },
//         new DialogueLine()
//         {
//             characterName = "NPC",
//             characterSprite = Resources.Load<Sprite>("Sprites/Character_NPC"),
//             characterPosition = CharacterPosition.Right,
//             dialogue = "小心！怪物要来了！",
//             expression = CharacterExpression.Angry
//         },
//         new DialogueLine()
//         {
//             characterName = "系统",
//             characterSprite = null,
//             characterPosition = CharacterPosition.None,
//             dialogue = "战斗即将开始...",
//             expression = CharacterExpression.Normal
//         }
//     };

//     // 开始对话
//     DialogueSystem.Instance.StartDialogue(dialogueLines);
// }