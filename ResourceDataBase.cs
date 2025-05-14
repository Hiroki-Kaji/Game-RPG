using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDataBase : MonoBehaviour
{
    #region 変数/参照
    //自身のインスタンス化
    public static ResourceDataBase instance = null;

    [SerializeField] public List<TextData>GameStoryInfo =new List<TextData>();
    [SerializeField] public List<BattleData>GameBattleInfo =new List<BattleData>();
    [SerializeField] public List<string> BattleText = new List<string>();
    #endregion
    #region 関数名
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

    private void Start()
    {
        SetupStoryText("sample");
        //SetupBattleText("sample");
    }
    //ストーリーのテキストを呼び出す
    public void SetupStoryText(string filename)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Texts/"+filename);

        if (jsonFile != null) {
            TextDataWrapper wrapper = JsonUtility.FromJson<TextDataWrapper>(jsonFile.text);
            if (wrapper == null || wrapper.lines == null) {
            Debug.LogError("JSONのパースに失敗しました。形式を確認してください。");
            return;
        }
            GameStoryInfo = new List<TextData>(wrapper.lines);

            // デバッグ表示
            // foreach (var line in GameStoryInfo) {
            //     Debug.Log($"ID: {line.id}, Speaker: {line.speakerID}, Text: {line.text}");
            // }
        } else {
            Debug.LogError("sample.json が読み込めませんでした。Resources/Texts に正しく置かれているか確認してください。");
        }
    }

    public void SetupBattleText(string filename)
    {
        TextAsset jsonFile = Resources.Load<TextAsset>("Battles/" + filename);

        if (jsonFile != null)
        {
            BattleDataWrapper wrapper = JsonUtility.FromJson<BattleDataWrapper>(jsonFile.text);
            if (wrapper == null || wrapper.lines == null)
            {
                Debug.LogError("JSONのパースに失敗しました。形式を確認してください。");
                return;
            }
            GameBattleInfo = new List<BattleData>(wrapper.lines);

            // デバッグ表示
            /*foreach (var line in GameBattleInfo) {
                Debug.Log($"ID: {line.id}, Enemy2: {line.enemy2}, enemy2lv: {line.enemy2_lv}");
            }*/
        }
        else
        {
            Debug.LogError("sample.json が読み込めませんでした。Resources/Texts に正しく置かれているか確認してください。");
        }
    }
    //エネミーの情報を出力する
    public CharaStatus[] OutputEnemysInfo(int BattleID)
    {
        Debug.Log("ResourceDataBase.OutputEnemyInfo");
        CharaStatus[] charas = new CharaStatus[3];
        //キャラの検索
        if (GameBattleInfo[BattleID].enemy1 != "")
        {   
            Chara chara1 = CharaDataBase.instance.SearchChara(GameBattleInfo[BattleID].enemy1);
            charas[0] = new CharaStatus(chara1, GameBattleInfo[BattleID].enemy1_lv);
            Debug.Log("キャラ1追加");
        }
        else
        {
            Debug.LogError("データ読み取りに失敗しました。実行順を確認してください。");
        }
        if (GameBattleInfo[BattleID].enemy2 != "")
        { 
            Chara chara2 = CharaDataBase.instance.SearchChara(GameBattleInfo[BattleID].enemy2);
            charas[1] = new CharaStatus(chara2, GameBattleInfo[BattleID].enemy2_lv);
            Debug.Log("キャラ2追加");
        }
        if (GameBattleInfo[BattleID].enemy3 != "")
        {   
            Chara chara3 = CharaDataBase.instance.SearchChara(GameBattleInfo[BattleID].enemy3);
            charas[2] = new CharaStatus(chara3, GameBattleInfo[BattleID].enemy3_lv);
            Debug.Log("キャラ3追加");
        }
        
        return charas;
    }
    #endregion
}
