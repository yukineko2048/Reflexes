using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomCircleAction : MonoBehaviour
{
    Vector3 tra_pos {get; set;}
    Vector3 pre_tra_pos {get; set;}
    Vector2 screenRes {get; set;}
    void Start()
    {
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
        tra_pos = NextNewPosition();
        this.gameObject.transform.localPosition = tra_pos;
    }

    // 次に出現させるポジションを作成する
    Vector3 NextNewPosition()
    {
        float rand_width = Random.Range (-screenRes.x, screenRes.x);
        float rand_height = Random.Range (-screenRes.y, screenRes.y);
        return new Vector3(rand_width, rand_height, 0);
    }
}
