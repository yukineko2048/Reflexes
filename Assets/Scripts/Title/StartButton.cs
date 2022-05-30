using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Const;

public class StartButton : MonoBehaviour, IStartButton
{
    private List<Image> _NeonImages = new List<Image>();
    private List<TextMeshProUGUI> _NeonTexts = new List<TextMeshProUGUI>();
    private int _childCount = 0;
    private int _HSVColorCount = 0;

    private void Start()
    {
        for (int i = 0; i < this.gameObject.transform.childCount; ++i)
        {
            if (this.gameObject.transform.GetChild(i).TryGetComponent<Image>(out var image)){
                Debug.Log(image);
                this._NeonImages.Add(image);
            }
            else if (this.gameObject.transform.GetChild(i).TryGetComponent<TextMeshProUGUI>(out var text)){
                Debug.Log(text);
                this._NeonTexts.Add(text);
            }
            else{
                Debug.LogError("判定できない種類の子が存在しています");
            }
        }
        Debug.Log(this._NeonImages);
        this._childCount = this.gameObject.transform.childCount;
    }

    private void FixedUpdate()
    {
        ++this._HSVColorCount;
        if (this._HSVColorCount > CO.MAXHSVCOLOR) {
            this._HSVColorCount = 0;
        }
        foreach (Image image in this._NeonImages) {
            image.color = Color.HSVToRGB((float)this._HSVColorCount / 360.0f, 1, 1);
        }
        foreach (TextMeshProUGUI text in this._NeonTexts) {
            text.color = Color.HSVToRGB((float)this._HSVColorCount / 360.0f, 1, 1);
        }
    }
}
