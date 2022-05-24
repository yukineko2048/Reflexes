using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchObject
{
    Vector3 Position {get;set;}
    Quaternion Rotate {get;set;}
    Vector3 Scale {get;set;}
    bool IsMoving {get;}
    // オブジェクトがタッチされたときの処理
    void TouchedObject();
}
