using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeSprite : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public Sprite sprite1;
    public Sprite sprite2;
    public charactermove charactermove;
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (charactermove.isspace)
        {
            spriteRenderer.sprite = sprite2;
        }
        else
        {
            spriteRenderer.sprite = sprite1;
        }
    }

}
