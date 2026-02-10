using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using Game.UI;
using UnityEngine;

public class HollyBug : MonoBehaviour
{
    public float DeltaTime = 1f;
    private GameUI gameUI;
    private bool isInrange;
    private void Awake()
    {
        gameUI = GameUI.Instance;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInrange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInrange = false;
            Last = false;
        }
    }

    private void ifDeath()
    {
        SceneManager.LoadScene("DeathScene");
    }
    private void DecreaseBoth()
    {
        if (gameUI.GetCurrentPoint() > 0)
        {
            gameUI.AddPoint(-1);
        }
        else
        {
            gameUI.SetPoint(0);
        }
        if (gameUI.GetCurrentHP() > 0)
        {
            gameUI.UpdateHP(gameUI.GetCurrentHP() - 1);
        }
        if (gameUI.GetCurrentHP() == 0)
        {
            ifDeath();
        }
        SimpleStateManager.Instance.SaveInt("UI", "point", gameUI.GetCurrentPoint());
        SimpleStateManager.Instance.SaveInt("UI", "hp", gameUI.GetCurrentHP());
    }

    bool Last;
    float lastTime;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (isInrange)
            {
                if (Last != isInrange)
                {
                    DecreaseBoth();
                    Last = isInrange;
                }
                Last = true;
                if (Time.time - lastTime > DeltaTime)
                {
                    DecreaseBoth();
                    lastTime = Time.time;
                }
            }
        }
    }
}
