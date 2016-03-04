using UnityEngine;
using System.Collections;

public class CreditsController : MonoBehaviour {

	// Use this for initialization
	void OnGUI(){
		if (GUI.Button(new Rect(Screen.width/2-50,Screen.height/2,Screen.width*.2f,Screen.height*.15f), "Back"))
		{
			Application.LoadLevel(0);
		}
}

	void Update(){
		if (Input.GetKey(KeyCode.Escape))
			
		{
			// Insert Code Here (I.E. Load Scene, Etc)
			Application.LoadLevel(0);
			// OR Application.Quit();	
		}
	}
	
}