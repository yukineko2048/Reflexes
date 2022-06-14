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

    public int ScoreValue
    {
        get { return this._scoreValue; }
    }

    private void Start()
    {
        this.UpdateScore();
    }

    public void Initialize()
    {
        this._scoreValue = 0;
        this._comboCount = 0;
        this.UpdateScore();
    }

    public void AddScore(int comboFrame)
    {
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
}
