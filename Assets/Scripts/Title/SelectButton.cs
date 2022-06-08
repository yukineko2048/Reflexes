using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour, ISelectButton
{
    public void Selected()
    {
        // フレームをactiveにする
        this.gameObject.transform.Find("SelectFrame").gameObject.SetActive(true);
        // ボタンにAudio Sourceがコンポーネントとして付与されていたらサンプル音声を流す
        // AudioSource audioSource = this.gameObject.GetComponent<AudioSource>();
        // if (audioSource)
        // {
        //     if (!audioSource.clip)
        //     {
        //         Debug.LogError("audioSourceは存在しているがクリップが存在していない");
        //     }
        //     audioSource.PlayOneShot(audioSource.clip);
        // }
    }
}
