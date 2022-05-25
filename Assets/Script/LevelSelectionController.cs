using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSelectionController : MonoBehaviour {

	// Use this for initialization
	public GameObject levelone;
	public GameObject leveltwo;
	public GameObject frontScreen;
	public GameObject htpImage;
	public GameObject closeBtn;

	public Button Level2Btn;
	public int levelUnlock = 0;
	string unLockKey = "LEVELUNLOCKKEY";

	void Awake(){
		levelUnlock = PlayerPrefs.GetInt ("LEVELUNLOCKKEY",0);
		if (levelUnlock == 0) {
			Debug.Log ("Level Locked");
		} else {
			Debug.Log ("Level UnLocked");
			Level2Btn.interactable = true;
		}
	}

	void Start () {
		
		frontScreen.gameObject.SetActive (true);
		levelone.gameObject.SetActive (false);
		leveltwo.gameObject.SetActive (false);

		htpImage.gameObject.SetActive (false);

	}
	public void htpBtnPressed() {
		htpImage.gameObject.SetActive (true);
	}
	public void closeBtnPressed() {
		htpImage.gameObject.SetActive (false);
	}
	public void Tester(){
		Debug.Log ("_________Working__________");
	}

	public void unLocker(){
		levelUnlock = 1;
		Level2Btn.interactable = true;
		PlayerPrefs.SetInt ("LEVELUNLOCKKEY", 1);
		PlayerPrefs.Save ();
		Debug.Log ("_________Working__________");
	}

	public void level1BtnFun() {
		
		levelone.gameObject.SetActive (true);
		frontScreen.gameObject.SetActive (false);
		leveltwo.gameObject.SetActive (false);
	}
	public void level2BtnFun() {
		
		frontScreen.gameObject.SetActive (false);
		levelone.gameObject.SetActive (false);
		leveltwo.gameObject.SetActive (true);
	}

}
