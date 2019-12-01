using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    int alienCount;
    

    private void Awake()
    {
        if(GameObject.FindGameObjectsWithTag("Alien") != null)
        {
            alienCount = GameObject.FindGameObjectsWithTag("Alien").Length;
        }

        if (ScoreScript.instance != null)
        {
            print("Odczytana: " + ScoreScript.instance.score.ToString());
            var textUIComp = GameObject.Find("Score").GetComponent<Text>();
            textUIComp.text = ScoreScript.instance.score.ToString();
        }
        else if(SceneManager.GetActiveScene().buildIndex==5)
        {

            ScoreScript.instance.score = 140;
            var textUIComp = GameObject.Find("Score").GetComponent<Text>();
            textUIComp.text = ScoreScript.instance.score.ToString();
        }

    }


    // Update is called once per frame
    void Update()
    {
        if (alienCount> GameObject.FindGameObjectsWithTag("Alien").Length)
        {
            alienCount--;
            IncreaseTextUiScore(10);
        }



        if (GameObject.FindGameObjectsWithTag("Alien").Length == 0)
        {
            Player.level++;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }

    }


    void IncreaseTextUiScore(int points)
    {
        var textUIComp = GameObject.Find("Score").GetComponent<Text>();
        ScoreScript.instance.score = int.Parse(GameObject.Find("Score").GetComponent<Text>().text);
        ScoreScript.instance.score += points;
        Player.score = ScoreScript.instance.score;
        print("Aktualny player score: "+Player.score);

        textUIComp.text = ScoreScript.instance.score.ToString();

    }
    

}
