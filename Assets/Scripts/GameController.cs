﻿using System.Collections;
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
