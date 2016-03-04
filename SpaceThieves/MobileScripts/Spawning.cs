using UnityEngine;
using System.Collections;

public class Spawning : MonoBehaviour
{
	public float spawnTime = 5f;		// The amount of time between each spawn.
	public float spawnDelay = 3f;		// The amount of time before spawning starts.
	//public GameObject[] enemies;		// Array of enemy prefabs.
	public Rigidbody2D alienPrefab;
	public Transform alienInstance;
	public Transform spawnPoint;
	public float speed;
	public bool gameOver;
	
	private GameController gameController;


	
	void Start ()
	{
		// Start calling the Spawn function repeatedly after a delay .
		InvokeRepeating("Spawn", Random.Range(2f, 10f), Random.Range(1f, 10f));
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}



	void Spawn ()
	{

		speed = -200;

		Rigidbody2D alienInstance;
		// Instantiate a random enemy.
		alienInstance = Instantiate(alienPrefab, spawnPoint.position, spawnPoint.rotation) as Rigidbody2D;
		alienInstance.AddForce(spawnPoint.up * speed);

		}


	}
