using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermove : MonoBehaviour
{
    public float xspeed = 5f;
    public float yspeed = 5f;
    public bool isspace = false;

    Transform Tr;
    // Start is called before the first frame update
    void Start()
    {
        Tr = GetComponent<Transform>();
    }

    void moveleft()
    {
        Tr.Translate(-xspeed * Time.deltaTime, 0, 0);
    }

    void moveright()
    {
        Tr.Translate(xspeed * Time.deltaTime, 0, 0);
    }

    void moveup()
    {
        Tr.Translate(0, yspeed * Time.deltaTime, 0);
    }

    void movedown()
    {
        Tr.Translate(0, -yspeed * Time.deltaTime, 0);
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.A))
        {
            moveleft();
        }
        if (Input.GetKey(KeyCode.D))
        {
            moveright();
        }
        if (isspace)
        {
            if (Input.GetKey(KeyCode.W))
            {
                moveup();
            }
            if (Input.GetKey(KeyCode.S))
            {
                movedown();
            }
        }
    }
}
