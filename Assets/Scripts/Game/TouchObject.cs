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

    private IMovingObjectOnRandom _IMovingObjectOnRandom;
    private IScore _IScore;

    private void Start()
    {
        this._IMovingObjectOnRandom = this.gameObject.transform.GetComponent<IMovingObjectOnRandom>();
        this._IScore = this._Score.GetComponent<IScore>();
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

    public void TouchedObject()
    {
        if (!this._isMoving && GameManager.Instance._isRunning)
        {
            this._isMoving = true;
            this._IMovingObjectOnRandom.UpdatePosition();
            this._IScore.AddScore();
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
