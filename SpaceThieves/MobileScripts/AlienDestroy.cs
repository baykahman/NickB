using UnityEngine;
using System.Collections;


public class AlienDestroy : MonoBehaviour {

	public int scoreValue;
	private GameController gameController;

	void Start()
	{
		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
	

	void OnCollisionEnter2D(Collision2D coll) {


		//When colliding with the bullet, destroy itself
		if (coll.gameObject.tag == "Shot")
		gameController.AddScore (scoreValue);
			Destroy(gameObject, .2f);


	}
}
