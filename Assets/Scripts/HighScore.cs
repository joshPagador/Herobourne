using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScore : MonoBehaviour
{
    public int score = 0;
    public Text scoreText;
    public Text highScore;

    void Start()
    {
        highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
    public void UpdateScore(int s)
    {
        score += s;
        scoreText.text = score.ToString();

        //checks if score value is higher than high score
        if (score > PlayerPrefs.GetInt("HighScore", 0))
        {

            //function to take in 2 values
            PlayerPrefs.SetInt("HighScore", score);
            //key is a string variable

            highScore.text = score.ToString();
        }
    }
}
