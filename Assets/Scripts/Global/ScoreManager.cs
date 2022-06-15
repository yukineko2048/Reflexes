using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;
using TMPro;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
    [SerializeField]
    private TextMeshProUGUI _ScoreCount;
    private int _scoreValue = 0;
    private int _comboCount = 0;
    private int _maxComboCount = 0;
    private int _touchObjectCount = 0;

    public int ScoreValue
    {
        get { return this._scoreValue; }
    }

    public int MaxComboCount
    {
        get { return this._maxComboCount; }
    }

    public int TouchObjectCount
    {
        get { return this._touchObjectCount; }
    }

    private void Start()
    {
        this.UpdateScore();
    }

    public void Initialize()
    {
        this._scoreValue = 0;
        this._comboCount = 0;
        this._maxComboCount = 0;
        this._touchObjectCount = 0;
        this.UpdateScore();
    }

    public void AddScore(int comboFrame)
    {
        // 共通処理
        ++this._touchObjectCount;
        // コンボ猶予フレームをオーバーしたのでコンボを途切れさせる
        if (comboFrame < 0)
        {
            this._comboCount = 0;
            this._scoreValue += CO.ADD_SCORE;
            ++this._comboCount;
        }
        else
        {
            ++this._comboCount;
            this._scoreValue += (int)(comboFrame * CO.ADD_SCORE * (this._comboCount * CO.COMBO_MAGNIFICATION + 1));
            Debug.Log($"コンボ!!{this._comboCount}");
        }
        if (this._comboCount > this._maxComboCount)
        {
            this._maxComboCount = this._comboCount;
        }
        this.UpdateScore();
    }

    public void UpdateScore()
    {
        this._ScoreCount.text = this._scoreValue.ToString();
    }

    // ハイスコア更新
    public void HighScoreUpdate(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
    }

    // ハイスコアを返す
    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    // スコアから獲得コイン数を計算する
    public int MathGetCoins()
    {
        // テスト中
        return TEST.GETCOINS;
    }
}
