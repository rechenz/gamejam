using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossPassword : MonoBehaviour
{
    public GameObject canvas;
    public KeyCode interactionKey = KeyCode.F;
    public bool isInpointView;
    private bool playerInRange = false;

    void Start()
    {
        if (canvas != null)
            canvas.SetActive(false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = true;
            Debug.Log("靠近纸团，按 " + interactionKey + " 互动");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
            if (canvas != null)
                canvas.SetActive(false);
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(interactionKey))
        {
            if (canvas != null)
            {
                bool shouldActivate = !canvas.activeSelf;
                canvas.SetActive(shouldActivate);

                // 简单控制玩家
                GameObject player = GameObject.FindGameObjectWithTag("Player");
                if (player != null)
                {
                    MonoBehaviour[] scripts = player.GetComponents<MonoBehaviour>();
                    foreach (var script in scripts)
                    {
                        script.enabled = !shouldActivate;
                    }
                }
            }
        }
    }
}
