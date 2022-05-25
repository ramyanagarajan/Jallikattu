using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowMovement1 : MonoBehaviour {

	// Use this for initialization
	public float speed = 5f;
	string keyPress = "left";
	GameObject player;
	Player pScript;




	void Start () {
		player = GameObject.Find ("Level2/Player");
		pScript = player.GetComponent<Player> ();

	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("position=" + transform.position.x);
		if (Input.GetKey ("left")) {			
			keyPress = "left";
		} 
		if (Input.GetKey ("right")) {			
			keyPress = "right";
		}
		if (keyPress == "left") {
			transform.Translate (Vector3.left * speed * Time.deltaTime);				
		}
		if (keyPress == "right") {
			transform.Translate (Vector3.right * speed * Time.deltaTime);
		}
		if (transform.position.x <= -1.0f) {
			//Debug.Log ("destroy left");
			pScript.callPlayerFallAnim ();
			transform.position = new Vector3(0, transform.position.y, transform.position.z);
			transform.parent.gameObject.SetActive(false);

		}
		if (transform.position.x >= 1.0f) {
			//Debug.Log ("destroy right");
			pScript.callPlayerFallAnim ();		
			transform.position = new Vector3(0, transform.position.y, transform.position.z);
			transform.parent.gameObject.SetActive(false);
		}
	}
	public void leftBtnFun() {
		keyPress = "left";
	}
	public void rightBtnFun() {
		keyPress = "right";
	}
	public void callArrowFun() {
		transform.position = new Vector3(0, transform.position.y, transform.position.z);
		transform.parent.gameObject.SetActive(false);
	}
}
