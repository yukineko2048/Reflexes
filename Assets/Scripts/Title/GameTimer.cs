using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class GameTimer : MonoBehaviour, IGameTimer
{
    [SerializeField]
    private Image _TimerCircle_front;
    [SerializeField]
    public TextMeshProUGUI _TimerText;
    // 設定する制限時間
    private float _timeLimit;
    // 現在の時間
    private float _timer;
    // ゲームが進行しているかどうか
    private bool _isRunning;

    public float TimeLimit
    {
        get { return this._timeLimit; }
    }
    public float Timer
    {
        get { return this._timer; }
    }
    public bool IsRunning
    {
        get { return this._isRunning; }
    }
    public void InitTimer(float _timeLimit) {
        this._timeLimit = _timeLimit;
        this._timer = this._timeLimit;
        this._isRunning = false;
        this._TimerText.text = this._timer.ToString("f0");
    }
    public void GameStart() {
        Debug.Log("開始");
        this._isRunning = true;
    }
    public void GameFinish() {
        Debug.Log("終了");
        this._isRunning = false;
    }
    private void FixedUpdate() {
        // ゲーム中
        if (this._isRunning && this._timer > 0.0f) {
            this._timer -= Time.deltaTime;
            var fillAmountValue = this._timer / this._timeLimit;
            this._TimerText.text = Mathf.Ceil(this._timer).ToString("f0");
            this._TimerCircle_front.fillAmount = fillAmountValue;
        }
        // ゲーム終了
        else if (this._isRunning && this._timer <= 0.0f) {
            this.GameFinish();
        }
    }
}
