using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectButton
{
    AudioClip AudioClip { get; set; }

    void Selected(bool playOneShot, SelectButton_Sound selectButton_Sound = null);

    void SetAudioClip(AudioClip audioClip);
}
