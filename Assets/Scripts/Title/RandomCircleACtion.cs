using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class RandomCircleACtion : MonoBehaviour
{
    Vector3 tra_pos {get; set;}
    Vector3 pre_tra_pos {get; set;}
    Vector2 screenRes {get; set;}
    public GameObject panel{get; set;}

    void Start()
    {
        if (Application.platform == RuntimePlatform.Android) {
            screenRes = new Vector2(Screen.currentResolution.width, panel.GetComponent<RectTransform>().sizeDelta.y);
            Debug.Log(screenRes);
        }
        else {
            screenRes = new Vector2(Screen.width, panel.GetComponent<RectTransform>().sizeDelta.y);
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
        float rand_width = Random.Range (-screenRes.x / 2, screenRes.x / 2);
        float rand_height = Random.Range (-screenRes.y / 2, screenRes.y / 2);
        return new Vector3(rand_width, rand_height, 0);
    }

    void Update()
    {
        
    }
}
