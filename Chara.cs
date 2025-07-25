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
    [SerializeField] int basicDfn;
    [SerializeField] string skillName;
    [SerializeField] Sprite normal;//普通
    [SerializeField] Sprite angry;//怒り
    [SerializeField] Sprite smile;//笑顔
    [SerializeField] Sprite trouble;//困り
    [SerializeField] Sprite surprise;//びっくり
    [SerializeField] Sprite hurt;//痛い
    [SerializeField] Sprite embarrassing;//恥ずかしい
    [SerializeField] Sprite agree;//同意
    [SerializeField] Vector2 faceCoordinates;
    [SerializeField] int basic_experience;
    public int Id { get => id;}
    public string CharaName { get => charaName;}
    public Sprite CharaSprite { get => charaSprite;}
    public int BasicHP { get => basicHP;}
    public int BasicAtk { get => basicAtk;}
    public int BasicDfn { get => basicDfn;}
    public string SkillName { get => skillName;}
    public Sprite Normal { get => normal; }
    public Sprite Angry { get => angry; }
    public Sprite Smile { get => smile; }
    public Sprite Trouble { get => trouble; }
    public Sprite Surprise { get => surprise; }
    public Sprite Hurt { get => hurt; }
    public Sprite Embarrassing { get => embarrassing;}
    public Sprite Agree { get => agree;}
    public Vector2 FaceCoordinates { get => faceCoordinates; }
    public int Basic_experience { get => basic_experience; }
}
