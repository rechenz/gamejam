using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class pointView : MonoBehaviour
{
    public bool isInpointView;
    [Header("常规显示列表")]
    public List<SpriteRenderer> pointViewList1 = new List<SpriteRenderer>();
    public List<Behaviour> pointVeiwActive1 = new List<Behaviour>();

    public List<GameObject> pointVeiwAct1 = new List<GameObject>();
    [Header("特殊显示列表")]
    public List<SpriteRenderer> pointViewList2 = new List<SpriteRenderer>();
    public List<Behaviour> pointVeiwActive2 = new List<Behaviour>();
    public List<GameObject> pointVeiwAct2 = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        isInpointView = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            isInpointView = !isInpointView;
            ChangePointView();
        }
    }

    private void ChangePointView()
    {
        if (isInpointView)
        {
            foreach (SpriteRenderer pointView in pointViewList1)
            {
                pointView.enabled = false;
            }
            foreach (Behaviour pointView in pointVeiwActive1)
            {
                pointView.enabled = false;
            }
            foreach (GameObject pointView in pointVeiwAct1)
            {
                pointView.SetActive(false);
            }
            foreach (SpriteRenderer pointView in pointViewList2)
            {
                pointView.enabled = true;
            }
            foreach (Behaviour pointView in pointVeiwActive2)
            {
                pointView.enabled = true;
            }
            foreach (GameObject pointView in pointVeiwAct2)
            {
                pointView.SetActive(true);
            }
        }
        else
        {
            foreach (SpriteRenderer pointView in pointViewList1)
            {
                pointView.enabled = true;
            }
            foreach (Behaviour pointView in pointVeiwActive1)
            {
                pointView.enabled = true;
            }
            foreach (GameObject pointView in pointVeiwAct1)
            {
                pointView.SetActive(true);
            }
            foreach (SpriteRenderer pointView in pointViewList2)
            {
                pointView.enabled = false;
            }
            foreach (Behaviour pointView in pointVeiwActive2)
            {
                pointView.enabled = false;
            }
            foreach (GameObject pointView in pointVeiwAct2)
            {
                pointView.SetActive(false);
            }
        }
    }
}
