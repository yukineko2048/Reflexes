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
    [SerializeField]
    private GameObject _TouchObject;
    private ITouchObject _ITouchObject;
    private IMovingObjectOnRandom _IMovingObjectOnRandom;
    [NonSerialized] //using System publicだけどInspectorに出さないとき
    public bool _isRunning;

    void Start()
    {
        Screen.SetResolution(1080, 1920, false);
        Application.targetFrameRate = CO.TARGET_FRAME_RATE;
        this._ITouchObject = this._TouchObject.GetComponent<ITouchObject>();
        this._IMovingObjectOnRandom = this._TouchObject.GetComponent<IMovingObjectOnRandom>();
        this._IGameTimer = _GameTimer.GetComponent<IGameTimer>();
        this._PauseButton.onClick.AddListener(this._IGameTimer.GamePause);
        this._ContinueButton.onClick.AddListener(this._IGameTimer.GameContinue);
        this._IGameTimer.Initialize(CO.TIME_LIMIT);
        this._isRunning = this._IGameTimer.IsRunning;
        // スタートボタンが押されたタイミングに移動
        // this.GameStart();

        // 初期化
        this.Initialize();
    }

    // アプリ起動時
    public void Initialize()
    {
        // this._GamePlayCanavs.SetActive(false);
        // this._TitleCanavs.SetActive(true);
        TitleManager.Instance.Initialize();
    }

    // playgame押したときの処理
    public void GameStart()
    {
        // **ゲーム開始**
        // ゲーム画面遷移
        this._TitleCanavs.SetActive(false);
        // 初期化処理

        // タイマースタート
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

    // ギブアップ処理
    public void GiveUp()
    {
        // タイマー初期化
        this._IGameTimer.Initialize(CO.TIME_LIMIT);
        this._isRunning = this._IGameTimer.IsRunning;
        // スコア、コンボ初期化
        ScoreManager.Instance.Initialize();
        // オブジェクトの位置初期化(z座標は初期化に関係ないので今までと同じ値を用いる)
        var objPos = this._ITouchObject.Position;
        this._ITouchObject.Position = new Vector3(0,0,objPos.z);
        // 計算用のオブジェクトの位置の値初期化
        this._IMovingObjectOnRandom.SetPosition(Vector3.zero);
        // 初期化が終わったのでタイトル画面へ遷移
        this._TitleCanavs.SetActive(true);
    }

    // リトライ処理
    public void Retry()
    {
        // タイマー初期化
        this._IGameTimer.Initialize(CO.TIME_LIMIT);
        this._isRunning = this._IGameTimer.IsRunning;
        // スコア、コンボ初期化
        ScoreManager.Instance.Initialize();
        // オブジェクトの位置初期化(z座標は初期化に関係ないので今までと同じ値を用いる)
        var objPos = this._ITouchObject.Position;
        this._ITouchObject.Position = new Vector3(0,0,objPos.z);
        // 計算用のオブジェクトの位置の値初期化
        this._IMovingObjectOnRandom.SetPosition(Vector3.zero);
        // 初期化が終わったので再スタート
        this.GameStart();
    }
}
