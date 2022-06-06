using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ITouchDecision
{
    bool DownFlag { get; }
    // タッチされているサイの処理
    void CheckTouchObject();
    // タッチ判定があった際の処理
    void OnTapDown();
    // タッチ判定が離れた際の処理
    void OnTapUp();
}
