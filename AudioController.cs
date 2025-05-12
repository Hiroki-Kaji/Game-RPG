using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    public static AudioController instance;

    [SerializeField] List<AudioClip> bGMList = new List<AudioClip>();
    [SerializeField] List<AudioClip> soundList = new List<AudioClip>();

}
