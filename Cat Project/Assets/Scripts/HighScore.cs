using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour {

    public static int highScoreValue;
    Text highScore;

	// Use this for initialization
	void Start () {
        highScore = GetComponent<Text>();
        highScore.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        if (Score.scoreValue > highScoreValue)              // sets new high score
        {
            highScoreValue = Score.scoreValue;
        }
        highScore.text = " " + highScoreValue + " ";
    }
}
