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
    [SerializeField] Sprite normal;//����
    [SerializeField] Sprite angry;//�{��
    [SerializeField] Sprite smile;//�Ί�
    [SerializeField] Sprite trouble;//����
    [SerializeField] Sprite surprise;//�т�����
    [SerializeField] Sprite hurt;//�ɂ�
    [SerializeField] Sprite embarrassing;//�p��������
    [SerializeField] Sprite agree;//����
    [SerializeField] Vector2 faceCoordinates;
    public int Id { get => id;}
    public string CharaName { get => charaName;}
    public Sprite CharaSprite { get => charaSprite;}
    public int BasicHP { get => basicHP;}
    public int BasicAtk { get => basicAtk;}
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
}
