using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public List<ObjectColor> objectColor = new List<ObjectColor>();
    public List<BackColor> backColor = new List<BackColor>();
    public List<Sound> sound = new List<Sound>();
}

[Serializable]
public class ObjectColor
{
    public bool selected;
    public bool unlock;
    public string name;
    public int sellingPrice;

    public ObjectColor(bool selected, bool unlock, string name, int sellingPrice)
    {
        this.selected = selected;
        this.unlock = unlock;
        this.name = name;
        this.sellingPrice = sellingPrice;
    }
}

[Serializable]
public class BackColor
{
    public bool selected;
    public bool unlock;
    public string name;
    public int sellingPrice;

    public BackColor(bool selected, bool unlock, string name, int sellingPrice)
    {
        this.selected = selected;
        this.unlock = unlock;
        this.name = name;
        this.sellingPrice = sellingPrice;
    }
}

[Serializable]
public class Sound
{
    public bool selected;
    public bool unlock;
    public string name;
    public int sellingPrice;

    public Sound(bool selected, bool unlock, string name, int sellingPrice)
    {
        this.selected = selected;
        this.unlock = unlock;
        this.name = name;
        this.sellingPrice = sellingPrice;
    }
}