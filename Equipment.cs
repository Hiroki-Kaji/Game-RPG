using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : ScriptableObject
{
    [SerializeField] string equiName;
    [SerializeField] Sprite sprite;
    [SerializeField] int rarity;
    [SerializeField] float prassHPrate;
    [SerializeField] float prassATKrate;
    [SerializeField] float prassDfnrate;

    public string EquiName { get => equiName;}
    public Sprite Sprite { get => sprite; }
    public float PrassHPrate { get => prassHPrate; }
    public float PrassATKrate { get => prassATKrate; }
    public float PrassDfnrate { get => prassDfnrate; }

}

[CreateAssetMenu(menuName = "Equipment.Weapon")]
public class Weapon :Equipment
{
    [SerializeField] int prassATK;
    public int PrassATK { get => prassATK;  }
}

[CreateAssetMenu(menuName = "Equipment.Armer")]
public class Armer : Equipment
{
    [SerializeField] int prassDFN;
    public int PrassDFN { get => prassDFN; }

}
[CreateAssetMenu(menuName = "Equipment.Ring")]
public class Ring : Equipment
{
    [SerializeField] Attribute attribute;

    public Attribute Attribute { get => attribute; }
}