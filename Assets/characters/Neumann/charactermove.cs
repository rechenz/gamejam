using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactermove : MonoBehaviour
{
    public float xspeed = 5f;
    public float yspeed = 5f;
    public bool isspace = false;
    Animator animator;
    Transform Tr;
    // Start is called before the first frame update
    void Start()
    {
        Tr = GetComponent<Transform>();
        animator = GetComponent<Animator>();
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

    void clear()
    {
        animator.SetBool("isstay", false);
        animator.SetBool("moveleft", false);
        animator.SetBool("moveright", false);
    }

    // Update is called once per frame
    void Update()
    {
        clear();
        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("moveleft", true);
            moveleft();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("moveright", true);
            moveright();
        }
        else
        {
            animator.SetBool("isstay", true);
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
