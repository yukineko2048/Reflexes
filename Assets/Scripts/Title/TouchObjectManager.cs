using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchObjectManager : MonoBehaviour
{
    public static TouchObjectManager instance;

    // タッチされてオブジェクトが移動し始めてから移動がおわるまでの時間(フレーム)
    // この間はタッチされてもUpdatePositionを行わない
    internal int _movingTime = 7;

    private bool isMoving {get;set;}

    public void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    void Start() {
        isMoving = false;
    }

    public void TouchObject(){
        if (!isMoving){
            isMoving = true;
            GetComponent<MovingObjectOnRandom>().UpdatePosition();
            StartCoroutine("MovingDelay");
        }
    }

    IEnumerator MovingDelay()
    {
        for (int i = 0; i < _movingTime ; i++)
        {
            yield return null;
        }
        isMoving = false;
    }
}
