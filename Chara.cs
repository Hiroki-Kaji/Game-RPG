using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Chara")]
public class Chara : ScriptableObject
{
    [SerializeField]int id;
    [SerializeField] string charaName;
    [SerializeField] Sprite charaSprite;
    [SerializeField] int basicHP;
    [SerializeField] int basicAtk;
    [SerializeField] string skillName;

    public int Id { get => id;}
    public string CharaName { get => charaName;}
    public Sprite CharaSprite { get => charaSprite;}
    public int BasicHP { get => basicHP;}
    public int BasicAtk { get => basicAtk;}
    public string SkillName { get => skillName;}
}
