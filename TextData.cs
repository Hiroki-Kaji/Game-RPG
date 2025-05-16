using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class TextData
{
    public int id;
    public int chara1ID;
    public int chara2ID;
    public int speakerID;
    public string background;
    public string text;
}

[Serializable]
public class TextDataWrapper
{
    public string title;
    public string areaName;
    public List<TextData> lines;
}
