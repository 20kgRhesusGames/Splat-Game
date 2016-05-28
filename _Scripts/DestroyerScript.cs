using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class DestroyerScript : MonoBehaviour {

	public GameObject destroyer;

	void OnTriggerEnter2D(Collider2D other)
	{
		
			if (other.tag == "Player") {
				SceneManager.LoadScene("EndGame");
				return;
			}

			if (destroyer.tag == "Sweeper") {
				if (other.gameObject.transform.parent) {
					Destroy (other.gameObject.transform.parent.gameObject);
				} else {
					Destroy (other.gameObject);
				}
			}

	}
}
