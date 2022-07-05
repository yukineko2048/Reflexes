using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class SaveData
{
    public List<ObjectColor> objectColor = new List<ObjectColor>();
    public List<BackColor> backColor = new List<BackColor>();
    public List<Sound> sound = new List<Sound>();

    public void SelectedClear_OC()
    {
        foreach(var obj in objectColor){
            obj.selected = false;
        }
    }

    public void SelectedClear_BC()
    {
        foreach(var obj in backColor){
            obj.selected = false;
        }
    }

    public void SelectedClear_S()
    {
        foreach(var obj in sound){
            obj.selected = false;
        }
    }
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

    public void SelectClear()
    {

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