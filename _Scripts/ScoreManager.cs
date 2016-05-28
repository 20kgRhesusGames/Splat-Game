using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	int highScore;
	int midScore;
	int lowScore;

	int currentScore;

	public Text currentScoreText;
	public Text highScoreText;
	public Text midScoreText;
	public Text lowScoreText;

	void Start () 
	{
		//pull the current score to check it against highscore list
		highScore = PlayerPrefs.GetInt("HighScore");
		midScore = PlayerPrefs.GetInt("MidScore");
		lowScore = PlayerPrefs.GetInt ("LowScore");
		currentScore = PlayerPrefs.GetInt ("Score");

		if (currentScore > highScore) 
		{
			//bump all scores down, assumes that the highscore table is in order already
			lowScore = midScore;
			midScore = highScore; 
			highScore = currentScore;
			PlayerPrefs.SetInt ("HighScore", highScore);
			PlayerPrefs.SetInt ("MidScore", midScore);
			PlayerPrefs.SetInt ("LowScore", lowScore);
		} 
		else if (currentScore > midScore && currentScore < highScore) 
		{
			lowScore = midScore;
			midScore = currentScore;
			PlayerPrefs.SetInt ("MidScore", midScore);
			PlayerPrefs.SetInt ("LowScore", lowScore);
		}
		else if (currentScore > lowScore && currentScore < midScore)
		{
			lowScore = currentScore;
			PlayerPrefs.SetInt("LowScore",lowScore);
		}

		//after high score list has been updated, populate the score list with the updated values
		GetScores();

		highScoreText.text = "Score 1: " + highScore;
		midScoreText.text = "Score 2: " + midScore;
		lowScoreText.text = "Score 3: " + lowScore;
		currentScoreText.text = "Score: " + currentScore;
	}

	public void GetScores()
	{
		highScore = PlayerPrefs.GetInt ("HighScore");
		midScore = PlayerPrefs.GetInt ("MidScore");
		lowScore = PlayerPrefs.GetInt ("LowScore");
	}
		
}
