using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExperienceDataBase : MonoBehaviour
{
    //���g�̃C���X�^���X��
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
    /// �����ݒ�
    /// </summary>
    void Start()
    {
        SetCharaExpList();
    }
    /// <summary>
    /// charaExperience�̐ݒ�
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
    /// Exp�̃f�[�^��n������
    /// </summary>
    /// <param name="playerLv">�v���C���[���x��</param>
    /// <returns></returns>
    public int OutputCharaExp(int playerLv)
    {
        if(playerLv== Contents.PLAYER_LV_MAX)
        {
            Debug.LogError("�v���C���[�͌o���l�𓾂邱�Ƃ��ł��܂���");
            return Contents.INT_NULL;
        }
        return charaExperience[playerLv-1];
    }
    /// <summary>
    /// �G�����Ƃ��o���l�ʂ�ݒ肷�鏈��
    /// </summary>
    /// <param name="player">�v���C���[�X�e�[�^�X</param>
    /// <param name="enemy">�G�l�~�[�X�e�[�^�X</param>
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


        float sd = 1f;//�A�C�e���ɂ�����    
        return (int)(baseExp * ld * sd);
    }


}
