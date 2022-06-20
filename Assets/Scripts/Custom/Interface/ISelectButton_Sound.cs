using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISelectButton_Sound
{
    void InstantiateButton();

    void AudioClipPlayOneShot(AudioClip audioClip);
}
