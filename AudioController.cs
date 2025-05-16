using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] List<AudioClip> bGMList = new List<AudioClip>();
    [SerializeField] List<AudioClip> soundList = new List<AudioClip>();

    /// <summary>
    /// インスタンス化
    /// </summary>
    private void Awake()
    {
        
    }
    /// <summary>
    /// BGMを出力する
    /// </summary>
    public void OutputBGM()
    {

    }
    /// <summary>
    /// 効果音を出力する
    /// </summary>
    public void OutputSound()
    {

    }
}
