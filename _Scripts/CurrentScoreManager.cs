using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CurrentScoreManager : MonoBehaviour {

	public Text playerScoreText;
	public GameObject player;

	PlayerController playerController;

	void Start()
	{
		playerController = player.GetComponent<PlayerController>();
	}

	void Update () 
	{
		playerScoreText.text = "Score: " + (int)playerController.playerScore;
	}
}
