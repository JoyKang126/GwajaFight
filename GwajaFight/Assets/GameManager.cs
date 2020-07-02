using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameHasEnded = false;
    GameObject[] p1Win;
    GameObject[] p2Win;
    GameObject[] noWin;

    public void Start()
    {
        p1Win = GameObject.FindGameObjectsWithTag("P1Wins");
        foreach (GameObject g in p1Win)
        {
            Debug.Log("p1");
            g.SetActive(false);
        }
        p2Win = GameObject.FindGameObjectsWithTag("P2Wins");
        foreach (GameObject g in p2Win)
        {
            g.SetActive(false);
        }
        noWin = GameObject.FindGameObjectsWithTag("NoWinner");
        foreach (GameObject g in noWin)
        {
            g.SetActive(false);
        }
    }
    public void EndGame()
    {
        if (gameHasEnded == false)
        {
            gameHasEnded = true;
            GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
            GameObject player1 = players[0];
            GameObject player2 = players[1];
            int p1Pts = player1.GetComponent<PointsScript>().getScore();
            int p2Pts = player2.GetComponent<PointsScript>().getScore();
            FindObjectOfType<GameManager>().EndGame();
            if (p1Pts > p2Pts)
            {
                Debug.Log("p1 wins");
                foreach (GameObject g in p1Win)
                {
                    g.SetActive(true);
                }
            } else if (p2Pts > p1Pts) {
                Debug.Log("p2 wins");
                foreach (GameObject g in p2Win)
                {
                    g.SetActive(true);
                }
            } else {
                Debug.Log("no win");
                foreach (GameObject g in noWin)
                {
                    Debug.Log("obj 1");
                    g.SetActive(true);
                }
            }
            Debug.Log("GAME OVER");
        }
    }
}