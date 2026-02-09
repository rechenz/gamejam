using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.UI
{
    /// <summary>
    /// 游戏主UI接口 - 管理HP和Point显示
    /// </summary>
    public class GameUI : MonoBehaviour
    {
        [Header("HP组件")]
        [SerializeField] private Image hpFillImage;
        [SerializeField] private TextMeshProUGUI hpText;
        
        [Header("Point组件")]
        [SerializeField] private TextMeshProUGUI pointText;
        
        // 当前数值（仅用于记录，不直接控制逻辑）
        private int currentHP;
        private int maxHP;
        private int currentPoint;
        
        #region HP接口
        
        /// <summary>
        /// 初始化HP显示
        /// </summary>
        /// <param name="max">最大HP值</param>
        public void InitHP(int max)
        {
            maxHP = max;
            currentHP = max;
            UpdateHPVisual();
        }
        
        /// <summary>
        /// 更新当前HP显示
        /// </summary>
        /// <param name="current">当前HP值</param>
        public void UpdateHP(int current)
        {
            currentHP = current;
            UpdateHPVisual();
        }
        
        /// <summary>
        /// 更新HP最大值（可选，用于升级等场景）
        /// </summary>
        /// <param name="newMax">新的最大HP值</param>
        public void UpdateMaxHP(int newMax)
        {
            maxHP = newMax;
            UpdateHPVisual();
        }
        
        /// <summary>
        /// 获取当前显示的HP值
        /// </summary>
        public int GetCurrentHP() => currentHP;
        
        /// <summary>
        /// 获取当前最大HP值
        /// </summary>
        public int GetMaxHP() => maxHP;
        
        #endregion
        
        #region Point接口
        
        /// <summary>
        /// 初始化分数显示
        /// </summary>
        public void InitPoint()
        {
            currentPoint = 0;
            UpdatePointVisual();
        }
        
        /// <summary>
        /// 设置当前分数
        /// </summary>
        /// <param name="point">分数值</param>
        public void SetPoint(int point)
        {
            currentPoint = point;
            UpdatePointVisual();
        }
        
        /// <summary>
        /// 增加分数
        /// </summary>
        /// <param name="amount">增加量</param>
        public void AddPoint(int amount)
        {
            currentPoint += amount;
            UpdatePointVisual();
        }
        
        /// <summary>
        /// 获取当前分数
        /// </summary>
        public int GetCurrentPoint() => currentPoint;
        
        #endregion
        
        #region 私有方法（视觉更新）
        
        private void UpdateHPVisual()
        {
            if (hpFillImage != null)
                hpFillImage.fillAmount = maxHP > 0 ? (float)currentHP / maxHP : 0;
            
            if (hpText != null)
                hpText.text = $"{currentHP}/{maxHP}";
        }
        
        private void UpdatePointVisual()
        {
            if (pointText != null)
                pointText.text = currentPoint.ToString();
        }
        
        #endregion
    }
}