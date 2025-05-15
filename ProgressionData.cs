using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ProgressionData")]
public class ProgressionData : ScriptableObject
{
    [SerializeField] string sceneName;
    [SerializeField] TYPE type;

    public string SceneName { get => sceneName; }
    public TYPE Type { get => type;}

    public enum TYPE
    {
        Story,    
        Battle,  
    }
}


