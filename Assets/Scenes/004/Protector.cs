using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Protector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (!SimpleStateManager.Instance.LoadBool("Dialogue014", "isRead", false))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
