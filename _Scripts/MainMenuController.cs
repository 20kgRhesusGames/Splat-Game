using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour {


	public Button soundButton;
	int muteToggle;

	public void ExitGame ()
	{
		Application.Quit();
	}

	public void HighScores ()
	{
		SceneManager.LoadScene ("HighScores");
	}

	public void HowToPlay ()
	{
		SceneManager.LoadScene ("HowToPlay");
	}

	public void NewGame ()
	{
		SceneManager.LoadScene ("Main");
	}
		
	public void BackToMainMenu ()
	{
		SceneManager.LoadScene ("StartMenu");
	}

	public void CreditsMenu()
	{
		SceneManager.LoadScene ("Credits");
	}

	public void SoundToggle()
	{
		if (muteToggle == 0) 
		{
			muteToggle = 1;
			PlayerPrefs.SetInt ("Mute", muteToggle);
		} 
		else if (muteToggle == 1)
		{
			muteToggle = 0;
			PlayerPrefs.SetInt ("Mute", muteToggle);
		}
	}

	void Update()
	{
		var colorBlock = soundButton.colors;
		Text soundButtonText = soundButton.GetComponent<Text> ();
		Color red = Color.red;
		Color white = Color.white;
		muteToggle = PlayerPrefs.GetInt ("Mute");

		if (muteToggle == 0) 
		{
			colorBlock.normalColor = red;
			colorBlock.highlightedColor = red;
			colorBlock.disabledColor = red;
			soundButtonText.text = "Sound Off";
			soundButton.colors = colorBlock;
		} 
		else if (muteToggle == 1)
		{
			colorBlock.normalColor = white;
			colorBlock.highlightedColor = white;
			colorBlock.disabledColor = white;
			soundButtonText.text = "Sound On";
			soundButton.colors = colorBlock;
		}
	}

}
