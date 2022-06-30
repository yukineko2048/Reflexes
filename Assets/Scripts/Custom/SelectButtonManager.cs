using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SelectButtonManager : MonoBehaviour
{
    // このスクリプトの孫に当たるContent
    private Transform _buttonsParent;
    public void Initialize(bool[] selected, bool[] unlock, string[] name, int[] sellingPrice)
    {
        this._buttonsParent = transform.Find("Scroll View/Viewport/Content");
        for (int i = 0; i < this._buttonsParent.childCount; ++i)
        {
            var button = this._buttonsParent.GetChild(i).Find("SelectButton").gameObject;
            // アンロックされているかどうかセーブデータから取得
            if (!unlock[i])
            {
                // ロックされているのでinteractableをfalse
                this.SetButtonInteractable(button.transform, false);
                // アンロックに必要なコイン数を表示
                this._buttonsParent.GetChild(i).Find("SellingPrice").gameObject.SetActive(true);
                // ロックimageの表示
                button.transform.Find("LockPanel").gameObject.SetActive(true);
            }
            
            // 選択されているかどうかセーブデータから取得
            if (selected[i])
            {
                // 選択フレームを出す
                button.GetComponent<ISelectButton>().Selected(false);
            }
            var child = button;
            // ボタンを押したときの処理の追加
            button.GetComponent<Button>().onClick.AddListener(() => this.SelectedButton(child.transform));
            // ボタンのnameを設定
            button.transform.Find("NameText").GetComponent<TextMeshProUGUI>().text = name[i];
            // 売値を設定
            this._buttonsParent.GetChild(i).Find("SellingPrice").GetComponent<TextMeshProUGUI>().text = sellingPrice[i].ToString();
        }
        // 現在選択されているボタンにフレームを付ける

    }

    private void SelectedButton(Transform child)
    {
        // 初期化
        this.SelectButtonFrameInvisible(this._buttonsParent);
        // 選択フレームを出す
        child.gameObject.GetComponent<ISelectButton>().Selected(true);
    }

    private void SelectButtonFrameInvisible(Transform Content)
    {
        foreach (Transform child in Content)
        {
            child.Find("SelectButton/SelectFrame").gameObject.SetActive(false);
        }
    }

    private void SetButtonInteractable(Transform child, bool flag)
    {
        child.gameObject.GetComponent<Button>().interactable = flag;
        child.gameObject.transform.Find("LockPanel").gameObject.SetActive(!flag);
    }
}