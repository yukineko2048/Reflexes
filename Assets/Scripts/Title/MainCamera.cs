using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour, IMainCamera
{
    private float _worldScreenHeight;
    private float _worldScreenWidth;

    private void Awake()
    {
        this._worldScreenHeight = Camera.main.orthographicSize * 2f;
        this._worldScreenWidth = this._worldScreenHeight / Screen.height * Screen.width;
    }
    public Vector2 WorldScreen
    {
        get { return new Vector2(this._worldScreenWidth, this._worldScreenHeight); }
    }
}
