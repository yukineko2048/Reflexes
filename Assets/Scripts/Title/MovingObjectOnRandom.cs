using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingObjectOnRandom : MonoBehaviour
{
    private Vector3 tra_pos {get; set;}
    private Vector3 pre_tra_pos {get; set;}
    private Vector2 screenRes {get; set;}
    // オブジェクト移動の始点
    private Vector2 startPos {get;set;}
    // オブジェクト移動の終点
    private Vector2 endPos {get;set;}
    private float startTime, distance;
    private int _movingTime{get;set;}

    void Start()
    {
        TouchObjectManager touchObjectManager = GetComponent<TouchObjectManager>();
        _movingTime = touchObjectManager._movingTime;
        // 計算式
        // 画面横幅/画面縦幅:画面比率
        // *10:シーンのUI画面のグリッド数
        // /2:画面の半分
        // -0.25:cubeの大きさの半分
        if (Application.platform == RuntimePlatform.Android) {
            screenRes = new Vector2((float.Parse(Screen.currentResolution.width.ToString())/float.Parse(Screen.currentResolution.height.ToString())*10)/2 - 0.25f, 4.11f);
            Debug.Log(screenRes);
        }
        else {
            screenRes = new Vector2((float.Parse(Screen.width.ToString())/float.Parse(Screen.height.ToString())*10)/2-0.25f, 4.11f);
            Debug.Log(screenRes);
        }
        tra_pos = this.gameObject.transform.position;
    }

    public void UpdatePosition()
    {
        pre_tra_pos = tra_pos;
        NextNewPosition();
        // this.gameObject.transform.localPosition = tra_pos;
    }

    // 次に出現させるポジションを作成する
    void NextNewPosition()
    {
        float rand_width = Random.Range (-screenRes.x, screenRes.x);
        float rand_height = Random.Range (-screenRes.y, screenRes.y);
        startPos = pre_tra_pos;
        endPos = new Vector2(rand_width, rand_height);
        StartCoroutine("MoveTouchObject");
        tra_pos = endPos;
    }

    IEnumerator MoveTouchObject()
    {
        var actionFlame = _movingTime;
        Vector2 dis = new Vector2(endPos.x - startPos.x, endPos.y - startPos.y);
        // Debug.Log(transform.position.x + endPos.x);
        // Debug.Log(transform.position.y + endPos.y);
        for (int i = actionFlame; i > 0; i--)
        {
            float x = dis.x / actionFlame;
            float y = dis.y / actionFlame;
            transform.position = new Vector3(transform.position.x + x, transform.position.y + y, transform.position.z);
            yield return null;
        }
    }
}
