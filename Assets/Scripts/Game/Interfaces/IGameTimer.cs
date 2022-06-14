using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IGameTimer
{
    float TimeLimit { get; }

    float Timer { get; }

    bool IsRunning { get; }

    // タイマーの初期化機能
    // 初期化：タイマーの時間を初期時間にセットし、isStartをfalseにセットする
    void Initialize(float _timeLimit);
    // 開始準備が整い、開始することを告げる機能
    void GameStart();
    // ゲームポーズボタンを押したときの機能
    void GamePause();
    // コンティニューボタンを押したときの機能
    void GameContinue();
    // 制限時間が経過し、終了したことを告げる機能
    void GameFinish();
}
