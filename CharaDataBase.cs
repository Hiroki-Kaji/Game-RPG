using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaDataBase : MonoBehaviour
{
    public static CharaDataBase instance;

    [SerializeField] private List<Chara>storyChara = new List<Chara>();
    [SerializeField] private List<Chara>enemyChara = new List<Chara>();

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
    /// �G�L�����N�^�[�𖼑O����T�������i��Փx���j
    /// </summary>
    /// <param name="charaName"></param>
    /// <returns></returns>
    public Chara SearchEnemyChara(string charaName)
    {
        Debug.Log("CharaDataBase.SearchChara");
        //�G�̃L�����̕��J��Ԃ�
        //����charaName �� Chara.charaname����v������
        //Chara��return����B
        return enemyChara[0];
    }
    /// <summary>
    /// �w�肳�ꂽ�L�������𑗂�֐�
    /// </summary>
    /// <returns></returns>
    public Chara OutputStoryChara()
    {
        return storyChara[0];
    }
    /// <summary>
    /// �w�肳�ꂽ�L�������𑗂�֐�
    /// </summary>
    /// <returns></returns>
    public Chara OutputEnmeyChara()
    {
        return enemyChara[0];
    }

}
