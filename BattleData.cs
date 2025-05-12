using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class BattleData
{
    public int id;
    public string enemy1;
    public string enemy2;
    public string enemy3;
    public int enemy1_lv;
    public int enemy2_lv;
    public int enemy3_lv;
    public int background;
}

[Serializable]
public class TextDataWrapper
{
    public TextData[] lines;
}
