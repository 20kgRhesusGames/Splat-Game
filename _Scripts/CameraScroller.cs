using UnityEngine;
using System.Collections;

public class CameraScroller : MonoBehaviour {

	public float cameraSpeed = 1.0f;
	public bool cameraMove = false;
	public GameObject player;

	AudioSource backgroundMusic;
	int muteToggle;

	void Start()
	{
		backgroundMusic = GetComponent<AudioSource> ();
		muteToggle = PlayerPrefs.GetInt ("Mute");

		if (muteToggle == 0) 
		{
			backgroundMusic.mute = true;
		} 
		else 
		{
			backgroundMusic.mute = false;
		}
	}

	void Update () 
	{
		if (cameraMove) 
		{
			transform.position = new Vector3(player.transform.position.x + 6, 0f, -10f);
		}


	}
}
