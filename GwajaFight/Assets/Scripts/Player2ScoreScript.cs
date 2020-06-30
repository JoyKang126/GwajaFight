using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2ScoreScript : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    Text score;
    void Start()
    {
        score = GetComponent<Text> ();
    }

    // Update is called once per frame
    void Update()
    {
        int scoreValue = player.GetComponent<PointsScript>().getScore();
        score.text = "Player 2: " + scoreValue;
    }
}
