using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndScreenScript : MonoBehaviour
{
    private void Awake()
    {
        var textUIComp = GameObject.Find("Score").GetComponent<TMPro.TextMeshProUGUI>();
        print("Odczytana wartosc: " + textUIComp.text);
        textUIComp.text = ScoreScript.instance.score.ToString();

    }

}
