using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour, ICustomButton
{
    private void Start() {
        this.gameObject.GetComponent<Button>().onClick.AddListener(TitleManager.Instance.ActiveTrueCustomPanel);
    }
}
