using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {
	public Rigidbody2D rigd;
	public int jumpHeight;
	public bool isGrounded = false;
	public bool isObstacleHit = false;
	public Animator anim;

	public GameObject titletxt;
	public Text gameOverTxt;
	public Button playBtn;
	public Button replayBtn;
	public Button jumpBtn;
	public Button exitBtn;
	public Button actionBtn;
	public Text scoreTxt;
	public Text hscoreTxt;
	public Text sTxt;
	public Text hTxt;
	public Image popup;
	public Button muteBtn;


	bool triggerEnabled = false;
	public bool holding = false;
	public GameObject arrow;
	GameObject oxObj;
	oxGenerator oxGenerator;

	public Button leftBtn;
	public Button rightBtn;

	public GameObject stoneObj;

    GameObject healthBarObj;
	public HealthBar healthBarScript; 
	GameObject healthBarFrame;

	public GameObject holdingBarObj;
	HoldingTime holdingBarScript; 
	GameObject holdingBarFrame;

	public bool holdComp = false;
	public int hScore=0;
	public int score;
	string highScoreKey = "HighScore";
	string highScoreKey2 = "HighScore2";
	int count;
	bool gameOverVar = false;

	AudioSource audioS;
	GameObject mainC;
	bool sndStatus = false;
	GameObject offBtn;
	public Image scorebg;

	public GameObject lscObj;
	private LevelSelectionController lsc;



	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();

		lsc = lscObj.GetComponent<LevelSelectionController> ();
		Time.timeScale = 0;


		healthBarFrame = GameObject.FindGameObjectWithTag ("hbf");
		healthBarObj = GameObject.FindGameObjectWithTag ("hb");
		healthBarScript = healthBarObj.GetComponent<HealthBar>();

		holdingBarFrame = GameObject.FindGameObjectWithTag ("htf");
		holdingBarObj = GameObject.FindGameObjectWithTag ("htb");
		holdingBarScript = holdingBarObj.GetComponent<HoldingTime>();



		titletxt.gameObject.SetActive (true);
		gameOverTxt.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (true);
		replayBtn.gameObject.SetActive (false);
		jumpBtn.gameObject.SetActive (false);
		exitBtn.gameObject.SetActive (true);
		actionBtn.gameObject.SetActive (false);
		arrow.gameObject.SetActive (false);
		leftBtn.gameObject.SetActive (false);
		rightBtn.gameObject.SetActive (false);
		healthBarFrame.gameObject.SetActive (false);
		holdingBarFrame.gameObject.SetActive (false);
		scoreTxt.gameObject.SetActive (false);
		hscoreTxt.gameObject.SetActive (false);
		sTxt.gameObject.SetActive (false);
		hTxt.gameObject.SetActive (false);
		popup.gameObject.SetActive (false);
		scorebg.gameObject.SetActive (false);

		oxObj = GameObject.Find ("oxContainer");
		oxGenerator = oxObj.GetComponent<oxGenerator> ();
		StartCoroutine ("scoreCalculate");
		if (gameObject.transform.parent.name == "Level1") {
			Debug.Log ("level1 get condition");
			hScore = PlayerPrefs.GetInt (highScoreKey, 0);
		}
		if (gameObject.transform.parent.name == "Level2") {
			Debug.Log ("level2 get condition");
			hScore = PlayerPrefs.GetInt (highScoreKey2, 0);
		}
		Debug.Log ("high score ="+hScore);
		hscoreTxt.text = "HighScore "+hScore.ToString ();


		mainC = GameObject.FindWithTag ("MainCamera");

	    audioS =  mainC.GetComponent<AudioSource>();
		offBtn = GameObject.Find ("muteBtn/offBtn");
		offBtn.SetActive (false);
	}	


	IEnumerator scoreCalculate(){
		yield return new WaitForSeconds (1f);
		score += 1;
		scoreTxt.text = score.ToString ();
		if (gameOverVar == false) {
			StartCoroutine ("scoreCalculate");
		}

	}
	public void soundFun() {
		if (sndStatus) {
			sndStatus = false;
			audioS.Play ();
			offBtn.SetActive (false);

		} else {
			sndStatus = true;
			audioS.Stop ();
			offBtn.SetActive (true);

		}
	}
	// Update is called once per frame
	void Update () {
		if (isGrounded == true) {
			if (Input.GetKeyDown (KeyCode.W)) {
				//Add force to the players rigidbody allowing it to move upwards if the above if statement is true
				rigd.AddForce (Vector2.up * jumpHeight);
				anim.StopPlayback ();
			}
			//Debug.Log("player x=" + transform.position.x);
			//if (ox.transform.position.x > transform.position.x) {
			//	Debug.Log ("holding");
		//	}
		}
	}
	public void play(){		
		Time.timeScale = 1;
		titletxt.gameObject.SetActive (false);
		gameOverTxt.gameObject.SetActive (false);
		playBtn.gameObject.SetActive (false);
		replayBtn.gameObject.SetActive (false);
		jumpBtn.gameObject.SetActive (true);
		exitBtn.gameObject.SetActive (false);
		actionBtn.gameObject.SetActive (true);
		arrow.gameObject.SetActive (false);
		healthBarFrame.gameObject.SetActive (true);
		holdingBarFrame.gameObject.SetActive (true);
		scoreTxt.gameObject.SetActive (true);
		hscoreTxt.gameObject.SetActive (true);
		sTxt.gameObject.SetActive (false);
		hTxt.gameObject.SetActive (false);
		popup.gameObject.SetActive (false);


	}

	public void rePlay(){
		Application.LoadLevel (0);
	}

	public void stop(string status=""){
		gameOverVar = true;
		Time.timeScale = 0;
		titletxt.gameObject.SetActive (true);
		gameOverTxt.gameObject.SetActive (true);

		playBtn.gameObject.SetActive (false);
		replayBtn.gameObject.SetActive (true);
		jumpBtn.gameObject.SetActive (false);
		exitBtn.gameObject.SetActive (true);
		actionBtn.gameObject.SetActive (false);
		leftBtn.gameObject.SetActive (false);
		rightBtn.gameObject.SetActive (false);
		healthBarFrame.gameObject.SetActive (false);
		holdingBarFrame.gameObject.SetActive (false);
		scoreTxt.gameObject.SetActive (false);
		hscoreTxt.gameObject.SetActive (false);
		sTxt.gameObject.SetActive (true);
		hTxt.gameObject.SetActive (true);
		scorebg.gameObject.SetActive (true);

		sTxt.text = "Score: "+score.ToString ();
		hTxt.text = "High Score: "+hScore.ToString ();


		//Save new High Score


		if(score > hScore){
			if (gameObject.transform.parent.name == "Level1") {
				Debug.Log ("level1 set condition");
				PlayerPrefs.SetInt(highScoreKey, score);
				PlayerPrefs.Save();
			}
			if (gameObject.transform.parent.name == "Level2") {
				
				PlayerPrefs.SetInt(highScoreKey2, score);
				Debug.Log ("level1 set condition");
				PlayerPrefs.Save();
			}

			gameOverTxt.text = "You Won";
			lsc.unLocker ();
		}
		else  {
			gameOverTxt.text = "Game Over";
		}

	}
	public void action() {
		

		if (triggerEnabled == true) {
			Debug.Log ("hold can work");
			anim.Play ("HoldingOx");
			holding = true;
			stoneObj.gameObject.SetActive (false);
			arrow.gameObject.SetActive (true);
			holdingBarFrame.gameObject.SetActive (true);


			leftBtn.gameObject.SetActive (true);
			rightBtn.gameObject.SetActive (true);

			actionBtn.gameObject.SetActive (false);
			jumpBtn.gameObject.SetActive (false);

		} else {			
			Debug.Log ("hold can't work");
		}
	}
	public void jump(){
		if (isGrounded == true) {
			//if (isObstacleHit == false) {
				//Add force to the players rigidbody allowing it to move upwards if the above if statement is true
				rigd.AddForce (Vector2.up * jumpHeight);
				anim.StopPlayback ();
			//}
		}
	}


	//collision logic
	void OnCollisionEnter2D(Collision2D col) {
		
		if (col.gameObject.tag == "ground") {
			isGrounded = true;
			Debug.Log ("isGrounded");
			if (isObstacleHit == false) {
				anim.Play ("playerRun");
			}
		} 

		if (col.gameObject.tag == "obstacle") {
			Debug.Log ("Collided");
			isObstacleHit = true;
			anim.Play ("playerAttackByOx"); //PlayerAttackByOx for Stone..... Playerfall for Ox hit
			//Invoke ("stop", 2);
			healthBarScript.reducePlayerFun("stone");
			GameObject bg = GameObject.FindGameObjectWithTag ("Quad");
			Done_BGScroller bgScript = bg.GetComponent<Done_BGScroller> ();
//			bgScript.stopBg = true;

			StartCoroutine ("bgScrollController", 0.7f);
		}
		if (col.gameObject.tag == "oxObstacle") {
			Debug.Log ("Collided");

			if (holding != true) {
				/*anim.Play ("PlayerFall");
				GameObject bg = GameObject.Find ("Quad");
				Done_BGScroller bgScript = bg.GetComponent<Done_BGScroller> ();
				bgScript.stopBg = true;
				StartCoroutine ("bgScrollController", 1);*/
				callPlayerFallAnim ();
			} 
		}

	}
	void OnCollisionExit2D(Collision2D col){
		if (col.gameObject.tag == "ground") {
			isGrounded = false;
			//Debug.Log ("!Grounded");

		}
		if (col.gameObject.tag == "oxObstacle") {
			//Debug.Log ("on collision exit");
			holding = false;
			triggerEnabled = false;
		}
	}

	//Trigger logic
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "oxObstacle") {
			//Debug.Log ("on trigger enter");
			triggerEnabled = true;
		}
	}

	void OnTriggerExit2D(Collider2D col) {
		if (col.gameObject.tag == "oxObstacle") {
			//Debug.Log ("on trigger exit");
			triggerEnabled = false;
		}
	}

	public void callPlayerFallAnim() {
		holding = false;
		anim.Play ("PlayerFall");
		healthBarScript.reducePlayerFun("ox");

		stoneObj.gameObject.SetActive (true);
		leftBtn.gameObject.SetActive (false);
		rightBtn.gameObject.SetActive (false);
		//holdingBarScript.timer = 0f;
		//holdingBarScript.currLength = 150f;
		//holdingBarFrame.gameObject.SetActive (false);


		actionBtn.gameObject.SetActive (true);
		jumpBtn.gameObject.SetActive (true);

		GameObject bg = GameObject.FindGameObjectWithTag ("Quad");
		Done_BGScroller bgScript = bg.GetComponent<Done_BGScroller> ();
		bgScript.stopBg = true;
		StartCoroutine ("bgScrollController", 1);
	}

	IEnumerator bgScrollController(){
		yield return new WaitForSeconds (1.5f);
		GameObject bg = GameObject.FindGameObjectWithTag("Quad");
		Done_BGScroller bgScript = bg.GetComponent<Done_BGScroller>();
		bgScript.stopBg = false;
		isObstacleHit = false;
		anim.Play ("playerRun");

	}
	public void callPlayerFun() {
		holdComp = true;
		holding = false;
		score += 100;
		stoneObj.gameObject.SetActive (true);
		leftBtn.gameObject.SetActive (false);
		rightBtn.gameObject.SetActive (false);
		actionBtn.gameObject.SetActive (true);
		jumpBtn.gameObject.SetActive (true);
		anim.Play ("playerRun");
		StartCoroutine ("makeHoldCompFalse", 1);
	}
	IEnumerator makeHoldCompFalse(){
		yield return new WaitForSeconds (1.5f);
		holdComp = false;
	}

	public void pauseGame(){
		Time.timeScale = 0;
		popup.gameObject.SetActive (true);

	}

	public void resumeGame(){
		Time.timeScale = 1;
		popup.gameObject.SetActive (false);

	}

	public void exitApp(){
		Application.Quit();
	}
}
