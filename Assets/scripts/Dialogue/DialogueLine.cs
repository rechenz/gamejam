using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public string characterName;          // 角色名
    public Sprite characterSprite;        // 立绘
    public CharacterPosition characterPosition; // 立绘位置
    public string dialogue;               // 对话内容
    public CharacterExpression expression = CharacterExpression.Normal; // 表情
    public AudioClip voiceClip;           // 语音（可选）
}

// 角色位置枚举
public enum CharacterPosition
{
    Left,
    Center,
    Right,
    None  // 不显示立绘
}

// 表情枚举
public enum CharacterExpression
{
    Normal,
    Happy,
    Angry,
    Sad,
    Surprised
}