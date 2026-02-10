using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutDoor : MonoBehaviour
{
    public Canvas GoOutDoor;
    // Start is called before the first frame update
    void Start()
    {
        GoOutDoor.enabled = false;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GoOutDoor.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GoOutDoor.enabled = false;
        }
    }
}
