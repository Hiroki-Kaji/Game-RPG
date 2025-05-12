using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaStatus : MonoBehaviour
{
    #region 変数/参照
    [SerializeField] private Chara _chara; //キャラクターの基礎データ
    [SerializeField] private int hp; //体力
    [SerializeField] private int atk; //攻撃力
    [SerializeField] private int lv; //レベル

    public int HP { get => hp;}
    public int Atk { get => atk;}
    public int Lv { get => lv;}
    public Chara Chara { get => _chara; }

    #endregion
    #region メソッド
    //敵モンスターのデータに使う関数
    public CharaStatus()
    {
    }
    public CharaStatus(Chara chara,int inputlv)
    {
        _chara = chara;
        lv = inputlv;
        hp = SetHP();
        atk = SetAtk();
    }
    public int SetHP()
    {
        hp = _chara.BasicHP * lv;
        return hp;
    }

    public int SetAtk()
    {
        atk = _chara.BasicAtk * lv;
        return atk;
    }
    #endregion
}
