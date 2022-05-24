using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class GameManager : SingletonMonoBehaviour<GameManager>
{
    public GameObject Timer;
    private GameTimer _gameTimer;

    void Start()
    {
        Application.targetFrameRate = CO.TARGET_FRAME_RATE;
        this._gameTimer = Timer.GetComponent<GameTimer>();
        this._gameTimer.InitTimer(CO.TIME_LIMIT);
        this._gameTimer.GameStart();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
