using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuyWindow : MonoBehaviour, IBuyWindow
{
    private TextMeshProUGUI _IndexText;
    private TextMeshProUGUI _PriceText;
    private TextMeshProUGUI _SubCoins;
    private Button _OkButton;
    private Button _CancelButton;

    private void Start()
    {
        this._IndexText = this.gameObject.transform.Find("Panel/IndexText").gameObject.GetComponent<TextMeshProUGUI>();
        this._PriceText = this.gameObject.transform.Find("Panel/PriceText").gameObject.GetComponent<TextMeshProUGUI>();
        this._SubCoins = this.gameObject.transform.Find("Panel/SubCoins").gameObject.GetComponent<TextMeshProUGUI>();
        this._OkButton = this.gameObject.transform.Find("Panel/OkButton").gameObject.GetComponent<Button>();
        this._CancelButton = this.gameObject.transform.Find("Panel/CancelButton").gameObject.GetComponent<Button>();
    }

    private void BuyWindowSetActive(bool flag)
    {
        foreach (Transform tra in this.gameObject.transform)
        {
            tra.gameObject.SetActive(flag);
        }
    }

    public void ShowBuyWindow(string typeText, int value, Transform child, int index)
    {
        this._IndexText.text = typeText;
        this._PriceText.text = value.ToString();
        var subCoinValue = CoinManager.Instance.GetCoin() - value;
        // 今の手持ちでその商品が買えるかどうか
        if (subCoinValue < 0)
        {
            this._OkButton.interactable = false;
        }
        else
        {
            this._OkButton.interactable = true;
            this._OkButton.onClick.RemoveAllListeners();
            this._OkButton.onClick.AddListener(() => this.BuyOk(value, child, index));
        }
        this._SubCoins.text = subCoinValue.ToString();
        // buyWindowのボタン押下処理
        this._CancelButton.onClick.AddListener(this.BuyCancel);
        this.BuyWindowSetActive(true);
    }

    public void BuyOk(int coins, Transform child, int index)
    {
        CoinManager.Instance.SubCoin(coins);
        this.BuyWindowSetActive(false);
        // ボタンをアンロックする
        child.parent.gameObject.SetActive(false);
        child.parent.parent.GetComponent<Button>().interactable = true;
        child.parent.parent.parent.Find("SellingPrice").gameObject.SetActive(false);
        // アンロックした情報をセーブする
        var save = SaveManager.Instance.save;
        // saveファイル更新
        var content = child.gameObject.transform.parent.parent.parent.parent;
        if (content.gameObject.CompareTag("TouchObject"))
        {
            save.objectColor[index].unlock = true;
        }
        else if (content.gameObject.CompareTag("BackPanel"))
        {
            save.backColor[index].unlock = true;
        }
        else if (content.gameObject.CompareTag("TouchSound"))
        {
            save.sound[index].unlock = true;
        }
        SaveManager.Instance.Save();
    }

    public void BuyCancel()
    {
        this.BuyWindowSetActive(false);
    }
}
