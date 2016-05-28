using UnityEngine;
using System.Collections;

public class SpawnerScript : MonoBehaviour {

	public GameObject[] obj;
	public float spawnMin = 10f;
	public float spawnMax = 20f;
	//float gameTimer = 10f;

	// Use this for initialization
	void Start () 
	{
		Spawn ();

	}

	void Spawn()
	{
		Instantiate(obj[Random.Range(0, obj.GetLength(0))], transform.position, Quaternion.identity);
		Invoke ("Spawn", Random.Range (spawnMin, spawnMax));
	}
		
	/*void Update()
	{
		gameTimer += Time.deltaTime;
		spawnMin = spawnMin / gameTimer;
		spawnMin = spawnMax / gameTimer;
	}*/
}
