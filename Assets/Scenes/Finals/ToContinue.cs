using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ToContinue : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (SimpleStateManager.Instance.LoadBool("Damsel", "isLeft", false))
        {
            SceneManager.LoadScene("Continue2");
        }
        else
        {
            SceneManager.LoadScene("Continue1");
        }
    }
}
