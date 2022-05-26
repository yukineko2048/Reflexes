using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    [SerializeField]
    private GameObject _GameTimer;
    private IGameTimer _IGameTimer;

    void Start()
    {
        Application.targetFrameRate = CO.TARGET_FRAME_RATE;
        this._IGameTimer = _GameTimer.GetComponent<IGameTimer>();
        this._IGameTimer.InitTimer(CO.TIME_LIMIT);
        this._IGameTimer.GameStart();
    }

    public void GameStart()
    {
        // ゲーム開始(タイマースタート)

    }

    public void GameFinish()
    {
        // ゲーム終了(タイマーフィニッシュ、リタイア、リトライ)
        
    }
}
