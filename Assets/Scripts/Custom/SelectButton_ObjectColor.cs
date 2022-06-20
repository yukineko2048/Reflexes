using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton_ObjectColor : MonoBehaviour, ISelectButton_ObjectColor
{
    [SerializeField] private Color[] _color;

    public void InstantiateButton()
    {
        var buttonsParent = this.gameObject.transform.Find("Scroll View/Viewport/Content").gameObject;
        for (int i = 0; i < this._color.Length; ++i)
        {
            var button = Instantiate(CustomManager.Instance._PrefabButton, buttonsParent.transform, false);
            button.GetComponent<Image>().color = this._color[i];
        }
        this.gameObject.GetComponent<SelectButtonManager>().Initialize();
    }
}
