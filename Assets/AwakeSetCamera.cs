using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeSetCamera : MonoBehaviour
{
    public Camera maincamera;
    void Awake()
    {
        maincamera = Camera.main;
        Canvas canvass = GetComponent<Canvas>();
        canvass.worldCamera = maincamera;
        canvass.sortingLayerName = "UI";
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
