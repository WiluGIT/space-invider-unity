﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int level;
    public int score;

    public PlayerData()
    {
        this.level = Player.level;
        this.score = Player.score;
    }
}
