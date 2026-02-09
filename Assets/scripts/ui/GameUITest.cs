using UnityEngine;
using Game.UI;

namespace Game.Test
{
    /// <summary>
    /// GameUI简单测试 - 按键盘按键测试功能
    /// </summary>
    public class GameUITest : MonoBehaviour
    {
        [Header("引用")]
        [SerializeField] private GameUI gameUI;
        
        [Header("测试设置")]
        [SerializeField] private int maxHP = 100;
        [SerializeField] private int damageAmount = 10;
        [SerializeField] private int healAmount = 10;
        [SerializeField] private int pointAmount = 100;
        
        private int currentHP;

        void Start()
        {
            // 自动查找GameUI（如果没拖入）
            if (gameUI == null)
                gameUI = FindObjectOfType<GameUI>();
            
            // 初始化
            gameUI.InitHP(maxHP);
            gameUI.InitPoint();
            currentHP = maxHP;
            
            Debug.Log("测试开始：按 H 加血，J 扣血，K 加分");
        }

        void Update()
        {
            // H键 - 加血
            if (Input.GetKeyDown(KeyCode.H))
            {
                currentHP = Mathf.Min(currentHP + healAmount, maxHP);
                gameUI.UpdateHP(currentHP);
                Debug.Log($"加血：{currentHP}/{maxHP}");
            }
            
            // J键 - 扣血
            if (Input.GetKeyDown(KeyCode.J))
            {
                currentHP = Mathf.Max(currentHP - damageAmount, 0);
                gameUI.UpdateHP(currentHP);
                Debug.Log($"扣血：{currentHP}/{maxHP}");
            }
            
            // K键 - 加分
            if (Input.GetKeyDown(KeyCode.K))
            {
                gameUI.AddPoint(pointAmount);
                Debug.Log($"当前分数：{gameUI.GetCurrentPoint()}");
            }
            
            // R键 - 重置
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentHP = maxHP;
                gameUI.InitHP(maxHP);
                gameUI.InitPoint();
                Debug.Log("重置完成");
            }
        }
    }
}