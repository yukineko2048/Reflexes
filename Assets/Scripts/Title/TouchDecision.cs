using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class TouchDecision : MonoBehaviour, ITouchDecision
{
    [SerializeField]
    private GameObject _TouchObject;
    private ITouchObject _ITouchObject;
    // ボタンを押したときtrue、離したときfalseになるフラグ
    private bool _downFlag = false;

    public bool DownFlag
    {
        get { return this._downFlag; }
    }

    private void Start()
    {
        this._ITouchObject = this._TouchObject.GetComponent<ITouchObject>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            this.OnTapDown();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            this.OnTapUp();
        }
        if (this._downFlag)
        {
            this.CheckTouchObject();
        }
    }

    public void CheckTouchObject()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        Debug.Log("hoge");
        if (Physics.Raycast(ray, out hit, CO.RAYCAST_MAX_DISTANCE)
         && this._TouchObject.tag == hit.collider.gameObject.tag)
        {
            this._ITouchObject.TouchedObject();
            Debug.Log("hoge");
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
    }

    public void OnTapDown()
    {
        this._downFlag = true;
    }

    public void OnTapUp()
    {
        this._downFlag = false;
    }
}
