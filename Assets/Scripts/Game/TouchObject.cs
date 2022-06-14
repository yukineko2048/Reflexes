using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Const;

public class TouchObject : MonoBehaviour, ITouchObject
{
    [SerializeField]
    private GameObject _Score;
    // タッチされてオブジェクトが移動し始めてから移動がおわるまでの時間(フレーム)
    // この間はタッチされてもUpdatePositionを行わない
    private int _movingTime = CO.MOVING_TIME;

    // オブジェクトがタッチされ、移動中はTRUE、静止している際はFALSE
    private bool _isMoving = false;

    // オブジェクトがタッチされて次にタッチされるまでを測定した
    private int _frameCount = 0;

    private IMovingObjectOnRandom _IMovingObjectOnRandom;

    private void Start()
    {
        this._IMovingObjectOnRandom = this.gameObject.transform.GetComponent<IMovingObjectOnRandom>();
    }

    public bool IsMoving
    {
        get { return this._isMoving; }
    }

    public Vector3 Position
    {
        get { return this.gameObject.transform.position; }
        set { this.gameObject.transform.position = value; }
    }

    public Quaternion Rotate
    {
        get { return this.gameObject.transform.rotation; }
        set { this.gameObject.transform.rotation = value; }
    }

    public Vector3 Scale
    {
        get { return this.gameObject.transform.localScale; }
        set { this.gameObject.transform.localScale = value; }
    }

    public void TouchedObject(int frameCount)
    {
        if (!this._isMoving && GameManager.Instance._isRunning)
        {
            this._isMoving = true;
            this._IMovingObjectOnRandom.UpdatePosition();
            int comboFrame = CO.COMBO_EXTENSION_FRAME - (frameCount - this._frameCount);
            this._frameCount = frameCount;
            ScoreManager.Instance.AddScore(comboFrame);
            StartCoroutine("MovingDelay");
        }
    }

    IEnumerator MovingDelay()
    {
        for (int i = 0; i < this._movingTime; i++)
        {
            yield return null;
        }
        this._isMoving = false;
    }
}
