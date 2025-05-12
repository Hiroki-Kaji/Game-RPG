using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BattleCanvas : MonoBehaviour
{
    #region 変数/参照
    [SerializeField] Image Hero;
    [SerializeField] Image[] Enemies = { };
    [SerializeField] Text HeroHP;
    [SerializeField] Text[] EnemiesHP;
    [SerializeField] GameObject Dialog;
    [SerializeField] TextMeshProUGUI DialogText;
    [SerializeField] GameObject Buttons;
    [SerializeField] Button AtkButton;
    [SerializeField] Button MagicButton;
    [SerializeField] Button HealButton;
    [SerializeField] Image Background;
    [SerializeField] Image Loading;
    #endregion
    #region 関数名
    #endregion
}
