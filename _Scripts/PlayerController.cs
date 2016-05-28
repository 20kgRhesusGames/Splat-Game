using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour {

	public GameObject player;			//holds the player for reference

	public float jumpVelocity = 20f;	//adjustable jump velocity for testing
	public float playerSpeed = 6f;		//controls the speed of the player/game (adjustable for testing)

	bool bouncy;						//when true, allows player to bounce off terrain
	float bouncyTime;					//when <0 player loses bouncy trait and dies on collision

	float gameTimer = 40f;				//keeps track of game time to scale difficulty with time
	public float playerScore = 0f;

	Animator anim;
	AudioSource playerAudio;
	public AudioClip bounceClip;
	public AudioClip splatClip;
	int muteToggle;

	void Start()
	{
		//the player should start out being able to bounce and animation should depict that
		anim = player.GetComponent<Animator> ();
		anim.SetBool ("Dripping", false);
		bouncy = true;
		bouncyTime = 10f;

		//set up audio source
		playerAudio = player.GetComponent<AudioSource>();
		muteToggle = PlayerPrefs.GetInt ("Mute");

		if (muteToggle == 0) 
		{
			playerAudio.mute = true;
		} 
		else 
		{
			playerAudio.mute = false;
		}
	}

	void FixedUpdate()
	{
		//set player to always be moving forward at "playerSpeed"
		Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();	
		playerRB.velocity = new Vector2 (playerSpeed, playerRB.velocity.y);


	}

	void Update () 
	{
		//control for moving the player upward (replace with multiplatform controls)
		if (Input.GetMouseButtonDown (0)) 
		{
			jump();
		}

		//use bonucyTime to keep track of bouncy state
		if (bouncyTime > 0) 
		{
			//only count down timer if above 0 so that powerups add to 0 instead of a negative
			bouncy = true;
			anim.SetBool ("Dripping", false);
			bouncyTime -= Time.deltaTime;

			//set player audio to play bounce sound if player is still bouncy
			playerAudio.clip = bounceClip;
		}

		if (bouncyTime < 1.5) 
		{
			anim.SetBool ("Dripping", true);
			if (bouncyTime < 0) 
			{
				bouncy = false;
				playerAudio.clip = splatClip;
			}
		}

		//as game length increases, speed up player to make game more difficult
		gameTimer += Time.deltaTime;
		Time.timeScale = (gameTimer / 40);
		playerScore += Time.deltaTime * 100f;
		//playerSpeed = 6f + gameTimer / 10;

	}
		
	public void jump()
	{
		//jumps the player upward on input
		Rigidbody2D playerRB = player.GetComponent<Rigidbody2D>();
		playerRB.AddForce(Vector2.up*jumpVelocity, ForceMode2D.Impulse);
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		//if the player hits terrain when not bouncy, kill player
		if (other.gameObject.tag == "Terrain") 
		{
			if (!bouncy) 
			{
				//play the splat animation/sound
				anim.SetBool("Splat",true);
				playerAudio.Play ();

				//stop all player movement
				Rigidbody2D playerRB = player.GetComponent<Rigidbody2D> ();
				playerRB.velocity = new Vector2 (0f, 0f);
				playerRB.constraints = RigidbodyConstraints2D.FreezeAll;

				//end the game after a short delay
				StartCoroutine (endGame());

			} 
			if (bouncy) 
			{
				//play the bounce animation/sound
				anim.SetTrigger("Bounce");
				playerAudio.Play ();

			}
		}

	}

	void OnDisable()
	{
		PlayerPrefs.SetInt ("Score", (int)playerScore);
	}

	void OnTriggerEnter2D(Collider2D pickup)
	{
		//if player picks up "good" pickups, increase time in bouncy state
		if (pickup.tag == "Bounce") 
		{
			bouncyTime += 10f;
			Destroy(pickup);
			return;
		}
		//if player picks up "bad" pickups, decrease time in bouncy state
		if (pickup.tag == "Soap") //fix the tag names at some point
		{
			if (bouncyTime > 0) 
			{
				bouncyTime -= 10f;
			}
			Destroy (pickup);
			return;
		}

	}

	//used to allow the player to see the splat animation before end game screen
	IEnumerator endGame() 
	{
		yield return new WaitForSeconds (1.8f);
		SceneManager.LoadScene ("EndGame");
	}
		
}
