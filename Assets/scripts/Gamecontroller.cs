using UnityEngine;
using Game.UI;

public class Gamecontroller : MonoBehaviour
{
    [Header("玩家属性")]
    [SerializeField] private int maxHP = 100;
    [SerializeField] private int maxShield = 50;
    
    private int currentHP;
    private int currentShield;

    void Start()
    {
        currentHP = maxHP;
        currentShield = maxShield;
        UpdateHPUI();
        UpdateShieldUI();
    }

    public void TakeDamage(int damage)
    {
        if (currentShield > 0)
        {
            int shieldDamage = Mathf.Min(currentShield, damage);
            currentShield -= shieldDamage;
            damage -= shieldDamage;
        }
        
        if (damage > 0)
        {
            currentHP = Mathf.Max(currentHP - damage, 0);
        }
        
        UpdateHPUI();
        UpdateShieldUI();
        
        if (currentHP <= 0) Die();
    }

    public void HealHP(int amount)
    {
        currentHP = Mathf.Min(currentHP + amount, maxHP);
        UpdateHPUI();
    }

    public void HealShield(int amount)
    {
        currentShield = Mathf.Min(currentShield + amount, maxShield);
        UpdateShieldUI();
    }

    private void UpdateHPUI()
    {
        if (GameUI.Instance != null)
            GameUI.Instance.SetHP(currentHP, maxHP);
    }

    private void UpdateShieldUI()
    {
        if (GameUI.Instance != null)
            GameUI.Instance.SetShield(currentShield, maxShield);
    }

    private void Die()
    {
        Debug.Log("玩家死亡");
    }
}