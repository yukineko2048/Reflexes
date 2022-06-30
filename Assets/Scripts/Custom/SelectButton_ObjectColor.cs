using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton_ObjectColor : MonoBehaviour, ISelectButton_ObjectColor
{
    [SerializeField] public Color[] _color;

    public Color[] Color
    {
        get { return this._color; }
    }

    public void InstantiateButton()
    {
        var save = SaveManager.Instance.save;
        bool[] selected = new bool[this._color.Length];
        bool[] unlock = new bool[this._color.Length];
        string[] name = new string[this._color.Length];
        int[] sellingPrice = new int[this._color.Length];
        var buttonsParent = this.gameObject.transform.Find("Scroll View/Viewport/Content").gameObject;
        for (int i = 0; i < this._color.Length; ++i)
        {
            var button = Instantiate(CustomManager.Instance._PrefabButton, buttonsParent.transform, false);
            button.transform.Find("SelectButton").gameObject.GetComponent<Image>().color = this._color[i];
            selected[i] = save.objectColor[i].selected;
            unlock[i] = save.objectColor[i].unlock;
            name[i] = save.objectColor[i].name;
            sellingPrice[i] = save.objectColor[i].sellingPrice;
        }
        this.gameObject.GetComponent<SelectButtonManager>().Initialize(selected, unlock, name, sellingPrice);
    }
}
