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
        [SerializeField] private int maxPoint = 10;
        [SerializeField] private int damageAmount = 10;
        [SerializeField] private int healAmount = 10;
        [SerializeField] private int pointAmount = 1;
        
        private int currentHP;
        private int currentPoint;

        void Start()
        {
            // 自动查找GameUI（如果没拖入）
            if (gameUI == null)
                gameUI = FindObjectOfType<GameUI>();
            
            // 初始化
            currentHP = maxHP;
            currentPoint = maxPoint;
            
            gameUI.UpdateMaxHP(maxHP);
            gameUI.UpdateHP(currentHP);
            gameUI.SetPoint(currentPoint);
            
            Debug.Log("测试开始：按 H 加血，J 扣血，K 加Point，L 减Point，R 重置");
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
            
            // K键 - 加Point
            if (Input.GetKeyDown(KeyCode.K))
            {
                currentPoint += pointAmount;
                gameUI.SetPoint(currentPoint);
                Debug.Log($"当前Point：{gameUI.GetCurrentPoint()}");
            }
            
            // L键 - 减Point（模拟UpdateUI的消耗逻辑）
            if (Input.GetKeyDown(KeyCode.L))
            {
                if (currentPoint > 0)
                {
                    currentPoint -= 1;
                    gameUI.AddPoint(-1);
                }
                else
                {
                    currentHP = Mathf.Max(currentHP - 1, 0);
                    gameUI.UpdateHP(currentHP);
                }
                Debug.Log($"Point:{currentPoint}, HP:{currentHP}");
            }
            
            // R键 - 重置
            if (Input.GetKeyDown(KeyCode.R))
            {
                currentHP = maxHP;
                currentPoint = maxPoint;
                gameUI.UpdateMaxHP(maxHP);
                gameUI.UpdateHP(currentHP);
                gameUI.SetPoint(currentPoint);
                Debug.Log("重置完成");
            }
        }
    }
}