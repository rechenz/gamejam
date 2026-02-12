using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollyKill : MonoBehaviour
{
    public string HollyID;
    public bool isInRange = false;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            isInRange = false;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (SimpleStateManager.Instance.LoadBool(HollyID, "isKilled", false))
        {
            Destroy(transform.parent.gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!SimpleStateManager.Instance.LoadBool("Player", "AbleToKillBugs", false))
        {
            return;
        }
        if (isInRange && Input.GetKeyDown(KeyCode.E))
        {
            SimpleStateManager.Instance.SaveInt("Holly", "number", SimpleStateManager.Instance.LoadInt("Holly", "number", 0) + 1);
            SimpleStateManager.Instance.SaveBool(HollyID, "isKilled", true);
            Destroy(transform.parent.gameObject);
        }
    }
}
