using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private Button _PauseButton;
    [SerializeField]
    private Button _ContinueButton;
    [SerializeField]
    private GameObject _GameTimer;
    [SerializeField]
    private GameObject _FrontCanvas;
    private IGameTimer _IGameTimer;
    [NonSerialized] //using System publicだけどInspectorに出さないとき
    public bool _isRunning;

    void Start()
    {
        
        this._isRunning = false;
        Application.targetFrameRate = CO.TARGET_FRAME_RATE;
        this._IGameTimer = _GameTimer.GetComponent<IGameTimer>();
        this._PauseButton.onClick.AddListener(this._IGameTimer.GamePause);
        this._ContinueButton.onClick.AddListener(this._IGameTimer.GameContinue);
        this._IGameTimer.InitTimer(CO.TIME_LIMIT);
        this._IGameTimer.GameStart();
    }

    public void GameStart()
    {
        // ゲーム開始(タイマースタート)
        this._isRunning = this._IGameTimer.IsRunning;
    }

    public void GamePause()
    {
        // ゲーム一時停止(タイマーストップ)
        this._isRunning = this._IGameTimer.IsRunning;
        // ポーズ画面を表示させる
        this._FrontCanvas.SetActive(true);
    }

    public void GameContinue()
    {
        // ゲーム再開(タイマースタート)
        this._isRunning = this._IGameTimer.IsRunning;
        // ポーズ画面を表示させる
        Debug.Log("asd");
        this._FrontCanvas.SetActive(false);
    }

    public void GameFinish()
    {
        // ゲーム終了(タイマーフィニッシュ、リタイア、リトライ)
        this._isRunning = this._IGameTimer.IsRunning;
    }
}
