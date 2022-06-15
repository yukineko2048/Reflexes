using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButton : MonoBehaviour, ITitleButton
{
    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(ButtonTouched);
    }

    public void ButtonTouched()
    {
        GameManager.Instance.Title();
    }
}
