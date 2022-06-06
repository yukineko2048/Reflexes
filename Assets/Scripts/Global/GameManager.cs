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
    private GameObject _PauseMenuPanel;
    private IGameTimer _IGameTimer;
    [SerializeField]
    private GameObject _GamePlayCanavs;
    [SerializeField]
    private GameObject _TitleCanavs;
    [NonSerialized] //using System publicだけどInspectorに出さないとき
    public bool _isRunning;

    void Start()
    {
        Screen.SetResolution(1080, 1920, false);
        this._isRunning = false;
        Application.targetFrameRate = CO.TARGET_FRAME_RATE;
        this._IGameTimer = _GameTimer.GetComponent<IGameTimer>();
        this._PauseButton.onClick.AddListener(this._IGameTimer.GamePause);
        this._ContinueButton.onClick.AddListener(this._IGameTimer.GameContinue);
        this._IGameTimer.InitTimer(CO.TIME_LIMIT);
        // スタートボタンが押されたタイミングに移動
        this.GameStart();
    }

    // アプリ起動時
    public void Initialize()
    {
        this._GamePlayCanavs.SetActive(false);
        this._TitleCanavs.SetActive(true);
    }

    // playgame押したときの処理
    public void GameStart()
    {
        // ゲーム開始(タイマースタート)
        this._IGameTimer.GameStart();
        this._isRunning = this._IGameTimer.IsRunning;
    }

    // ポーズボタン押されたときの処理
    public void GamePause()
    {
        Debug.Log("ポーズ");
        // ゲーム一時停止(タイマーストップ)
        this._isRunning = this._IGameTimer.IsRunning;
        // ポーズ画面を表示させる
        this.SetActivePauseMenuPanel(true);
    }

    // ポーズメニュー画面内のコンティニューボタンを押したときの処理
    public void GameContinue()
    {
        // ゲーム再開(タイマースタート)
        this._isRunning = this._IGameTimer.IsRunning;
        // ポーズ画面を表示させる
        this.SetActivePauseMenuPanel(false);
    }

    // ポーズメニュー画面内のリトライ、ギブアップ、タイマーフィニッシュしたときの処理
    public void GameFinish()
    {
        // ゲーム終了(タイマーフィニッシュ、ギブアップ、リトライ)
        this._isRunning = this._IGameTimer.IsRunning;
    }

    // ポーズメニュー画面の表示、非表示管理
    public void SetActivePauseMenuPanel(bool active)
    {
        this._PauseMenuPanel.SetActive(active);
    }
}
