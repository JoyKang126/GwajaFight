﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointsScript : MonoBehaviour
{
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame

    public void addScore(int value)
    {
        score += value;
    }

    public int getScore()
    {
        return score;
    }
}
