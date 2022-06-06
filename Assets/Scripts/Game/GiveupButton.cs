using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Const;

public class GiveupButton : MonoBehaviour, IGiveupButton
{
    [SerializeField]
    private GameObject _ChangeScenePanel;
    private IChangeScenePanel _IChangeScenePanel;

    void Start()
    {
        this.gameObject.GetComponent<Button>().onClick.AddListener(TouchButton);
        this._IChangeScenePanel = this._ChangeScenePanel.GetComponent<IChangeScenePanel>();
    }

    private void TouchButton()
    {
        Debug.Log("ギブアップボタンタッチ");
        if (this._IChangeScenePanel.ActiveChangeScenePanel(CO.STRING_GIVE_UP))
        {
            // 正常にシーンチェンジパネルが表示されたのでポーズパネルを非表示にする
            GameManager.Instance.SetActivePauseMenuPanel(false);
        };
    }
}
