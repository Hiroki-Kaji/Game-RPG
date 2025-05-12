using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    #region 変数/参照
    [SerializeField] BattleSystem _battleCanvas;
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
        
    }
    /// <summary>
    /// Playerの選択が変わるまで行うバトル関数
    /// </summary>
    /// <returns></returns>
    private IEnumerator WaitPlayerSelect()
    {
        yield return new WaitForSeconds(1f);
    }
    /// <summary>
    /// 選択したパターンの攻撃を行うバトル関数
    /// </summary>
    /// <returns></returns>
    private IEnumerator MainBattleTurn()
    {
        yield return new WaitForSeconds(1f);
    }
    /// <summary>
    /// 毒ダメージなどの攻撃を受けるバトル関数
    /// </summary>
    /// <returns></returns>
    private IEnumerator SubBattleTurn()
    {
        yield return new WaitForSeconds(1f);
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
        GetEnemyData();
        //バトルのセット
        SetBattle();
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

    }
    //CharaUIをセットする関数
    private void SetChara()
    {

    }
    //プレイヤーの情報を格納する
    private CharaStatus GetPlayableChara()
    {
        return null;
    }
    //エネミーの情報を格納する
    private CharaStatus GetEnemyChara()
    {
        
        return null;
    }
    //シーンを変更する
    private void UpdateScene()
    {

    }
    //Canvasから選択肢を受け取り、行動を決定する処理
    public void DecideSelect(int selectNumber)
    {

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
    //ResouceDataBaseからバトルフェーズの敵情報を取得する方法
    public void GetEnemyData()
    {
        Debug.Log("BattleSystem.GetEnemyData");
        enemies = ResourceDataBase.instance.OutputEnemysInfo(battleTurn);
        Debug.Log(enemies[0]);
    }
    #endregion
    #endregion
}
