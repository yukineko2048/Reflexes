using System.IO;
using UnityEngine;
using System.Collections.Generic;
using Utile;
using Const;

public class SaveManager : SingletonMonoBehaviour<SaveManager>
{
    [SerializeField]
    GameObject _ObjectColor;
    [SerializeField]
    GameObject _BackColor;
    [SerializeField]
    GameObject _Sound;

    private string filePath;
    [SerializeReference]
    public SaveData save;

    new private void Awake()
    {
        save = new SaveData();
        // this.Initialize();
        // this.Save();
    }

    // セーブデータの初期化の時に使う(普段使いではない)
    private void Initialize()
    {
        // 初期化処理
        // 1番目のカスタムデータを選択済み、ロック解除にする
        var firstData_ObjectColor = new ObjectColor(true, true, "test", 123);
        save.objectColor.Add(firstData_ObjectColor);
        var firstData_BackColor = new BackColor(true, true, "test", 123);
        save.backColor.Add(firstData_BackColor);
        var firstData_Sound = new Sound(true, true, "test", 123);
        save.sound.Add(firstData_Sound);

        // 2番目移行のデータは選択済みではない、ロック解除ではないにする
        var data_ObjectColor = new ObjectColor(false, false, "test", 123);
        var objectColorCount = this._ObjectColor.GetComponent<ISelectButton_ObjectColor>().Color.Length;
        for (int i = 1; i < objectColorCount; ++i)
        {
            save.objectColor.Add(data_ObjectColor);
        }
        var data_BackColor = new BackColor(false, false, "test", 123);
        var backColorCount = this._BackColor.GetComponent<ISelectButton_BackColor>().Color.Length;
        for (int i = 1; i < backColorCount; ++i)
        {
            save.backColor.Add(data_BackColor);
        }
        var data_Sound = new Sound(false, false, "test", 123);
        var soundCount = this._Sound.GetComponent<ISelectButton_Sound>().AudioClip.Length;
        for (int i = 1; i < soundCount; ++i)
        {
            save.sound.Add(data_Sound);
        }
    }


    private void SetTestData()
    {
        var firstData_ObjectColor = new ObjectColor(true, true, "test", 123);
        save.objectColor.Add(firstData_ObjectColor);
        var firstData_BackColor = new BackColor(true, true, "test", 123);
        save.backColor.Add(firstData_BackColor);
    }
    
    public void Save()
    {
        string json = JsonUtility.ToJson(save);
        StreamWriter streamWriter = new StreamWriter(GameManager.Instance.filePath);
        streamWriter.Write(json);
        streamWriter.Close();
    }

    public void Load()
    {
        if (File.Exists(GameManager.Instance.filePath))
        {
            StreamReader streamReader = new StreamReader(GameManager.Instance.filePath);
            string data = streamReader.ReadToEnd();
            streamReader.Close();
            save = JsonUtility.FromJson<SaveData>(data);
            Debug.Log(save.objectColor[0].ToString());
        }
    }
}