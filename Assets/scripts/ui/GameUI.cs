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
        // 单例
        public static GameUI Instance { get; private set; }
        
        [Header("HP组件")]
        [SerializeField] private Image hpFillImage;
        [SerializeField] private TextMeshProUGUI hpText;
        
        [Header("Point组件")]
        [SerializeField] private TextMeshProUGUI pointText;

        // 内部存储的数值（供Get方法使用）
        private int currentHP;
        private int maxHP;
        private int currentPoint;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(gameObject);
                return;
            }
            Instance = this;
        }

        #region HP接口

        /// <summary>
        /// 设置HP显示（新接口，GameController用）
        /// </summary>
        public void SetHP(int current, int max)
        {
            currentHP = current;
            maxHP = max;
            UpdateHPVisual();
        }

        /// <summary>
        /// 更新当前HP
        /// </summary>
        public void UpdateHP(int current)
        {
            currentHP = current;
            UpdateHPVisual();
        }

        /// <summary>
        /// 更新最大HP
        /// </summary>
        public void UpdateMaxHP(int max)
        {
            maxHP = max;
            UpdateHPVisual();
        }

        /// <summary>
        /// 获取当前HP
        /// </summary>
        public int GetCurrentHP() => currentHP;

        /// <summary>
        /// 获取最大HP
        /// </summary>
        public int GetMaxHP() => maxHP;

        #endregion

        #region Point接口

        /// <summary>
        /// 设置Point（新接口）
        /// </summary>
        public void SetPoint(int point)
        {
            currentPoint = point;
            UpdatePointVisual();
        }

        /// <summary>
        /// 增加/减少Point
        /// </summary>
        public void AddPoint(int amount)
        {
            currentPoint += amount;
            UpdatePointVisual();
        }

        /// <summary>
        /// 获取当前Point
        /// </summary>
        public int GetCurrentPoint() => currentPoint;

        #endregion

        #region 护盾接口（新增，GameController用）

        /// <summary>
        /// 设置护盾显示
        /// </summary>
        public void SetShield(int current, int max)
        {
            // 用PointText显示护盾值
            if (pointText != null)
                pointText.text = $"{current}/{max}";
        }

        #endregion

        #region 私有方法

        private void UpdateHPVisual()
        {
            if (hpFillImage != null)
                hpFillImage.fillAmount = (float)currentHP / maxHP;
    
            if (hpText != null)
                hpText.text = currentHP.ToString();  // 只显示100，不是100/100
        }

        private void UpdatePointVisual()
        {
            if (pointText != null)
                pointText.text = currentPoint.ToString();
        }

        #endregion
    }
}