using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTouch : MonoBehaviour
{
    // ボタンを押したときtrue、離したときfalseになるフラグ
    private bool _downFlag = false;

    void Update()
    {
        if(Input.GetMouseButtonDown(0)) {
            OnTapDown();
        } else if(Input.GetMouseButtonUp(0)) {
            OnTapUp();
        }
        if (_downFlag){
            CheckTouchObject();
        }    
    }

    void CheckTouchObject(){
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray,out hit,10.0f))
        {
            TouchObjectManager.instance.TouchObject();
        }
        Debug.DrawRay(ray.origin, ray.direction * 10, Color.red, 5);
    }

    void OnTapDown(){
        _downFlag = true;
    }

    void OnTapUp(){
        _downFlag = false;
    }
}
