using System.IO;
using UnityEngine;
using System.Collections.Generic;
using Utile;

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
        filePath = Application.persistentDataPath + "/" + ".savedata.json";
        Debug.Log(Application.persistentDataPath);
        save = new SaveData();
    }

    private void Initialize()
    {
        // 初期化処理
        // 1番目のカスタムデータを選択済み、ロック解除にする
        var firstData_ObjectColor = new ObjectColor(true, true);
        save.objectColor.Add(firstData_ObjectColor);
        var firstData_BackColor = new BackColor(true, true);
        save.backColor.Add(firstData_BackColor);
        var firstData_Sound = new Sound(true, true);
        save.sound.Add(firstData_Sound);

        // 2番目移行のデータは選択済みではない、ロック解除ではないにする
        var data_ObjectColor = new ObjectColor(false, false);
        var objectColorCount = this._ObjectColor.GetComponent<ISelectButton_ObjectColor>().Color.Length;
        for (int i = 1; i < objectColorCount; ++i)
        {
            save.objectColor.Add(data_ObjectColor);
        }
        var data_BackColor = new BackColor(false, false);
        var backColorCount = this._BackColor.GetComponent<ISelectButton_BackColor>().Color.Length;
        for (int i = 1; i < backColorCount; ++i)
        {
            save.backColor.Add(data_BackColor);
        }
        var data_Sound = new Sound(false, false);
        var soundCount = this._Sound.GetComponent<ISelectButton_Sound>().AudioClip.Length;
        for (int i = 1; i < soundCount; ++i)
        {
            save.sound.Add(data_Sound);
        }
    }

    public void Save()
    {
        string json = JsonUtility.ToJson(save);
        StreamWriter streamWriter = new StreamWriter(filePath);
        streamWriter.Write(json);
        streamWriter.Flush();
        streamWriter.Close();
    }

    public void Load()
    {
        if (File.Exists(filePath))
        {
            StreamReader streamReader;
            streamReader = new StreamReader(filePath);
            string data = streamReader.ReadToEnd();
            Debug.Log(data);
            streamReader.Close();
            save = JsonUtility.FromJson<SaveData>(data);
            Debug.Log(save.objectColor[0].ToString());
        }
    }
}