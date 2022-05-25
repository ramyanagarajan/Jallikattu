using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartScreenController : MonoBehaviour {

	// Use this for initialization
	public GameObject titletxt;
	public Text gameOverTxt;
	public Button playBtn;
	public Button replayBtn;
	public Button exitBtn;
	public Button testing;
	void Start () {
		Time.timeScale = 0;
		titletxt.gameObject.SetActive (true);
		gameOverTxt.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (true);
		replayBtn.gameObject.SetActive (false);
		exitBtn.gameObject.SetActive (true);
		Debug.Log ("checking=" + testing);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void testFun() {
		Debug.Log ("it is coming here");
	}
	public void play(){	
			
		titletxt.gameObject.SetActive (false);
		gameOverTxt.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);
		replayBtn.gameObject.SetActive (false);
		exitBtn.gameObject.SetActive (false);
	}
	public void stop(string status=""){
		titletxt.gameObject.SetActive (true);
		gameOverTxt.gameObject.SetActive (true);
		if (status == "GameOver") {
			gameOverTxt.text = "Game Over";
		}
		if (status == "YouWin") {
			gameOverTxt.text = "You Win";
		}
		playBtn.gameObject.SetActive (false);
		replayBtn.gameObject.SetActive (true);
		exitBtn.gameObject.SetActive (true);
	}
	public void exitApp(){
		Application.Quit();
	}
}
