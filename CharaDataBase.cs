using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaDataBase : MonoBehaviour
{
    public static CharaDataBase instance;

    [SerializeField] public List<Chara>playableChara = new List<Chara>();
    [SerializeField] public List<Chara>nonPlayableChara = new List<Chara>();

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

    public Chara SearchChara(string charaName)
    {
        Debug.Log("CharaDataBase.SearchChara");
        return nonPlayableChara[0];
    }

}
