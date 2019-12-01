using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    private void Awake()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        
        textUIComp.text = Player.score.ToString();
        print("Odczytana wartosc w end screen: " + textUIComp.text);
    }

}
