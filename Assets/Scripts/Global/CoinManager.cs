using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : SingletonMonoBehaviour<CoinManager>
{
    private int _coins;

    void Start()
    {
        // 取得できなければ0を返す
        this._coins = this.GetCoin();
    }

    public int GetCoin()
    {
        return PlayerPrefs.GetInt("Coins", 0);
    }

    // コイン加算
    public void AddCoin(int addCoins)
    {
        PlayerPrefs.SetInt("Coins", this._coins + addCoins);
        Debug.Log($"コインを加算.コイン数:{PlayerPrefs.GetInt("Coins")}");
    }

    // コイン減算(マイナスチェック済み)
    public void SubCoin(int subCoins)
    {
        if (this._coins >= subCoins)
        {
            PlayerPrefs.SetInt("Coins", this._coins - subCoins);
            Debug.Log($"コインを減算.コイン数:{PlayerPrefs.GetInt("Coins")}");
        }
    }
}
