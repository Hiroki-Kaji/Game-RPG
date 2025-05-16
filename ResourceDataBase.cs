using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceDataBase : MonoBehaviour
{
    #region 変数/参照
    //自身のインスタンス化
    public static ResourceDataBase instance = null;

    [SerializeField] public TextDataWrapper GameStoryInfo;
    [SerializeField] public List<BattleData>GameBattleInfo =new List<BattleData>();
    [SerializeField] public List<string> BattleText = new List<string>();
    [SerializeField] public List<ProgressionData> GameProgression = new List<ProgressionData>();
    [SerializeField] public List<Sprite>BGsprite = new List<Sprite>();
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
    }

    //ストーリーのテキストを呼び出す
    public void SetupStoryText(string filename)
    {
        Debug.Log("ResourceDataBase.SetupStoryText");
        TextAsset jsonFile = Resources.Load<TextAsset>("Texts/"+filename);

        if (jsonFile != null) {
            TextDataWrapper wrapper = JsonUtility.FromJson<TextDataWrapper>(jsonFile.text);
            if (wrapper == null || wrapper.lines == null) {
            Debug.LogError("JSONのパースに失敗しました。形式を確認してください。");
            return;
        }
            GameStoryInfo.title = wrapper.title;
            GameStoryInfo.areaName = wrapper.areaName;
            GameStoryInfo.lines = new List<TextData>(wrapper.lines);

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
        Debug.Log("ResourceDataBase.SetupBattleText");
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
            Chara chara1 = CharaDataBase.instance.SearchEnemyChara(GameBattleInfo[BattleID].enemy1);
            charas[0] = new CharaStatus(chara1, GameBattleInfo[BattleID].enemy1_lv);
        }
        else
        {
            Debug.LogError("データ読み取りに失敗しました。実行順を確認してください。");
        }
        if (GameBattleInfo[BattleID].enemy2 != "")
        { 
            Chara chara2 = CharaDataBase.instance.SearchEnemyChara(GameBattleInfo[BattleID].enemy2);
            charas[1] = new CharaStatus(chara2, GameBattleInfo[BattleID].enemy2_lv);
            //Debug.Log("キャラ2追加");
        }
        if (GameBattleInfo[BattleID].enemy3 != "")
        {   
            Chara chara3 = CharaDataBase.instance.SearchEnemyChara(GameBattleInfo[BattleID].enemy3);
            charas[2] = new CharaStatus(chara3, GameBattleInfo[BattleID].enemy3_lv);
            //Debug.Log("キャラ3追加");
        }
        
        return charas;
    }

    /// <summary>
    /// フォルダから指定した名前のスプライトを検索します。
    /// </summary>
    /// <param name="name">検索するスプライトの名前（拡張子なし）</param>
    /// <returns>該当するスプライトが見つかれば返し、見つからなければ null を返します。</returns>
    public Sprite SearchStoryBack(string name)
    {
        Debug.Log("ResourceDataBase.SearchStoryBack");
        // Resources フォルダ内の指定パスからスプライトを検索
        Sprite sprite = Resources.Load<Sprite>($"Arts/StoryBack/{name}");

        // スプライトが見つからなければ null を返す
        if (sprite == null)
        {
            Debug.LogWarning($"スプライト '{name}' が Resources/Arts/StoryBack フォルダ内に見つかりませんでした。");
        }

        return sprite;
    }

    public Sprite SearchBattleBack(string name)
    {
        Debug.Log("ResourceDataBase.SearchBattleBack");
        // Resources フォルダ内の指定パスからスプライトを検索
        Sprite sprite = Resources.Load<Sprite>($"Arts/BattleBack/{name}");

        // スプライトが見つからなければ null を返す
        if (sprite == null)
        {
            Debug.LogWarning($"スプライト '{name}' が Resources/Arts/BattleBack フォルダ内に見つかりませんでした。");
        }

        return sprite;
    }
    #endregion
}
