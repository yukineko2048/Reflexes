using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Const;

public class TitleManager : SingletonMonoBehaviour<TitleManager>
{
    [SerializeField]
    private GameObject _CustomPanel;
    [SerializeField]
    private GameObject _CoinValue;
    [SerializeField]
    private GameObject _HighScoreValue;
    [SerializeField]
    private GameObject _Version;

    // ゲーム起動時処理(初期化)
    public void Initialize()
    {
        this._CoinValue.GetComponent<TextMeshProUGUI>().text = CoinManager.Instance.GetCoin().ToString();
        this._HighScoreValue.GetComponent<TextMeshProUGUI>().text = ScoreManager.Instance.GetHighScore().ToString();
        this._Version.GetComponent<Text>().text = CO.STRING_GAME_VERSION;
    }

    // コインの更新処理
    public void CoinUpdate()
    {
        this._CoinValue.GetComponent<TextMeshProUGUI>().text = CoinManager.Instance.GetCoin().ToString();
    }

    public void ActiveTrueCustomPanel()
    {
        this.SetActiveCustomPanel(true);
    }

    public void ActiveFalseCustomPanel()
    {
        this.SetActiveCustomPanel(false);
    }

    private void SetActiveCustomPanel(bool active)
    {
        this._CustomPanel.SetActive(active);
    }
}
