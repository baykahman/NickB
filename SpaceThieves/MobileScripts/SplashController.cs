using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using GooglePlayGames.BasicApi.Multiplayer;

public class SplashController : MonoBehaviour {

	public Texture creditsButton;
	public Texture playButton;
	public Texture quitButton;
	public Texture signInButton;
	public Texture servicesButton;
	public Texture failMessage;
	public Texture sucMessage;
	public bool authenticated;

	void Start(){
	PlayGamesPlatform.Activate();
		authenticated = false;

		Social.localUser.Authenticate((bool success) => {
			if (success){
				authenticated = true;
				Debug.Log ("Login Success");
			}
			else{
				authenticated = false;
				Debug.Log("something went wrong");
			}
		});
		}

	public void sMessage(){
		if(authenticated == true)
			GUI.Label (new Rect(Screen.width*.2f,Screen.height-Screen.height*.80f,Screen.height*.50f,Screen.height*.40f), sucMessage);
		else{
			GUI.Label (new Rect(Screen.width*.14f,Screen.height-Screen.height*.87f,Screen.width*.30f,Screen.height*.25f), failMessage); 
		};
	}

	

	void OnGUI(){

		/*if(authenticated == true)
			GUI.Label (new Rect(Screen.width*.2f,Screen.height-Screen.height*.80f,Screen.height*.50f,Screen.height*.40f), sucMessage);
		else{
			GUI.Label (new Rect(Screen.width*.14f,Screen.height-Screen.height*.87f,Screen.width*.30f,Screen.height*.25f), failMessage); 
		};*/

		sMessage();

		if (GUI.Button(new Rect(0,Screen.height-Screen.height*.60f,Screen.width*.2f,Screen.height*.15f), playButton))
		{
			Application.LoadLevel(1);
		}
		if (GUI.Button(new Rect(0,Screen.height-Screen.height*.2f,Screen.width*.2f,Screen.height*.15f), quitButton))
		{
			Application.Quit();
		}
		/*if (GUI.Button(new Rect(0,Screen.height-Screen.height*.15f,Screen.width*.2f,Screen.height*.15f), creditsButton))
		{
			Application.LoadLevel(2);
		}
		*/
		if (GUI.Button(new Rect(0,Screen.height-Screen.height*.4f,Screen.width*.2f,Screen.height*.15f), servicesButton))
		{
			Application.LoadLevel(3);
		}

		if (GUI.Button(new Rect(0,Screen.height-Screen.height*.80f,Screen.width*.2f,Screen.height*.15f), signInButton))
		{
			Social.localUser.Authenticate((bool success) => {
				if (success){
					authenticated = true;
					Debug.Log ("Login Success");
				}
				else{
					authenticated = false;
					Debug.Log("something went wrong");
				}
			});
		}
}
}