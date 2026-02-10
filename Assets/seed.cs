using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seed : MonoBehaviour
{


    private bool isInRange;
    // Start is called before the first frame update
    void Start()
    {
        bool hasSeed = SimpleStateManager.Instance.LoadBool("Seed", "hasSeed", false);
        if (hasSeed)
        {
            getPicked();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            isInRange = false;
        }
    }

    private void getPicked()
    {
        SimpleStateManager.Instance.SaveBool("Seed", "hasSeed", true);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                getPicked();
            }
        }
    }
}
