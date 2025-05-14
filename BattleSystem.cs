using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BattleSystem : MonoBehaviour
{
    static int MAX_ENEMIES_NUM = 3;//最大敵の数
    static float SINGLE_ATTACK_DAMAGE_COLLECTION=1.5f;//1人攻撃倍率補正
    static float HEAL_EFFECT_RATE = 0.3f;//回復倍率補正
    #region 変数/参照
    [SerializeField] BattleCanvas _battleCanvas;
    [SerializeField] private CharaStatus player; //プレイヤーの情報
    [SerializeField] private List<CharaStatus> enemies = new List<CharaStatus>(); //エネミーの情報
    [SerializeField] private int playerSelect; //選択肢

    private int battleTurn;

    public CharaStatus Player { get => player;}
    public List<CharaStatus> Enemies { get => enemies;}
    public int PlayerSelect { get => playerSelect;}
    #endregion
    #region 関数名

    #region バトル遷移メソッド
    /// <summary>
    /// ターンごとに行う設定（playerSelectの初期化等）
    /// </summary>
    private void SetBattle()
    {
        Debug.Log("BattleSystem.SetBattle");
        playerSelect = 0;
        StartCoroutine(WaitPlayerSelect());
    }
    /// <summary>
    /// Playerの選択が変わるまで行うバトル関数
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitPlayerSelect()
    {
        Debug.Log("BattleSystem.WaitPlayerSelect");
        while (playerSelect==0)
        {
            yield return new WaitForSeconds(0.5f);
        }
        _battleCanvas.CloseButtons();
        StartCoroutine(MainBattleTurn());
    }
    /// <summary>
    /// 選択したパターンの攻撃を行うバトル関数
    /// </summary>
    /// <returns></returns>
    private IEnumerator MainBattleTurn()
    {
        Debug.Log("BattleSystem.MainBattleTurn");
        yield return new WaitForSeconds(1f);
        //見方の攻撃
        //＊＊＊＊攻撃は一番左を狙う
        switch(playerSelect)
        {
            case 1://攻撃
                //_battleCanvas.UpdateDialog(ResouceDataBase.instance.BattleText);
                foreach (CharaStatus e in enemies)
                {
                    if (e.HP > 0) { e.damageHP((int)(Player.Atk * SINGLE_ATTACK_DAMAGE_COLLECTION)); break; }
                }
                break;

            case 2://魔法
                //_battleCanvas.UpdateDialog(ResouceDataBase.instance.BattleText);
                foreach (CharaStatus e in enemies) {
                    e.damageHP(Player.Atk);
                }
                break;
            case 3://回復
                //_battleCanvas.UpdateDialog(ResouceDataBase.instance.BattleText);
                player.HealHP((int)(Player.MaxHP()* HEAL_EFFECT_RATE));
                break;
            default:
                Debug.LogError("入力判定が想定外です!");
                break;
        }
        //_battleCanvas.UpdateDialog(ResouceDataBase.instance.BattleText);
        //敵の攻撃
        foreach (CharaStatus e in enemies)
        {
            if (e.HP > 0) { player.damageHP((int)(e.Atk));}
        }
        //生死判定
        if (enemies.All(e => e.HP == 0))
        {
            GameSystem.instance.PrassExp(enemies.Count*50);
            //全員削除(蘇生のため最後に削除)
            enemies.Clear();
            // 次のバトルの処理
            NextStart();
            yield break;
        }
        if (player.HP == 0)
        {
            PlayerDeath();
            yield break;
        }
        _battleCanvas.CloseLoading();
        StartCoroutine(SubBattleTurn());
    }
    /// <summary>
    /// 毒ダメージなどの攻撃を受けるバトル関数
    /// </summary>
    /// <returns></returns>
    private IEnumerator SubBattleTurn()
    {
        Debug.Log("BattleSystem.SubBattleTurn");
        yield return new WaitForSeconds(1f);
        SetBattle();
    }
    #endregion
    #region ボタン
    public void PushAtkButton()
    {
        Debug.Log("BattleSystem.PushAtkButton");
        playerSelect = 1;
    }
    public void PushMagicButton()
    {
        Debug.Log("BattleSystem.PushMagicButton");
        playerSelect = 2;
    }
    public void PushHealButton()
    {
        Debug.Log("BattleSystem.PushHealButton");
        playerSelect = 3;
    }
    #endregion
    #region Other
    /// <summary>
    /// 初期設定
    /// </summary>
    private void Start()
    {
        //バトルターンの初期化
        battleTurn = 0;
        //敵のリソース情報を読み込む
        SetBattleText(GameManager.instance.BattleID);
        //最初のゲーム敵配置
        GetPlayableChara();
        GetEnemyChara();
        SetChara();
        _battleCanvas.CloseLoading();
        //バトルのセット
        SetBattle();
    }
    //２戦目以降の設定
    private void NextStart()
    {
        battleTurn++;
        //次のバトルシーンがある場合、セット
        try
        {
            GetEnemyChara();
            SetChara();
            _battleCanvas.CloseLoading();
            //バトルのセット
            SetBattle();
        }
        catch
        {
            UpdateScene();
        }     
    }
    //テキストを更新する処理
    private void UpdateText()
    {

    }
    //テキストを準備する処理
    private void SetText()
    {
        UpdateText();
    }
    //テキストを読み込む処理
    private string GetText(int textNumber)
    {
        return "";
    }
    //背景をセットするための処理
    private void SetBackground(int backgroundNumber)
    {
        _battleCanvas.ChangeBackGround();
        //_battleCanvas.ChangeBackGround(backgroundNumber);
    }
    //CharaUIをセットする関数
    private void SetChara()
    {
        _battleCanvas.UpdateHeroData(Player);
        for(int i =0;i<Enemies.Count;i++)
        {
            if (Enemies[i].Chara!=null)
            {
                _battleCanvas.UpdateOtherData(enemies[i], i);
            }
        }
        for(int i = MAX_ENEMIES_NUM-1; i > Enemies.Count-1; i--)
        {
            _battleCanvas.CloseOthers(i, 0, 0);
        }
    }
    //プレイヤーの情報を格納する
    private void GetPlayableChara()
    {
        player = new CharaStatus(CharaDataBase.instance.OutputPlayableChara(), GameManager.instance.PlayerLv);
    }
    //エネミーの情報を格納する
    //ResouceDataBaseからバトルフェーズの敵情報を取得する方法
    public void GetEnemyChara()
    {
        Debug.Log("BattleSystem.GetEnemyData");
        CharaStatus[] a = ResourceDataBase.instance.OutputEnemysInfo(battleTurn);
        //順番に読み込んだキャラを追加する
        foreach (CharaStatus aItem in a) {
            if (aItem !=null)
            {
                enemies.Add(aItem);
            }
        }
    }
    //シーンを変更する
    private void UpdateScene()
    {
        Debug.Log("BattleSystem.UpdateScene");
        //ストーリーシーンに変更
        GameSystem.instance.ChangeStoryScene();
    }
    //バトルに関係するキャラ全員のステータスを変換し格納する
    private void SetCharaStatus()
    {

    }
    //HPを変更する処理
    private void UpdateHP()
    {

    }

    private void UpdateHP(int num)
    {

    }
    //必要か不明
    private void UpdateAtk()
    {

    }
    //ResourceDataBaseにバトルテキストを格納させる
    public void SetBattleText(int fileID)
    {
        Debug.Log("BattleSystem.SetBattleText");
        //通常はfileIDのデータを呼び出す
        ResourceDataBase.instance.SetupBattleText("sample");
    }

    private void PlayerDeath()
    {
        Debug.Log("player death");
        GameSystem.instance.ChangeFirstScene();
    }

    #endregion
    #endregion
}
