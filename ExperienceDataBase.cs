using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceDataBase : MonoBehaviour
{
    //自身のインスタンス化
    public static ExperienceDataBase instance = null;

    [SerializeField] List<int> charaExperience = new List<int>();



    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    /// <summary>
    /// 初期設定
    /// </summary>
    void Start()
    {
        SetCharaExpList();
    }
    /// <summary>
    /// charaExperienceの設定
    /// </summary>
    private void SetCharaExpList()
    {
        charaExperience.Clear();
        charaExperience = new List<int>
        {
            1000, 1325, 1700, 2150, 2625, 3150, 3725, 4350, 5000, 5700,
            6450, 7225, 8050, 8925, 9825, 10750, 11725, 12725, 13775, 14875,
            16800, 18000, 19250, 20550, 21875, 23250, 24650, 26100, 27575, 29100,
            30650, 32250, 33875, 35550, 37250, 38975, 40750, 42575, 44425, 46300,
            50625, 52700, 54775, 56900, 59075, 61275, 63525, 65800, 68125, 70475,
            76500, 79050, 81650, 84275, 86950, 89650, 92400, 95175, 98000, 100875,
            108950, 112050, 115175, 118325, 121525, 124775, 128075, 131400, 134775, 138175,
            148700, 152375, 156075, 159825, 163600, 167425, 171300, 175225, 179175, 183175,
            216225, 243025, 273100, 306800, 344600, 386950, 434425, 487625, 547200, 8362650 // level 90 MAX
        };
    }
    /// <summary>
    /// Expのデータを渡す処理
    /// </summary>
    /// <param name="playerLv">プレイヤーレベル</param>
    /// <returns></returns>
    public int OutputCharaExp(int playerLv)
    {
        if(playerLv== Contents.PLAYER_LV_MAX)
        {
            Debug.LogError("プレイヤーは経験値を得ることができません");
            return Contents.INT_NULL;
        }
        return charaExperience[playerLv-1];
    }
    /// <summary>
    /// 敵が落とす経験値量を設定する処理
    /// </summary>
    /// <param name="player">プレイヤーステータス</param>
    /// <param name="enemy">エネミーステータス</param>
    /// <returns></returns>
    public int SetEnemyExp(CharaStatus player ,CharaStatus enemy)
    {
        int baseExp = enemy.Chara.Basic_experience;
        float ld = 1f;
        if (player.Lv - enemy.Lv>=15)
        {
            ld = 0.03f;
        }
        else if(player.Lv - enemy.Lv>=10)
        {
            ld = 0.1f;
        }
        else if(player.Lv - enemy.Lv>=7)
        {
            ld = 0.6f;
        }
        else if(player.Lv - enemy.Lv>=4)
        {
            ld = 0.9f;
        }
        else if(player.Lv - enemy.Lv>=1)
        {
            ld = 1f;
        }
        else if(player.Lv - enemy.Lv>=-1)
        {
            ld = 1.1f;
        }
        else if(player.Lv - enemy.Lv>=-3)
        {
            ld = 1.3f;
        }
        else if (player.Lv - enemy.Lv >= -5)
        {
            ld = 1.5f;
        }
        else if (player.Lv - enemy.Lv >= -7)
        {
            ld = 1.7f;
        }
        else if (player.Lv - enemy.Lv >= -10)
        {
            ld = 1.9f;
        }
        else if (player.Lv - enemy.Lv >= -15)
        {
            ld = 2.0f;
        }
        else
        {
            ld = 2.15f;
        }


        float sd = 1f;//アイテムによる効果    
        return (int)(baseExp * ld * sd);
    }


}
