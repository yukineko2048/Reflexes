using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class MovingObjectOnRandom : MonoBehaviour, IMovingObjectOnRandom
{
    public GameObject _PanelRoot;
    private Vector3 _tra_pos {get; set;}
    private Vector3 _pre_tra_pos {get; set;}
    private Vector2 _screenRes {get; set;}
    // オブジェクト移動の始点
    private Vector2 _startPos {get;set;}
    // オブジェクト移動の終点
    private Vector2 _endPos {get;set;}
    private int _movingTime = CO.MOVING_TIME;
    // オブジェクト情報
    private ITouchObject _ITouchObject;
    // カメラ情報
    private IMainCamera _IMainCamera;
    // UIパネル情報
    private IPanelRoot _IPanelRoot;

    void Start()
    {
        // オブジェクト、カメラ情報取得
        this._ITouchObject = this.gameObject.GetComponent<ITouchObject>();
        this._IMainCamera = Camera.main.GetComponent<IMainCamera>();
        this._IPanelRoot = this._PanelRoot.GetComponent<IPanelRoot>();
        var worldScreen = this._IMainCamera.WorldScreen;
        var panelRootScreen = this._IPanelRoot.UIScreen;
        var panelBodyScreen = this._IPanelRoot.PanelBodyScreen;

        // 計算式
        // 画面横幅/画面縦幅=画面比率(横)
        // 画面比率(縦)が"1"になるので、画面比率(横)に画面縦幅の大きさをかければワールド座標の横幅が算出
        // 画面比率(横) * 画面縦幅の大きさ(ワールド座標)=横幅
        if (Application.platform == RuntimePlatform.Android) {
            this._screenRes = new Vector2(worldScreen.x / 2.0f - (this._ITouchObject.Scale.x/2.0f)
                                        , ((panelBodyScreen.y / 2.0f) * (worldScreen.y / 2.0f)) / (panelRootScreen.y / 2.0f) - (this._ITouchObject.Scale.y/2.0f));
            Debug.Log(this._screenRes);
        }
        else {
            this._screenRes = new Vector2(worldScreen.x / 2.0f - (this._ITouchObject.Scale.x/2.0f)
                                        , ((panelBodyScreen.y / 2.0f) * (worldScreen.y / 2.0f)) / (panelRootScreen.y / 2.0f) - (this._ITouchObject.Scale.y/2.0f));
            // Debug.Log(this._screenRes);
        }
        this._tra_pos = this.gameObject.transform.position;
    }

    public void UpdatePosition()
    {
        this._pre_tra_pos = this._tra_pos;
        NextNewPosition();
        // this.gameObject.transform.localPosition = this._tra_pos;
    }

    // 次に出現させるポジションを作成する
    private void NextNewPosition()
    {
        float rand_width = Random.Range (-this._screenRes.x, this._screenRes.x);
        float rand_height = Random.Range (-this._screenRes.y, this._screenRes.y);
        this._startPos = this._pre_tra_pos;
        this._endPos = new Vector2(rand_width, rand_height);
        StartCoroutine("MoveTouchObject");
        this._tra_pos = this._endPos;
    }

    IEnumerator MoveTouchObject()
    {
        var actionFlame = _movingTime;
        Vector2 dis = new Vector2(this._endPos.x - this._startPos.x, this._endPos.y - this._startPos.y);
        // Debug.Log(transform.position.x + this._endPos.x);
        // Debug.Log(transform.position.y + this._endPos.y);
        for (int i = actionFlame; i > 0; i--)
        {
            float x = dis.x / actionFlame;
            float y = dis.y / actionFlame;
            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            yield return null;
        }
    }
}
