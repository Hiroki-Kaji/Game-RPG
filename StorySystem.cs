using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StorySystem : MonoBehaviour
{
    [SerializeField] StoryCanvas _storyCanvas;
    [SerializeField] int storyID;
    [SerializeField] Chara chara1;
    [SerializeField] Chara chara2;
    [SerializeField] int speakerID;
    [SerializeField] int textID;
    [SerializeField] bool isSkip;//スキップ機能のフラグ？
                                 //trueの時OpenLoading()を呼び出しシーンの切り替えまで飛ぶ？
                                 //ResourceDataBaseインスタンス化
                                 //textData[]からテキストをもらう
                                 //
                                 //シーン切り替えで使うかも
                                 //OpenLoading()どこで呼び出す？
                                 //CloseDialog()
                                 //CloseHero()
                                 //CloseOther()
                                 //CloseLoading()
    private void Start()
    {
        // とりあえずfalse?
        isSkip = false;
        UpdateCharaSprite();
    }
    /// <summary>
    /// StoryCanvasの表示を指示するメソッド
    /// </summary>
    private void UpdateCharaSprite()
    {
        if (_storyCanvas == null) return;
        // キャラクター1の表示と設定
        if (chara1 != null)
        {
            _storyCanvas.OpenHero();
            // Charaから立ち絵と顔座標を設定
            _storyCanvas.SetHero(chara1.CharaSprite, chara1.FaceCoordinates);
        }
        else
        {
            _storyCanvas.CloseHero();
        }
        // キャラクター2の表示と設定
        if (chara2 != null)
        {
            _storyCanvas.OpenOther();
            // Charaから立ち絵と顔座標を設定
            //_storyCanvas.SetOther(chara2.CharaSprite, chara2.FaceCoordinates);
        }
        else
        {
            _storyCanvas.CloseOther();
        }
        //アクティブキャラの切り替え
        //Hero 1
        //Other 2
        // 話者に注目させ、そうでない方はグレーアウトする
        if (speakerID == 1)
        {
            _storyCanvas.StartAttentionHero();
            _storyCanvas.StopAttentionOther();
        }
        else if (speakerID == 2)
        {
            _storyCanvas.StartAttentionOther();
            _storyCanvas.StopAttentionHero();
        }
        // CharaデータとEmotion設定から、表示すべき顔スプライトを取得する
        Sprite heroFaceSprite = GetSpriteForEmotion(chara1);
        Sprite otherFaceSprite = GetSpriteForEmotion(chara2);
        // StoryCanvasに顔スプライトの設定を指示
        _storyCanvas.SetHeroFace(heroFaceSprite);
        //_storyCanvas.SetOtherFace(otherFaceSprite);
        // //charaとは関係ないのでメソッド分けた方がいいかも？
        // // ダイアログの表示とテキスト更新
        // _storyCanvas.OpenDialog();
        // _storyCanvas.UpdateDialog(textID);//わからないのでとりあえず引数にしている
        // //背景の更新
        // _storyCanvas.ChangeBackGround(storyID);//わからないのでとりあえず引数にしている
    }
    private Sprite GetSpriteForEmotion(Chara chara)
    {
        /*if (chara == null) return null;
        switch (chara)
        {
            case Chara.Normal: return chara.Normal;
            case Chara.Angry: return chara.Angry;
            case Chara.Smile: return chara.Smile;
            case Chara.Trouble: return chara.Trouble;
            case Chara.Surprise: return chara.Surprise;
            case Chara.Hurt: return chara.Hurt;
            case Chara.Embarrassing: return chara.Embarrassing;
            case Chara.Agree: return chara.Agree;
            default: return chara.Normal; // 不明な場合は通常顔を返す
        }*/
        return chara.Normal;
    }
}
