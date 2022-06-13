using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinAddButton : MonoBehaviour, ICoinAddButton
{
    private void Start() {
        this.gameObject.GetComponent<Button>().onClick.AddListener(ButtonTouched);
    }

    private void ButtonTouched()
    {
        GoogleMobileAdsDemoScript.Instance.UserChoseToWatchAd();
    }
}
