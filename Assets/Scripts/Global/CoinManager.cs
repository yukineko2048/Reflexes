using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoinManager : SingletonMonoBehaviour<CoinManager>
{
    private int _coins;

    void Start()
    {
        // 取得できなければ0を返す
        this._coins = this.GetCoin();
        this.UpdateCoin();
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt("Coins", 0);
    }

    // コイン加算
    public void AddCoin(int addCoins)
    {
        PlayerPrefs.SetInt("Coins", this._coins + addCoins);
        this._coins += addCoins;
        Debug.Log($"コインを加算.コイン数:{PlayerPrefs.GetInt("Coins")}");
        this.UpdateCoin();
    }

    // コイン減算(マイナスチェック済み)
    public void SubCoin(int subCoins)
    {
        if (this._coins >= subCoins)
        {
            PlayerPrefs.SetInt("Coins", this._coins - subCoins);
            this._coins -= subCoins;
            Debug.Log($"コインを減算.コイン数:{PlayerPrefs.GetInt("Coins")}");
            this.UpdateCoin();
        }
    }

    // コイン数更新
    public void UpdateCoin()
    {
        var viewCoinsText = GameObject.FindGameObjectsWithTag("Coin");
        foreach (var obj in viewCoinsText)
        {
            if (obj.TryGetComponent(out Text text))
            {
                text.text = this._coins.ToString();
            }
            else if (obj.TryGetComponent(out TextMeshProUGUI textmeshpro))
            {
                textmeshpro.text = this._coins.ToString();
            }
        }
    }
}
