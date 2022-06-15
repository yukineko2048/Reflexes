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
    [SerializeField]
    private GameObject _TitleCanavs;
    [SerializeField]
    private GameObject _TouchObject;
    [SerializeField]
    private GameObject _ResultCanavs;
    [NonSerialized] //using System publicだけどInspectorに出さないとき
    public bool _isRunning;

    private ITouchObject _ITouchObject;
    private IGameTimer _IGameTimer;
    private IMovingObjectOnRandom _IMovingObjectOnRandom;


    private void Start()
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

        // 初期化処理
        this.GameInitialize();

        // 初期化(ゲーム開始時はタイトル画面)
        this.Title();
    }

    // アプリ起動時
    public void Title()
    {
        this._TitleCanavs.SetActive(true);
        this._ResultCanavs.SetActive(false);
        TitleManager.Instance.Initialize();
    }

    // リザルト画面表示処理
    public void Result()
    {
        // 画面表示処理(ゲーム画面→リザルト画面)
        this._TitleCanavs.SetActive(false);
        this._ResultCanavs.SetActive(true);
        ResultManager.Instance.ShowResult();
    }    

    // playgame押したときの処理
    public void GameStart()
    {
        // **ゲーム開始**
        // ゲーム画面遷移
        this._TitleCanavs.SetActive(false);
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
        // 画面遷移
        this.Result();
        // ゲーム初期化
        this.GameInitialize();
    }

    // ポーズメニュー画面の表示、非表示管理
    public void SetActivePauseMenuPanel(bool active)
    {
        this._PauseMenuPanel.SetActive(active);
    }

    // ギブアップ処理
    public void GiveUp()
    {
        // ゲーム初期化
        this.GameInitialize();
        // タイトル画面へ遷移
        this._TitleCanavs.SetActive(true);
    }

    // リトライ処理
    public void Retry()
    {
        // ゲーム初期化
        this.GameInitialize();
        // 再スタート
        this.GameStart();
    }

    // ゲームのリセット処理(ゲームスタートをおしたらゲームが開始できる状態にする)
    private void GameInitialize()
    {
        ScoreManager.Instance.Initialize();
        this._IGameTimer.Initialize(CO.TIME_LIMIT);
        this.InitializeTouchObjectPos();
    }

    // タッチオブジェクトの座標初期化
    private void InitializeTouchObjectPos()
    {
        // オブジェクトの位置初期化(z座標は初期化に関係ないので今までと同じ値を用いる)
        var objPos = this._ITouchObject.Position;
        this._ITouchObject.Position = new Vector3(0, 0, objPos.z);
        // 計算用のオブジェクトの位置の値初期化
        this._IMovingObjectOnRandom.SetPosition(Vector3.zero);
    }
}
