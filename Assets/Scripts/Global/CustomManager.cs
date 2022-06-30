using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CustomManager : SingletonMonoBehaviour<CustomManager>
{
    [SerializeField]
    private GameObject _ObjectColor;
    [SerializeField]
    private GameObject _BackColor;
    [SerializeField]
    private GameObject _Sound;
    // カスタム画面で使用する共通ボタン
    public GameObject _PrefabButton;
    // コインテキスト
    [SerializeField]
    private TextMeshProUGUI CoinValue;

    // CustomButtonGenerateは一度しか呼びたくないのでそのフラグ用
    private bool once = false;

    public void CustomButtonGenerate()
    {
        if (once) return;
        once = true;
        // Instantiateでボタンの生成
        this._ObjectColor.GetComponent<ISelectButton_ObjectColor>().InstantiateButton();
        this._BackColor.GetComponent<ISelectButton_BackColor>().InstantiateButton();
        this._Sound.GetComponent<ISelectButton_Sound>().InstantiateButton();

        // PlayerPrefsからユーザーが選択していた情報を取得
        var objectColorPrefs = PlayerPrefs.GetInt("ObjectColor", 0);
        var backPanelColorPrefs = PlayerPrefs.GetInt("BackPanelColor", 0);
        var soundPrefs = PlayerPrefs.GetInt("Sound", 0);

        // 
    }
}
