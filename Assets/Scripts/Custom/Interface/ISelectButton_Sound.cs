using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectButton_Sound
{
    AudioClip[] AudioClip{get;}
    void InstantiateButton();

    void AudioClipPlayOneShot(AudioClip audioClip);
}
