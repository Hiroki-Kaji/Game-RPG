using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [SerializeField] List<AudioClip> bGMList = new List<AudioClip>();
    [SerializeField] List<AudioClip> soundList = new List<AudioClip>();

    /// <summary>
    /// インスタンス化
    /// </summary>
    private void Awake()
    {
        
    }
    /// <summary>
    /// 指定されたBGMを流す関数
    /// </summary>
    public void OutputBGM()
    {

    }
    /// <summary>
    /// 指定された効果音を流す関数
    /// </summary>
    public void OutputSound()
    {

    }
}
