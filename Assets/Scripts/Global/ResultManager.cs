using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ResultManager : SingletonMonoBehaviour<ResultManager>
{
    [SerializeField]
    private TextMeshProUGUI CoinValue;
    [SerializeField]
    private TextMeshProUGUI Score;
    [SerializeField]
    private TextMeshProUGUI HighScore;
    [SerializeField]
    private TextMeshProUGUI MaxCombo;
    [SerializeField]
    private TextMeshProUGUI TouchObjects;
    [SerializeField]
    private TextMeshProUGUI GetCoins;

    public void ShowResult()
    {
        // 所持コイン数表示
        this.CoinValue.text = CoinManager.Instance.GetCoin().ToString();
        // スコア表示
        this.Score.text = ScoreManager.Instance.ScoreValue.ToString();
        // ハイスコア表示
        this.HighScore.text = ScoreManager.Instance.GetHighScore().ToString();
        // マックスコンボ数表示
        this.MaxCombo.text = ScoreManager.Instance.MaxComboCount.ToString();
        // タッチオブジェクトカウント表示
        this.TouchObjects.text = ScoreManager.Instance.TouchObjectCount.ToString();
        // ゲットコイン数表示
        this.GetCoins.text = ScoreManager.Instance.MathGetCoins().ToString();

        // ハイスコア更新処理
        if (ScoreManager.Instance.ScoreValue > ScoreManager.Instance.GetHighScore())
        {
            Debug.Log("ハイスコア更新!!");
            ScoreManager.Instance.HighScoreUpdate(ScoreManager.Instance.ScoreValue);
        }

        // コイン取得処理(アニメーション)
        this.GetCoin();
    }

    private void GetCoin()
    {
        
        CoinManager.Instance.AddCoin(ScoreManager.Instance.MathGetCoins());
    }
}
