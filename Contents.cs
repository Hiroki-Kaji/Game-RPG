using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Contents
{
    //プログラムに必要な定数
    public static readonly int INT_NULL = 0;//INTがNULLデータとして扱う定数または初期値
    public static readonly float WaitTime = 0.5f;//更新を待つとき定数
    //ゲーム内で使用する定数
    public static readonly int PLAYER_LV_MAX = 90;
    public static readonly int MAX_ENEMIES_NUM = 3;//最大敵の数
    public static readonly float SINGLE_ATTACK_DAMAGE_COLLECTION = 1.5f;//1人攻撃倍率補正
    public static readonly float HEAL_EFFECT_RATE = 0.3f;//回復倍率補正
}
