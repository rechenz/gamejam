using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UseKey : MonoBehaviour
{
    public bool isInRange;
    public Dialogue7 dialogue7;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isInRange = false;
        }
    }
    public void Use()
    {
        dialogue7.StartDialogue();
        SimpleStateManager.Instance.SaveBool("PasswordBox", "isOpen", true);
        Destroy(gameObject);
    }

    void Start()
    {
        if (SimpleStateManager.Instance.LoadBool("PasswordBox", "isOpen", false))
        {
            dialogue7.Set();
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange && Input.GetKeyDown(KeyCode.F) && SimpleStateManager.Instance.LoadBool("FileRoomKey", "hasKey", false))
        {
            Use();
        }
    }
}
