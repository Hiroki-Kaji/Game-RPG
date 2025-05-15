using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StoryCanvas : MonoBehaviour
{
    [SerializeField] Image Hero;
    [SerializeField] Image HeroFace;
    [SerializeField] Image Other;
    [SerializeField] Image OtherFace;
    [SerializeField] GameObject Dialog;
    [SerializeField] TextMeshProUGUI DialogText;
    [SerializeField] Button NextButton;
    [SerializeField] Image Frontground;
    [SerializeField] Image Background;
    [SerializeField] Image Loading;

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
    /// ダイアログのTextを書き換える関数
    /// </summary>
    public void UpdateDialog()
    {
        
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
    /// キャラ画像をセットする。顔差分の位置を決定する
    /// </summary>
    /// <param name="sprite">キャライラスト</param>
    /// <param name="facePoints">顔座標</param>
    public void SetHero(Sprite sprite, Vector2 facePoints)
    {
        //キャラ画像を設定する
        //image.gameobject.transform.localPositonを変更する
    }
    /// <summary>
    /// Heroの顔イラスト変更する関数
    /// </summary>
    /// <param name="sprite">顔イラスト</param>
    public void SetHeroFace(Sprite sprite)
    {
        //キャラ顔画像を設定する
    }
    /// <summary>
    /// OtherをSetActive(true)する関数		
    /// </summary>
    public void OpenOther()
    {

    }
    /// <summary>
    /// OtherをSetActive(false)する関数		
    /// </summary>
    public void CloseOther()
    {

    }
    /// <summary>
    /// Heroのイラスト変更する関数
    /// </summary>
    public void SetOther()
    {

    }
    /// <summary>
    /// Otherの顔イラスト変更する関数
    /// </summary>
    public void SetOtherFace()
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

    //以下作成しなくていい部分
    public void StartAttentionHero()
    {
        Hero.color = Color.white;
        HeroFace.color = Color.white;
    }

    public void StopAttentionHero()
    {
        Hero.color = Color.gray;
        HeroFace.color = Color.gray;
    }

    public void StartAttentionOther()
    {
        Other.color = Color.white;
        OtherFace.color = Color.white;
    }

    public void StopAttentionOther()
    {
        Other.color = Color.gray;
        OtherFace.color = Color.gray;
    }
}
