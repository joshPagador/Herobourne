
using UnityEngine;
using UnityEngine.UI;

public class scoreSystem : MonoBehaviour {

	public int score = 0;
	public Text scoreText;

    public void UpdateScore (int s)
	{
		score += s;
		scoreText.text = score.ToString();


    }
}
