using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton : MonoBehaviour, ISelectButton
{
    private AudioClip _audioClip;
    private SelectButton_Sound _selectButton_Sound;

    public AudioClip AudioClip
    {
        get { return this._audioClip; }
        set { this._audioClip = value; }
    }

    public void Selected(bool playOneShot, SelectButton_Sound selectButton_Sound = null)
    {
        // 2回目移行は初回にはいったSelectButton_Soundがはいるようになる
        this._selectButton_Sound = selectButton_Sound ?? this._selectButton_Sound;
        // フレームをactiveにする
        this.gameObject.transform.Find("SelectFrame").gameObject.SetActive(true);
        // 選択したボタンの色、サウンドに反映する
        var content = this.gameObject.transform.parent.parent;
        if (content.gameObject.CompareTag("TouchObject"))
        {
            GameManager.Instance.SetObjectColor(this.gameObject.GetComponent<Image>().color);
        }
        else if (content.gameObject.CompareTag("BackPanel"))
        {
            GameManager.Instance.SetBackColor(this.gameObject.GetComponent<Image>().color);
        }
        else if (content.gameObject.CompareTag("TouchSound"))
        {
            // サウンドのボタンなら音を鳴らす
            if (this._audioClip && playOneShot)
            {
                this._selectButton_Sound.AudioClipPlayOneShot(this._audioClip);
            }
            GameManager.Instance.SetTouchSound(this._audioClip);
        }
    }

    public void SetAudioClip(AudioClip audioClip)
    {
        Debug.Log(this.gameObject.GetComponent<AudioSource>().clip);
        this.gameObject.GetComponent<AudioSource>().clip = audioClip;
        Debug.Log(audioClip.name);
        Debug.Log(this.gameObject.GetComponent<AudioSource>().clip);
    }
}
