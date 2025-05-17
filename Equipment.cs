using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equipment : ScriptableObject
{
    [SerializeField] string equiName;
    [SerializeField] Sprite sprite;
    [SerializeField] int rarity;

    public string EquiName { get => equiName;}
    public Sprite Sprite { get => sprite; }
    public float PrassHPrate => GetPrassRate(rarity);
    public float PrassATKrate => GetPrassRate(rarity);
    public float PrassDfnrate => GetPrassRate(rarity);

    private float GetPrassRate(int rarity)
    {
        switch (rarity)
        {
            case 1: return 0.2f;
            case 2: return 0.35f;
            case 3: return 0.50f;
            case 4: return 0.65f;
            case 5: return 0.75f;
            default: return 0.2f;
        }
    }

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