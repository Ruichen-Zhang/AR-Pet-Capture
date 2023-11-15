using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetSave
{
    private string strName = "未命名宝可梦";

    private int petIndex = 0;

    public string PetName
    {
        get { return strName; }
        set { strName = value; }
    }

    public int PetIndex
    {
        get { return petIndex; }
        set { petIndex = value; }
    }

    public PetSave(string name, int index)
    {
        PetName = name;
        PetIndex = index;
    }
}
