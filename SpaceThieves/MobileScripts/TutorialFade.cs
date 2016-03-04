using UnityEngine;
using System.Collections;


public class TutorialFade : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (GameController.gameCount <= 10){
		Destroy(gameObject, 4f);
			print ("I exist");
		}
		else{
			Destroy (gameObject);
			Destroy (this);
		}
	}
	
	// Update is called once per frame
}
