using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StorySystem : MonoBehaviour
{
    [SerializeField] StoryCanvas _storyCanvas;

    [SerializeField] int storyID;
    [SerializeField] Chara chara1;
    [SerializeField] Chara chara2;
    [SerializeField] int speakerID;
    [SerializeField] int textID;
    [SerializeField] bool isSkip;

    private void Start()
    {
        UpdateCharaSprite();
    }
    private void UpdateCharaSprite()
    {

    }
}
