using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    public int score;
    private GameObject scoreText;

    void Start()
    {
        this.scoreText = GameObject.Find("ScoreText");

    }

    void Update()
    {
        if (this.score>=10000000) 
        {
            this.score = 9999999;
        }
        this.scoreText.GetComponent<Text>().text = this.score.ToString("0000000");
    }
}
