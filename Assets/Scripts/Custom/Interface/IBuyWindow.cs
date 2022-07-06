using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IBuyWindow
{
    void ShowBuyWindow(string typeText, int value,Transform child, int index);

    void BuyOk(int coins, Transform child, int index);

    void BuyCancel();
}
