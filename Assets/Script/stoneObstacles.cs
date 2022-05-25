using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stoneObstacles : MonoBehaviour {

	// Use this for initialization
	GameObject bg;
	Done_BGScroller bgScript;
	GameObject p;
	Player pScript;
	void Start () {
		bg = GameObject.Find ("Quad");
		bgScript = bg.GetComponent<Done_BGScroller> ();

		p = GameObject.Find ("Player");
		pScript = p.GetComponent<Player> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (bgScript.stopBg == false && pScript.holding != true ) {
			gameObject.SetActive (true);
			transform.Translate (Vector3.right * 5 * Time.deltaTime);
		}
		if (pScript.holding == true) {
			gameObject.SetActive (false);
		}
		//Debug.Log (transform.position.x);
		if (transform.position.x >= 12) {
			gameObject.SetActive (false);
		}
	}
	void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			if (pScript.isObstacleHit != true) {
				pScript.score += 10;
			}
		}
	}
}
