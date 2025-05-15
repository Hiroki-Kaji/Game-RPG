using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [SerializeField] List<AudioClip> bGMList = new List<AudioClip>();
    [SerializeField] List<AudioClip> soundList = new List<AudioClip>();

    /// <summary>
    /// �C���X�^���X��
    /// </summary>
    private void Awake()
    {
        
    }
    /// <summary>
    /// �w�肳�ꂽBGM�𗬂��֐�
    /// </summary>
    public void OutputBGM()
    {

    }
    /// <summary>
    /// �w�肳�ꂽ���ʉ��𗬂��֐�
    /// </summary>
    public void OutputSound()
    {

    }
}
