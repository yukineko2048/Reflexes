using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : SingletonMonoBehaviour<ScoreManager>
{
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
