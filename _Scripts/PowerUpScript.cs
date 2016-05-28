using UnityEngine;
using System.Collections;

public class PowerUpScript : MonoBehaviour {

	public GameObject pickup;
	public GameObject player;


	void OnTriggerEnter2D(Collider2D other)
	{

		if (other.tag == "Player")
		{
			Destroy(pickup);
			return;
		}
	}
}
