using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaDataBase : MonoBehaviour
{
    public static CharaDataBase instance;

    [SerializeField] private List<Chara>storyChara = new List<Chara>();
    [SerializeField] private List<Chara>enemyChara = new List<Chara>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 敵キャラクターを名前から探す処理（難易度高）
    /// </summary>
    /// <param name="charaName"></param>
    /// <returns></returns>
    public Chara SearchEnemyChara(string charaName)
    {
        Debug.Log("CharaDataBase.SearchChara");
        //敵のキャラの分繰り返す
        //もしcharaName と Chara.charanameが一致したら
        //Charaをreturnする。
        return enemyChara[0];
    }
    /// <summary>
    /// 指定されたキャラ情報を送る関数
    /// </summary>
    /// <returns></returns>
    public Chara OutputStoryChara()
    {
        return storyChara[0];
    }
    /// <summary>
    /// 指定されたキャラ情報を送る関数
    /// </summary>
    /// <returns></returns>
    public Chara OutputEnmeyChara()
    {
        return enemyChara[0];
    }

}
