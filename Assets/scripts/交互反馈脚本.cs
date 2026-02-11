using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class 交互反馈脚本 : MonoBehaviour
{
    public SpriteRenderer sprite1;
    public SpriteRenderer sprite2;



    // Start is called before the first frame update
    void Start()
    {
        sprite1.enabled = true;
        sprite2.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sprite1.enabled = false;
            sprite2.enabled = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            sprite1.enabled = true;
            sprite2.enabled = false;
        }
    }
}
