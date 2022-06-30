using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions;
using UnityEngine;
using UnityEngine.UI;

public class SelectButton_Sound : MonoBehaviour, ISelectButton_Sound
{
    [SerializeField]
    public AudioClip[] _sound;
    private AudioSource _audioSource;
    private SaveData _save;

    public AudioClip[] AudioClip
    {
        get { return this._sound; }
    }

    private void Start()
    {
        this._audioSource = this.gameObject.GetComponent<AudioSource>();
    }

    public void InstantiateButton()
    {
        var save = SaveManager.Instance.save;
        bool[] selected = new bool[this._sound.Length];
        bool[] unlock = new bool[this._sound.Length];
        string[] name = new string[this._sound.Length];
        int[] sellingPrice = new int[this._sound.Length];
        var buttonsParent = this.gameObject.transform.Find("Scroll View/Viewport/Content").gameObject;
        Assert.IsNotNull(buttonsParent, "buttonsParentがnull");
        for (int i = 0; i < this._sound.Length; ++i)
        {
            var button = Instantiate(CustomManager.Instance._PrefabButton, buttonsParent.transform, false).transform.Find("SelectButton");
            button.GetComponent<ISelectButton>().AudioClip = this._sound[i];
            button.GetComponent<Button>().onClick.AddListener(() => button.GetComponent<ISelectButton>().Selected(false, this));
            selected[i] = save.sound[i].selected;
            unlock[i] = save.sound[i].unlock;
            name[i] = save.sound[i].name;
            sellingPrice[i] = save.sound[i].sellingPrice;
        }
        this.gameObject.GetComponent<SelectButtonManager>().Initialize(selected, unlock, name, sellingPrice);
    }

    public void AudioClipPlayOneShot(AudioClip audioClip)
    {
        this._audioSource.PlayOneShot(audioClip);
    }
}
