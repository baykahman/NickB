using UnityEngine;
using System.Collections;

public class Destroy : MonoBehaviour
{

	public bool gameOver;
	public bool restart;

	private GameController gameController;

	void Start ()
	{

		GameObject gameControllerObject = GameObject.FindWithTag ("GameController");
		if (gameControllerObject != null)
		{
			gameController = gameControllerObject.GetComponent <GameController>();
		}
	}
		void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Enemy")
		{
			gameController.GameOver ();
			gameController.RestartGame ();
			Destroy(other.gameObject);
			Time.timeScale = 0F;
			print ("AlienDead");

		}


		Destroy(other.gameObject);
	}
}
