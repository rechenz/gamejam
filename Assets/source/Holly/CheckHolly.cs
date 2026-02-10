using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckHolly : MonoBehaviour
{
    public bool isHolly = false;
    public string Hollyname;
    public bool enable;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHolly = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            isHolly = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        enable = SimpleStateManager.Instance.LoadBool("Player", "isSeed", false);
    }

    // Update is called once per frame
    void Update()
    {
        if (!enable) return;
        if (Input.GetKeyDown(KeyCode.E) && isHolly)
        {
            SimpleStateManager.Instance.SaveBool(Hollyname, "isTag", true);
        }
    }
}
