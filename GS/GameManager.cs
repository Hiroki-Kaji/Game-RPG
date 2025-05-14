using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region 変数/参照
    //自身のインスタンス化
    public static GameManager instance = null;
    //変数
    [SerializeField]private string playerName; //プレイヤー名
    [SerializeField]private int scenceID; //シーン進捗
    [SerializeField]private int battleID; //バトル進捗
    [SerializeField]private int playerLv; //プレイヤーレベル
    [SerializeField]private float playerExp; //プレイヤー経験値

    public string PlayerName { get => playerName;}
    public int ScenceID { get => scenceID;}
    public int BattleID { get => battleID;}
    public int PlayerLv { get => playerLv;}
    public float PlayerExp { get => playerExp;}
    #endregion

    #region メソッド

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 初期設定
    /// </summary>
    private void Start()
    {

    }

    /// <summary>
    /// レベルを1あげる処理
    /// </summary>
    internal void LevelUp()
    {
        Debug.Log("GameSystem.LevelUp");
        GameManager.instance.playerLv++;
    }

    /// <summary>
    /// 経験値を保存する処理
    /// </summary>
    internal void SaveExp(float exp)
    {
        Debug.Log("GameSystem.SaveExp");
        GameManager.instance.playerExp = exp;
    }
    /// <summary>
    /// 名前を設定する処理
    /// </summary>
    public void SetPlayerName(string name)
    {
        playerName = name;
    }
    #endregion
}
