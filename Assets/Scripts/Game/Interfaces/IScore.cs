using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IScore
{
    // スコアの値
    int ScoreValue { get; }
    // スコアを0にする
    void ScoreInitialize();
    // スコアを加算する処理
    void AddScore();
}
