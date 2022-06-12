using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonManager : MonoBehaviour
{
    private List<Button> buttons = new List<Button>();
    // このスクリプトの孫に当たるContent
    private Transform Content;
    private void Awake()
    {
        Content = transform.Find("Scroll View/Viewport/Content");
        foreach (Transform child in Content)
        {
            Debug.Log(child.name);
            buttons.Add(child.gameObject.GetComponent<Button>());
            // ボタンを押したときの処理の追加
            child.gameObject.GetComponent<Button>().onClick.AddListener(() => this.SelectedButton(child));
        }
        this.SelectButtonFrameInvisible(Content);
        // 現在選択されているボタンにフレームを付ける
        
    }

    private void SelectedButton(Transform child)
    {
        // 初期化
        this.SelectButtonFrameInvisible(Content);
        // 選択フレームを出す
        child.gameObject.GetComponent<ISelectButton>().Selected();
    }

    private void SelectButtonFrameInvisible(Transform Content)
    {
        foreach (Transform child in Content)
        {
            child.Find("SelectFrame").gameObject.SetActive(false);
        }
    }
}
