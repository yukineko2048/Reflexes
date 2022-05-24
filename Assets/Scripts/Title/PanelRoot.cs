using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelRoot : MonoBehaviour, IPanelRoot
{
    // ヘッダーのパネル
    private GameObject _PanelHeader;
    // ボディのパネル
    private GameObject _PanelBody;
    // フッターのパネル
    private GameObject _PanelFooter;
    private Vector2 _UIScreen;

    private void Awake() {
        this._PanelHeader = transform.Find("PanelHeader").gameObject;
        this._PanelBody = transform.Find("PanelBody").gameObject;
        this._PanelFooter = transform.Find("PanelFooter").gameObject;
    }

    private void Start() {
        var canvasRectTransform = transform.parent.gameObject.GetComponent<RectTransform>();
        this._UIScreen = new Vector2(canvasRectTransform.sizeDelta.x, canvasRectTransform.sizeDelta.y);
        // Debug.Log(this._UIScreen);
    }

    public Vector2 UIScreen
    {
        get { return this._UIScreen; }
    }
    public Vector2 PanelHeaderScreen
    {
        get { return new Vector2(this._PanelHeader.GetComponent<RectTransform>().sizeDelta.x, this._PanelHeader.GetComponent<RectTransform>().sizeDelta.y); }
    }
    public Vector2 PanelBodyScreen
    {
        get { return new Vector2(this._PanelBody.GetComponent<RectTransform>().sizeDelta.x, this._PanelBody.GetComponent<RectTransform>().sizeDelta.y); }
    }
    public Vector2 PanelFooterScreen
    {
        get { return new Vector2(this._PanelFooter.GetComponent<RectTransform>().sizeDelta.x, this._PanelFooter.GetComponent<RectTransform>().sizeDelta.y); }
    }
}
