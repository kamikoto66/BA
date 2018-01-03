using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    [HideInInspector] public int score;
    public Text scoreText;
	// Use this for initialization
	void Start () {
        score = 0;
        scoreText = GetComponent<Text>();
        scoreText.text = score.ToString();
    }
	
    public void AddScore(int _score)
    {
        score += _score;
        scoreText.text = score.ToString();
    }
}
