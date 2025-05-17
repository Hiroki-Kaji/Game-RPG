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
    [SerializeField]private int sceneID; //シーン進捗
    [SerializeField]private int playerLv; //プレイヤーレベル
    [SerializeField]private float playerExp; //プレイヤー経験値
    [SerializeField] private Weapon playerWeapon;//キャラの武器装備
    [SerializeField] private Armer playerArmer;//キャラの防具装備
    [SerializeField] private Ring playerRing;//キャラの指輪装備

    public string PlayerName { get => playerName;}
    public int SceneID { get => sceneID;}
    public int PlayerLv { get => playerLv;}
    public float PlayerExp { get => playerExp;}
    public Weapon PlayerWeapon { get => playerWeapon;}
    public Armer PlayerArmer { get => playerArmer;}
    public Ring PlayerRing { get => playerRing; }
    #endregion

    #region メソッド

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
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
    internal void SetPlayerName(string name)
    {
        GameManager.instance.playerName = name;
    }

    internal void ForwardScene()
    {
        GameManager.instance.sceneID++;
    }

    internal void BackwardsScene()
    {
        GameManager.instance.sceneID--;
    }

    internal void SetWeapon(Weapon weapon)
    {
        GameManager.instance.playerWeapon = weapon;
    }

    internal void SetArmer(Armer armer)
    {
        GameManager.instance.playerArmer = armer;
    }
    internal void SetRing(Ring ring)
    {
        GameManager.instance.playerRing = ring;
    }
    #endregion
}
