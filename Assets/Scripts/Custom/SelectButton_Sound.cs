using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton_Sound : MonoBehaviour, ISelectButton_Sound
{
    [SerializeField]
    private AudioClip[] _sound;
    private AudioSource _audioSource;

    private void Start()
    {
        this._audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void InstantiateButton()
    {
        var buttonsParent = this.gameObject.transform.Find("Scroll View/Viewport/Content").gameObject;
        Assert.IsNotNull(buttonsParent, "buttonsParentがnull");
        for (int i = 0; i < this._sound.Length; ++i)
        {
            var button = Instantiate(CustomManager.Instance._PrefabButton, buttonsParent.transform, false);
            button.GetComponent<ISelectButton>().AudioClip = this._sound[i];
            button.GetComponent<Button>().onClick.AddListener(() => button.GetComponent<ISelectButton>().Selected(this));
        }
        this.gameObject.GetComponent<SelectButtonManager>().Initialize();
    }

    public void AudioClipPlayOneShot(AudioClip audioClip)
    {
        this._audioSource.PlayOneShot(audioClip);
    }
}
