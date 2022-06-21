using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    // オブジェクトの色(index)
    public List<ObjectColor> objectColor = new List<ObjectColor>();
    public List<BackColor> backColor = new List<BackColor>();
    public List<Sound> sound = new List<Sound>();

}

[Serializable]
public class ObjectColor
{
    public bool selected;
    public bool unlock;

    public ObjectColor(bool selected, bool unlock)
    {
        this.selected = selected;
        this.unlock = unlock;
    }

    public override string ToString()
    {
        return string.Format("{0}, {1}", selected, unlock);
    }
}

[Serializable]
public class BackColor
{
    public bool selected;
    public bool unlock;

    public BackColor(bool selected, bool unlock)
    {
        this.selected = selected;
        this.unlock = unlock;
    }

    public override string ToString()
    {
        return string.Format("{0}, {1}", selected, unlock);
    }
}

[Serializable]
public class Sound
{
    public bool selected;
    public bool unlock;

    public Sound(bool selected, bool unlock)
    {
        this.selected = selected;
        this.unlock = unlock;
    }

    public override string ToString()
    {
        return string.Format("{0}, {1}", selected, unlock);
    }
}