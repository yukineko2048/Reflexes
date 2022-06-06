using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;
using TMPro;

public class Score : MonoBehaviour, IScore
{
    [SerializeField]
    private TextMeshProUGUI _ScoreCount;
    private int _scoreValue = 0;

    public int ScoreValue
    {
        get { return this._scoreValue; }
    }

    private void Start()
    {
        this.UpdateScore();
    }

    public void ScoreInitialize()
    {
        this._scoreValue = 0;
        this.UpdateScore();
    }

    public void AddScore()
    {
        this._scoreValue += CO.ADD_SCORE;
        this.UpdateScore();
    }

    public void UpdateScore()
    {
        this._ScoreCount.text = this._scoreValue.ToString();
    }
}
