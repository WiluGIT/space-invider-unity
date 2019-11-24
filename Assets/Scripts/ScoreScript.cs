using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{

    public int score=0;

    public static ScoreScript instance = null;


    void Awake()
    {
        instance = this;
    }

}
