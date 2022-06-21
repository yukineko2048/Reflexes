using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectButton : MonoBehaviour, ISelectButton
{
    private AudioClip _audioClip;
    private SelectButton_Sound _selectButton_Sound;

    public AudioClip AudioClip
    {
        get { return this._audioClip; }
        set { this._audioClip = value; }
    }

    public void Selected(SelectButton_Sound selectButton_Sound = null)
    {
        // 2回目移行は初回にはいったSelectButton_Soundがはいるようになる
        this._selectButton_Sound = selectButton_Sound ?? this._selectButton_Sound;
        // フレームをactiveにする
        this.gameObject.transform.Find("SelectFrame").gameObject.SetActive(true);
        if (this._audioClip)
        {
            this._selectButton_Sound.AudioClipPlayOneShot(this._audioClip);
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
