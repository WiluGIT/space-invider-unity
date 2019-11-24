using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControllerS2 : MonoBehaviour
{

    int bossLifeCount;

    private void Awake()
    {
        if (GameObject.FindGameObjectsWithTag("Heart") != null)
        {
            bossLifeCount = GameObject.FindGameObjectsWithTag("Heart").Length;
        }
        print("Odczytana: " + ScoreScript.instance.score.ToString());
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();
        textUIComp.text = ScoreScript.instance.score.ToString();
    }


    // Update is called once per frame
    void Update()
    {

        if (GameObject.FindGameObjectsWithTag("AlienBoss").Length == 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

        }
    }


    void IncreaseTextUiScore(int points)
    {
        ScoreScript.instance.score += points;
        print(ScoreScript.instance.score);
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();
        //int score = int.Parse(textUIComp.text);
        //score += points;
        textUIComp.text = ScoreScript.instance.score.ToString();

    }
}
