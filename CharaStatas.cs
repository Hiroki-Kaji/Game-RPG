using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[System.Serializable]
public class CharaStatus
{
    #region 変数/参照
    [SerializeField] private Chara _chara; //キャラクターの基礎データ
    [SerializeField] private Attribute attribute;//キャラ属性
    [SerializeField] private int hp; //体力
    [SerializeField] private int atk; //攻撃力
    [SerializeField] private int dfn; //防御力
    [SerializeField] private int max_hp; //最大体力
    [SerializeField] private int max_atk; //最大攻撃力
    [SerializeField] private int max_dfn; //最大防御力
    [SerializeField] private int base_atk; //基礎攻撃力
    [SerializeField] private int base_dfn; //基礎防御力
    [SerializeField] private int lv; //レベル

    public Chara Chara { get => _chara; }
    public Attribute Attribute { get => attribute; }
    public int HP { get => hp;}
    public int Atk { get => atk;}
    public int Dfn { get => dfn; }
    public int Max_hp { get => max_hp; set => max_hp = value; }
    public int Max_atk { get => max_atk; set => max_atk = value; }
    public int Max_dfn { get => max_dfn; set => max_dfn = value; }
    public int Base_atk { get => base_atk;}
    public int Base_dfn { get => base_dfn;}
    public int Lv { get => lv; }




    #endregion
    #region メソッド
    //敵モンスターのデータに使う関数

    public CharaStatus(Chara chara,int inputlv)
    {
        _chara = chara;
        lv = inputlv;
        hp = SetHP();
        atk = SetAtk();
        dfn = SetDfn();
    }

    public int SetHP()
    {
        float prassRate = 1f;
        //通常の基礎ステータスの追加
        base_atk = _chara.BasicAtk;
        hp = (int)(_chara.BasicHP * prassRate * GrowthFactor(Lv));
        this.max_hp = hp;
        return hp;
    }

    public int SetAtk()
    {
        float prassRate = 1f;
        //通常の基礎ステータスの追加
        base_atk = _chara.BasicAtk;
         atk = (int)(base_atk * prassRate * GrowthFactor(Lv));
        this.max_atk = atk;
        return atk;
    }

    public int SetDfn()
    {
        float prassRate = 1f;
        //通常の基礎ステータスの追加
        base_dfn = _chara.BasicDfn;
        dfn = (int)(base_dfn * prassRate * GrowthFactor(Lv));
        this.max_dfn = dfn;
        return dfn;
    }

    public void damageHP(int damage)
    {
        this.hp -= damage;
        if (this.hp < 0)
        {
            this.hp = 0;
        }
    }

    public void HealHP(int heal)
    {
        Debug.Log(this.hp+"::"+heal);
        this.hp += heal;
        Debug.Log(this.hp+"HP:"+ HP);
        if (this.hp > Max_hp)
        {
            this.hp = Max_hp;
        }
    }

    /// <summary>
    /// 成長率の調整
    /// </summary>
    /// <param name="lv"></param>
    /// <returns></returns>
    private float GrowthFactor(int lv)
    {
        if (lv <= 30) return lv * 0.1f;
        if (lv <= 60) return lv * 0.15f - 1.5f;
        if (lv <= 80) return lv * 0.225f - 6.0f;
        if (lv <= 100) return lv * 0.45f - 24.0f;
        if (lv <= 150) return lv * 0.1125f + 5.25f;
        if (lv <= 180) return lv * 0.16875f - 3.1875f;
        return lv * 0.253125f - 18.375f;
    }
    #endregion
}
