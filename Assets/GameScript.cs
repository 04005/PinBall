

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;





public class GameScript : MonoBehaviour
{
    string getScoreString(int n)
    {
        string str = n.ToString();

        while (str.Length < 7)
        {
            str = "0" + str;
        }
        return str;
    }
    
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


        this.scoreText.GetComponent<Text>().text = getScoreString(this.score);
    }
}
