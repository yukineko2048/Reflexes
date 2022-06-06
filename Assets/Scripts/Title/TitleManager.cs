using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleManager : SingletonMonoBehaviour<TitleManager>
{
    [SerializeField]
    private GameObject _CustomPanel;

    private void Start()
    {

    }

    public void ActiveTrueCustomPanel()
    {
        this.SetActiveCustomPanel(true);
    }

    public void ActiveFalseCustomPanel()
    {
        this.SetActiveCustomPanel(false);
    }

    private void SetActiveCustomPanel(bool active)
    {
        this._CustomPanel.SetActive(active);
    }
}
