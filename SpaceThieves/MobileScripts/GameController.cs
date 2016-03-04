using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GooglePlayGames;
using GooglePlayGames.BasicApi;
using UnityEngine.SocialPlatforms;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour {

	public GUIText scoreText;
	public GUIText highScoreText;
	public GUIText restartText;
	public GUIText gameOverText;
	public GUIText highScoreMessage;
	public Texture highScoreBackground; 
	public Texture restartButton;
	public Texture LeaderboardText;
	public Texture PausedText;
	public Texture PauseButton;
	public Texture muteButton;
	public Texture unmuteButton;
	
	public int score;
	private int newHighScore;
	private int highScore;
	public bool gameOver;
	public bool restart;
	public bool newplayer;

	public static int gamesTrack = 0;
	public static int gamesPlayed = gamesTrack;
	private const int counterReset = 10;
	public static int gameCount = counterReset;

	public AudioClip success;

	public GameObject alien;
	
	 

	// Use this for initialization
	void Start()
	{
		gameOver = false;
		restart = false;
		restartText.text = "";
		gameOverText.text = "";
		score = 0;
		gamesPlayed++;
		gameCount--; 
		//highScore = PlayerPrefs.GetInt("High Score", score);
		UpdateScore();
		AdInitialize();
		Time.timeScale = 1.0F;
		highScoreText.text = "High Score: " + PlayerPrefs.GetInt("highScore");
		//alienDestroy = GameObject.FindGameObjectWithTag("Enemy").GetComponent<AlienDestroy>();
		//grab the advertisement code

		print (gamesPlayed);

	}
	public static void resetCounter (){
		gameCount = counterReset;
	}

	public static void gameCounter (){

	}

	public void AdInitialize(){
		if (Advertisement.isSupported) {
			Advertisement.allowPrecache = false;
			Advertisement.Initialize ("131627406");
		} else {
			Debug.Log("Platform not supported");
		}
	}

	void Update ()
	{
		backButton();

		if (restart)
		{
			if (Input.GetKeyDown (KeyCode.R))
			{
				Application.LoadLevel (Application.loadedLevel);
			}

		}

		//Achievements start
		if (score == 0){
			Social.ReportProgress("CgkIteSm_voIEAIQAw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}

		if (score >= 5) {
			Social.ReportProgress("CgkIteSm_voIEAIQAQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (score >= 10){
			Social.ReportProgress("CgkIteSm_voIEAIQBA", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (score >= 30){
			Social.ReportProgress("CgkIteSm_voIEAIQBQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt("highScore") >= 50){
			Social.ReportProgress("CgkIteSm_voIEAIQBw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (score >= 50){
			Social.ReportProgress("CgkIteSm_voIEAIQBw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt("highScore") >= 75){
			Social.ReportProgress("CgkIteSm_voIEAIQCA", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (score >= 75){
			Social.ReportProgress("CgkIteSm_voIEAIQCA", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt("highScore") >= 100){
			Social.ReportProgress("CgkIteSm_voIEAIQCQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (score >= 100){
			Social.ReportProgress("CgkIteSm_voIEAIQCQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt("highScore") >= 200){
			Social.ReportProgress("CgkIteSm_voIEAIQCQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (score >= 200){
			Social.ReportProgress("CgkIteSm_voIEAIQCQ", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (PlayerPrefs.GetInt("highScore") >= 371){
			Social.ReportProgress("CgkIteSm_voIEAIQCw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (score >= 371){
			Social.ReportProgress("CgkIteSm_voIEAIQCw", 100.0f, (bool success) => {
				// handle success or failure
			});
		}
		if (newplayer == false){
			Social.ReportProgress("CgkIteSm_voIEAIQBg", 100.0f, (bool success) => {
				if (success){
					Debug.Log ("Beta Achievement Unlocked");
				}
			});

		}
		if (newplayer == true){
			Social.ReportProgress("CgkIteSm_voIEAIQBg", 0.0f, (bool success) => {
				if (success){
					Debug.Log ("Can't unlock");
				}
			});
			
		}
	}

	public void OnApplicationPause(){
		pauseGame();
	}

	public void AddScore(int newScoreValue)
	{
		score += newScoreValue;
		UpdateScore ();
		//UpdateHighScore ();
	}

	void UpdateHighScore()
	{
		//highScoreText.text = "High Score: " + score;
		//PlayerPrefs.SetInt("High Score", score);
	}

	void UpdateScore() 
	{
		scoreText.text = "Score: " + score;
		GetComponent<AudioSource>().PlayOneShot(success);
		}

	void OnGUI()
	{
		//pause button
		if (gameOver == false){
		if(GUI.Button(new Rect(Screen.width-Screen.width*.07f,0,Screen.width*.07f,Screen.height*.10f),PauseButton)){
			// call our toggle function
			doPauseToggle();
		}
		}
		//Display paused when game is paused
		if(gameOver == false & Time.deltaTime == 0f){
			GUI.Label (new Rect (Screen.width/2-Screen.width*.1f,Screen.height/2,Screen.width*.2f,Screen.height*.15f), PausedText);
			if (GUI.Button (new Rect(Screen.width-Screen.width*.20f,Screen.height/2,Screen.width*.2f,Screen.height*.15f), muteButton)){
				AudioListener.volume = 0;
			}
			if (GUI.Button (new Rect(Screen.width-Screen.width*.20f,Screen.height/2-Screen.height*.2f,Screen.width*.2f,Screen.height*.15f), unmuteButton)){
				AudioListener.volume = 1;
			}

		}
		//if a new high score, display the seal 
		if (gameOver == true && (score >= PlayerPrefs.GetInt("highScore", score))){
			highScoreMessage.text = "Congrats! You have a new high score of " + score;
			GUI.Label (new Rect (0,Screen.height/2-Screen.height*.2f,Screen.width*.33f,Screen.height*.25f), highScoreBackground);
		}

		if(restart){

			//restart button
			if (GUI.Button(new Rect(Screen.width/2-Screen.width*.1f,Screen.height/2,Screen.width*.2f,Screen.height*.15f), restartButton))
		    {
				Application.LoadLevel (Application.loadedLevel);
			}
			/*if (GUI.Button(new Rect(Screen.width/2-Screen.width*.1f,Screen.height/2+Screen.height*.25f,Screen.width*.2f,Screen.height*.15f), leaderboardButton))
			{
				Social.ShowLeaderboardUI();
			}
*/

	}
		GUI.contentColor = Color.black;
		
	}
	public void RestartGame()
	{
		restartText.text = "Press R for Restart";
		restart = true;

	}

	public void GameOver() 
	{
		if (score >= PlayerPrefs.GetInt("highScore", score))
		{
			PlayerPrefs.SetInt("highScore", score);
		}
		gameOverText.text = "Game Over";
		if (gameCount <= 0){
		resetCounter();
			Advertisement.Show();
		}
		//Time.timeScale = 0F;
		gameOver = true;
		Social.ReportScore(PlayerPrefs.GetInt("highScore"), "CgkIteSm_voIEAIQAg", (bool success) => {
			// handle success or failure
		});
		}


	

	public void pauseGame()
	{
		//sets game to 0 frames
		Time.timeScale = 0f;
	}
	public void unPauseGame()
	{
		//sets game to 1 frame, unpaused
		Time.timeScale = 1.0f;
	}

	public void doPauseToggle(){
	{
			//code that toggles the pause function
		if(Time.timeScale>0)
			pauseGame();
	
	else{
		unPauseGame();
			}
		}
	}
	public void nobeta()
	{
		if((PlayerPrefs.GetInt("highScore") == 0) && score == 0) {
			newplayer = true;
		}

	}

	public void backButton()
	{
			
		if (Input.GetKey(KeyCode.Escape))
				
			{
				// Insert Code Here (I.E. Load Scene, Etc)
				Application.LoadLevel(0);
				// OR Application.Quit();	
			}
		}
	

	

}

