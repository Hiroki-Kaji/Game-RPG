using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BattleSystem : MonoBehaviour
{
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
        playerSelect = Contents.INT_NULL;
        StartCoroutine(WaitPlayerSelect());
    }
    /// <summary>
    /// Playerの選択が変わるまで行うバトル関数
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitPlayerSelect()
    {
        Debug.Log("BattleSystem.WaitPlayerSelect");
        _battleCanvas.OpenButtons();
        while (playerSelect== Contents.INT_NULL)
        {
            yield return new WaitForSeconds(Contents.WaitTime);
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
        int damage = Contents.INT_NULL;
        yield return new WaitForSeconds(1f);
        //見方の攻撃
        //＊＊＊＊攻撃は一番左を狙う
        switch(playerSelect)
        {
            case 1://攻撃
                //_battleCanvas.UpdateDialog(ResouceDataBase.instance.BattleText);
                foreach (CharaStatus e in enemies)
                {
                    damage = DamageCalculation(player, e);
                    damage = (int)(damage*Contents.SINGLE_ATTACK_DAMAGE_COLLECTION);
                    if (e.HP > 0) { e.damageHP(damage); break; }
                }
                break;

            case 2://魔法
                //_battleCanvas.UpdateDialog(ResouceDataBase.instance.BattleText);
                foreach (CharaStatus e in enemies) {
                    damage = DamageCalculation(player, e);
                    e.damageHP(damage);
                }
                break;
            case 3://回復
                //_battleCanvas.UpdateDialog(ResouceDataBase.instance.BattleText);
                player.HealHP((int)(Player.Max_hp* Contents.HEAL_EFFECT_RATE));
                break;
            default:
                Debug.LogError("入力判定が想定外です!");
                break;
        }
        UpdateHP();
        //_battleCanvas.UpdateDialog(ResouceDataBase.instance.BattleText);
        //敵の攻撃
        foreach (CharaStatus e in enemies)
        {
            if (e.HP > 0) {player.damageHP((int)(e.Atk));}
        }
        //生死判定
        if (enemies.All(e => e.HP == 0))
        {
            int exp = 0;
            foreach (CharaStatus e in enemies)
            {
                exp += ExperienceDataBase.instance.SetEnemyExp(player, e);
            }
            GameSystem.instance.PrassExp(exp);
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
        battleTurn = Contents.INT_NULL;
        //敵のリソース情報を読み込む
        SetBattleText(ResourceDataBase.instance.GameProgression[GameManager.instance.SceneID].SceneName);
        //最初のゲーム敵配置
        SetBackground();
        GetPlayableChara();
        GetEnemyChara();
        SetChara();
        _battleCanvas.ResetDialog();
        _battleCanvas.CloseLoading();
        //バトルのセット
        SetBattle();
    }
    //２戦目以降の設定
    private void NextStart()
    {
        Debug.Log("BattleSystem.NextStart");
        battleTurn++;
        //次のバトルシーンがある場合、セット
        try
        {
            SetBackground();
            GetEnemyChara();
            SetChara();
            //バトルのセット
            SetBattle();
        }
        catch
        {
            _battleCanvas.OpenLoading();
            UpdateScene();
        }     
    }
    //テキストを更新する処理
    private void UpdateText(string text)
    {
        Debug.Log("BattleSystem.UpdateText");
        _battleCanvas.UpdateDialog(text);
    }
    //テキストを準備する処理
    private void SetText()
    {
        Debug.Log("BattleSystem.SetText");
        string text = "";
        UpdateText(text);
    }
    //テキストを読み込む処理
    private string GetText(int textNumber)
    {
        return ResourceDataBase.instance.BattleText[textNumber];
    }
    //背景をセットするための処理
    private void SetBackground()
    {
        Debug.Log("BattleSystem.SetBackground");
        Sprite bg = ResourceDataBase.instance.SearchBattleBack(ResourceDataBase.instance.GameBattleInfo[battleTurn].background);
        _battleCanvas.ChangeBackGround();
        //_battleCanvas.ChangeBackGround(bg);
    }
    //CharaUIをセットする関数
    private void SetChara()
    {
        Debug.Log("BattleSystem.SetChara");
        _battleCanvas.UpdateHeroData(Player);
        for(int i =0;i<Enemies.Count;i++)
        {
            if (Enemies[i].Chara!=null)
            {
                _battleCanvas.UpdateOtherData(enemies[i], i);
            }
        }
        for(int i = Contents.MAX_ENEMIES_NUM-1; i > Enemies.Count-1; i--)
        {
            _battleCanvas.CloseOthers(i, Contents.INT_NULL, Contents.INT_NULL);
        }
    }
    //プレイヤーの情報を格納する
    private void GetPlayableChara()
    {
        Debug.Log("BattleSystem.GetPlayableChara");
        player = new CharaStatus(CharaDataBase.instance.OutputStoryChara(), GameManager.instance.PlayerLv);
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
        GameSystem.instance.ChangeScene();
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
    public void SetBattleText(string sceneName)
    {
        Debug.Log("BattleSystem.SetBattleText");
        //通常はfileIDのデータを呼び出す
        ResourceDataBase.instance.SetupBattleText(sceneName);
    }
    //死に戻り処理
    private void PlayerDeath()
    {
        Debug.Log("player death");
        GameSystem.instance.PlayerDeathReturn();
    }

    #endregion
    #endregion

    #region ダメージ計算
    public int DamageCalculation(CharaStatus atk,CharaStatus dfn)
    {
        float damage = 0;
        //通常ダメージ
        damage = atk.Atk;
        //ダメバフ補正
        //レベル補正
        damage*= LevelDifferenceCcorrection(atk,dfn);
        //属性相性
        damage *= AttributeCorrection(atk.Attribute, dfn.Attribute);
        //防御補正
        damage *= DefenseModifier(atk, dfn);
        Debug.Log("総量ダメージ："+damage);
        return (int)damage;
    }
    //レベル差補正
    public float LevelDifferenceCcorrection(CharaStatus atk, CharaStatus dfn)
    {
        return 1f+0.05f*(atk.Lv - dfn.Lv)/10;
    }
    //属性補正
    public float AttributeCorrection(Attribute atkAt,Attribute defAt)
    {
        //炎と氷
        if (atkAt == Attribute.Fire && defAt == Attribute.Ice) return 1.3f;
        if (atkAt == Attribute.Ice && defAt == Attribute.Fire) return 0.7f;
        //氷と風
        if (atkAt == Attribute.Ice && defAt == Attribute.Wind) return 1.1f;
        if (atkAt == Attribute.Wind && defAt == Attribute.Ice) return 0.9f;
        //氷と岩
        if (atkAt == Attribute.Ice && defAt == Attribute.Rock) return 1.1f;
        if (atkAt == Attribute.Rock && defAt == Attribute.Ice) return 0.9f;
        //雷と氷
        if (atkAt == Attribute.Elec && defAt == Attribute.Ice) return 1.1f;
        if (atkAt == Attribute.Ice && defAt == Attribute.Elec) return 0.9f;
        //雷と岩
        if (atkAt == Attribute.Elec && defAt == Attribute.Rock) return 1.1f;
        if (atkAt == Attribute.Rock && defAt == Attribute.Elec) return 0.9f;
        //風と炎
        if (atkAt == Attribute.Wind && defAt == Attribute.Fire) return 1.2f;
        if (atkAt == Attribute.Fire && defAt == Attribute.Wind) return 0.8f;
        //風と雷
        if (atkAt == Attribute.Wind && defAt == Attribute.Elec) return 1.1f;
        if (atkAt == Attribute.Elec && defAt == Attribute.Wind) return 0.9f;
        //岩と風
        if (atkAt == Attribute.Rock && defAt == Attribute.Wind) return 1.2f;
        if (atkAt == Attribute.Wind && defAt == Attribute.Rock) return 0.7f;
        //岩と炎
        if (atkAt == Attribute.Rock && defAt == Attribute.Fire) return 1.1f;
        if (atkAt == Attribute.Fire && defAt == Attribute.Rock) return 0.9f;

        return 1f;
    }
    //防御補正
    public float DefenseModifier(CharaStatus atk, CharaStatus dfn)
    {
        return atk.Atk * 100 / (100 + dfn.Dfn);
    }
    #endregion
}
