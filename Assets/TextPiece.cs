using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextPiece : MonoBehaviour
{
    public SpriteRenderer Sprite;
    public SpriteRenderer SpriteWithShadow;
    public KeyCode Interact;
    public Canvas Text;
    private bool isInrange;
    private bool isLooking;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpriteWithShadow.enabled = true;
            Sprite.enabled = false;
            isInrange = true;

        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            SpriteWithShadow.enabled = false;
            Sprite.enabled = true;
            isInrange = false;
            Text.enabled = false;
            isLooking = false;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpriteWithShadow.enabled = false;
        Sprite.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (isInrange && Input.GetKeyDown(Interact))
        {
            if (!isLooking)
            {
                Text.enabled = true;
                isLooking = true;
            }
            else
            {
                Text.enabled = false;
                isLooking = false;
            }
        }
    }
}
