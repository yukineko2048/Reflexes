using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Const;

public class ChangeScenePanel : MonoBehaviour, IChangeScenePanel
{
    private string _text;

    private void Start()
    {
        this.gameObject.transform.Find("OkCancelButtons").Find("CancelButton").GetComponent<Button>().onClick.AddListener(CancelButton);
        this.gameObject.transform.Find("OkCancelButtons").Find("OkButton").GetComponent<Button>().onClick.AddListener(OkButton);
    }

    public bool ActiveChangeScenePanel(string text)
    {
        if (text == null)
        {
            Debug.LogError("引数が不正です");
            return false;
        }
        this._text = text;
        this.gameObject.SetActive(true);
        this.gameObject.transform.Find("ChangeSceneText").GetComponent<TextMeshProUGUI>().text = text;
        return true;
    }

    private void UnDActiveChangeScenePanel()
    {
        this.gameObject.SetActive(false);
    }

    private void OkButton()
    {
        if (this._text == CO.STRING_RETRY)
        {
            // リトライ処理
            Debug.Log("リトライします");
            this.UnDActiveChangeScenePanel();
            GameManager.Instance.Retry();
        }
        else if (this._text == CO.STRING_GIVE_UP)
        {
            // ギブアップ処理
            Debug.Log("ギブアップします");
            this.UnDActiveChangeScenePanel();
            GameManager.Instance.GiveUp();
        }
    }

    private void CancelButton()
    {
        if (this._text == CO.STRING_RETRY)
        {
            Debug.Log("リトライをキャンセルしました");
            this.UnDActiveChangeScenePanel();
            GameManager.Instance.SetActivePauseMenuPanel(true);
        }
        else if (this._text == CO.STRING_GIVE_UP)
        {
            Debug.Log("ギブアップをキャンセルしました");
            this.UnDActiveChangeScenePanel();
            GameManager.Instance.SetActivePauseMenuPanel(true);
        }
    }
}
