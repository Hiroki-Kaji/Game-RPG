using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleCanvas : MonoBehaviour
{
    #region 変数/参照
    [SerializeField] Image Hero;
    [SerializeField] Image[] Enemies = { };
    [SerializeField] TextMeshProUGUI HeroHP;
    [SerializeField] TextMeshProUGUI [] EnemiesHP;
    [SerializeField] TextMeshProUGUI HeroLv;
    [SerializeField] TextMeshProUGUI[] EnemiesLv;
    [SerializeField] GameObject Dialog;
    [SerializeField] List<TextMeshProUGUI> DialogText = new List<TextMeshProUGUI>();
    [SerializeField] GameObject Buttons;
    [SerializeField] Button AtkButton;
    [SerializeField] Button MagicButton;
    [SerializeField] Button HealButton;
    [SerializeField] Image Background;
    [SerializeField] Image Loading;
    #endregion
    #region 関数名
    private void Start()
    {
        GUIStyle style = new GUIStyle();
        style.richText = true;
    }
    /// <summary>
    /// ダイアログをSetActive(true)する関数
    /// </summary>
    public void OpenDialog()
    {
        
    }
    /// <summary>
    /// ダイアログをSetActive(false)する関数
    /// </summary>
    public void CloseDialog()
    {

    }
    /// <summary>
    /// ダイアログの全体を空白にする処理
    /// </summary>
    public void ResetDialog()
    {

    }
    /// <summary>
    /// ダイアログのTextを書き換える関数（完成済）
    /// </summary>
    public void UpdateDialog(string text)
    {
        //もし、logが空ならtextを途中に呼ぶ
        foreach (var item in DialogText)
        {
            if (item.text == "")
            {
                item.text = text; return;
            }
        }
        //DialogText[7]に新しいのを追加
        for (int num=0; num<DialogText.Count-1; num++)
        {
            DialogText[num].text = DialogText[num+1].text;
        }
        DialogText[DialogText.Count-1].text =  text;
    }
    /// <summary>
    /// HeroをSetActive(true)する関数
    /// </summary>
    public void OpenHero()
    {

    }
    /// <summary>
    /// HeroをSetActive(false)する関数
    /// </summary>
    public void CloseHero()
    {

    }
    /// <summary>
    /// Heroの情報を書き換える関数
    /// </summary>
    public void UpdateHeroData(CharaStatus player)
    {
        //スプライトの更新
        //HPtextの初期設定
        //Lvの表示
    }
    /// <summary>
    /// HeroHPのTextを書き換える関数
    /// </summary>
    public void UpdateHeroHP()
    {

    }
    /// <summary>
    /// Other[引数]をSetActive(true)する関数 引数2以降はnullの時実行しない
    /// </summary>
    public void OpenOthers(int other1, int other2, int other3)
    {
        Enemies[other1].gameObject.SetActive(true);
        //残りの記述
    }
    /// <summary>
    /// Other[引数]をSetActive(false)する関数 引数2以降はnullの時実行しない
    /// </summary>
    public void CloseOthers(int other1, int other2, int other3)
    {

    }
    /// <summary>
    /// OtherDataの情報を書き換える関数
    /// </summary>
    public void UpdateOtherData(CharaStatus other, int enemyNum)
    {
        //Spriteの表示
        //Lvの表示
    }
    /// <summary>
    /// OtherHPのTextを書き換える関数
    /// </summary>
    public void UpdateOtherHP(string hp, int enemyNum)
    {
        
    }
    /// <summary>
    /// ButtonsをSetActive(true)する関数
    /// </summary>
    public void OpenButtons()
    {

    }
    /// <summary>
    /// ButtonsをSetActive(false)する関数
    /// </summary>
    public void CloseButtons()
    {

    }
    /// <summary>
    /// 背景を変更する関数
    /// </summary>
    public void ChangeBackGround()
    {
        //現状は同じものを貼る
    }
    /// <summary>
    /// LoadingをSetActive(true)する関数		
    /// </summary>
    public void OpenLoading()
    {

    }
    /// <summary>
    /// LoadingをSetActive(false)する関数		
    /// </summary>
    public void CloseLoading()
    {

    }

    #endregion
}
