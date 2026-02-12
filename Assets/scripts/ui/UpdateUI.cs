using System.Collections;
using System.Collections.Generic;
using Game.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UpdateUI : MonoBehaviour
{
    public float costTime = 15f; // 15s
    public pointView Sc;
    public int MaxPoint = 5;
    public int MaxHP = 3;
    private GameUI ui;
    private float lastTime = 0f;
    private bool isInpointView = false;
    private bool LastCondition = false;
    // Start is called before the first frame update
    void Start()
    {
        Sc = GameObject.FindWithTag("Player").GetComponent<pointView>();
        ui = GameObject.FindWithTag("UI").GetComponent<GameUI>();
        int Point = SimpleStateManager.Instance.LoadInt("UI", "point", -1);
        int HP = SimpleStateManager.Instance.LoadInt("UI", "hp", -1);
        if (Point == -1)
        {
            ui.SetPoint(MaxPoint);
        }
        else
        {
            ui.SetPoint(Point);
        }
        if (HP == -1)
        {
            ui.UpdateMaxHP(MaxHP);
            ui.UpdateHP(MaxHP);
        }
        else
        {
            ui.UpdateHP(HP);
        }
    }

    public void ifDeath()
    {
        SceneManager.LoadScene("DeathScene");
    }

    public void PointDecrease()
    {
        if (ui.GetCurrentPoint() > 0)
        {
            ui.AddPoint(-1);
        }
        else
        {
            ui.UpdateHP(ui.GetCurrentHP() - 1);
        }
        if (ui.GetCurrentHP() == 0)
        {
            ifDeath();
        }
        SimpleStateManager.Instance.SaveInt("UI", "point", ui.GetCurrentPoint());
        SimpleStateManager.Instance.SaveInt("UI", "hp", ui.GetCurrentHP());
    }

    // Update is called once per frame
    void Update()
    {
        isInpointView = Sc.isInpointView;
        if (!isInpointView) return;
        if (isInpointView && !LastCondition)
        {
            PointDecrease();
            lastTime = Time.time;
        }
        LastCondition = isInpointView;
        if (Time.time - lastTime > costTime)
        {
            PointDecrease();
            lastTime = Time.time;
        }
    }
}
