using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySystem : MonoBehaviour
{
    [SerializeField] StoryCanvas _storyCanvas;

    [SerializeField] int storyID;
    [SerializeField] int chara1ID;
    [SerializeField] int chara2ID;
    [SerializeField] int textID;
    [SerializeField] bool isSkip;
}
