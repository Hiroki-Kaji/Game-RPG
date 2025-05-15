using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FirstSystem: MonoBehaviour
{
    [SerializeField]TMP_InputField field;
    [SerializeField] Button startButton;
    // Start is called before the first frame update
    public void OnSetField()
    {
        if (field != null)
        { GameSystem.instance.SetPlayerName(field.text); }
        else 
        { GameSystem.instance.SetPlayerName("éÂêlåˆ"); }
            
    }

    public void OnStartButton()
    {
        GameSystem.instance.ChangeScene();
    }
}
