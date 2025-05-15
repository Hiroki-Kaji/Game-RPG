using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameSystem : MonoBehaviour
{
    #region 変数/参照
    //自身のインスタンス化
    public static GameSystem instance = null;
    #endregion

    #region メソッド
    /// <summary>
    /// インスタンス化
    /// </summary>
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
    /// 経験値を増やす処理、レベルが上がったら経験値分リセット
    /// </summary>
    public void PrassExp(float exp)
    {
        Debug.Log("GameSystem.PrassExp");
        exp += GameManager.instance.PlayerExp;
        while(exp >=100)
        {
            if(exp >= 100)
            {
                exp -=100;
                GameManager.instance.LevelUp();
            }
        }
        GameManager.instance.SaveExp(exp);
    }

    public void SetPlayerName(string name)
    {
        GameManager.instance.SetPlayerName(name);
    }

    public void ChangeScene()
    {
        GameManager.instance.ForwardScene();
        try
        {
            Debug.Log(GameManager.instance.SceneID);
            switch (ResourceDataBase.instance.GameProgression[GameManager.instance.SceneID].Type)
            {
                case ProgressionData.TYPE.Story:
                    ChangeStoryScene();
                    break;
                case ProgressionData.TYPE.Battle:
                    ChangeBattleScene();
                    break;
                default:
                    Debug.LogError("存在しないシーンタイプです");
                    break;
            }
        }
        catch
        {
            ChangeEndScene();
        }
    }
    /// <summary>
    /// バトルシーンに切り替える
    /// </summary>
    private void ChangeBattleScene()
    {
        SceneManager.LoadScene("BattleScene");
    }
    /// <summary>
    /// ストーリーシーンに切り替える
    /// </summary>
    private void ChangeStoryScene()
    {
        SceneManager.LoadScene("StoryScene");
    }

    public void ChangeFirstScene()
    {
        SceneManager.LoadScene("FirstScene");
    }

    private void ChangeEndScene()
    {
        SceneManager.LoadScene("EndScene");
    }
    #endregion
}
