using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButtonManager : MonoBehaviour
{
    private List<Button> buttons = new List<Button>();
    // このスクリプトの孫に当たるContent
    private Transform _buttonsParent;
    public void Initialize(bool[] selected, bool[] unlock)
    {
        this._buttonsParent = transform.Find("Scroll View/Viewport/Content");
        for (int i = 0; i < this._buttonsParent.childCount; ++i)
        {
            buttons.Add(this._buttonsParent.GetChild(i).gameObject.GetComponent<Button>());
            // アンロックされているかどうかPlayerPrefsから取得
            if (!unlock[i])
            {
                // ロックされているのでinteractableをfalse
                this.SetButtonInteractable(this._buttonsParent.GetChild(i), false);
            }
            // ボタンを押したときの処理の追加
            this._buttonsParent.GetChild(i).gameObject.GetComponent<Button>().onClick.AddListener(() => this.SelectedButton(this._buttonsParent.GetChild(i)));
        }
        this.SelectButtonFrameInvisible(this._buttonsParent);
        // 現在選択されているボタンにフレームを付ける

    }

    private void SelectedButton(Transform child)
    {
        // 初期化
        this.SelectButtonFrameInvisible(this._buttonsParent);
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

    private void SetButtonInteractable(Transform child, bool flag)
    {
        child.gameObject.GetComponent<Button>().interactable = flag;
        child.gameObject.transform.Find("LockPanel").gameObject.SetActive(!flag);
    }
}
