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
        this._coins = PlayerPrefs.GetInt("Score", 0);
    }

    public int GetCoin()
    {
        return this._coins;
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
