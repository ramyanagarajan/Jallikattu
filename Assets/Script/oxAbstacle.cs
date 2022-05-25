using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxAbstacle : MonoBehaviour {

	// Use this for initialization
	public Animator anim;
	bool oXAttack= false;
	public bool stopTranslate = false;
	GameObject p;
	Player pScript;


	void Start () {
		anim = GetComponent<Animator>();
		p = GameObject.Find ("Player");
		pScript = p.GetComponent<Player> ();

	}
	
	// Update is called once per frame
	void Update () {
		if (pScript.holding != true) {
			transform.Translate (Vector3.left * 5 * Time.deltaTime);
		} else {
			//transform.position = p.transform.position;
			transform.position = new Vector3(p.transform.position.x+2.0f, p.transform.position.y, p.transform.position.z);
		}
		//anim.Play ("onAttack");
		if (transform.position.x < -8.0f) {
			//Debug.Log ("Checking=" + transform.position.x);
			Destroy (gameObject);

		}
		//Debug.Log("ox x=" + transform.position.x);


	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.gameObject.tag == "Player") {
			
			if (pScript.holding != true && pScript.holdComp != true) {
				//Debug.Log ("Colloded");
				anim.Play ("onAttack");

			}

		}
	}

	void OnCollisionStay2D(Collision2D collisionInfo){
		//Debug.Log ("Stay");
		if (pScript.holding != true && pScript.holdComp != true) {
			//Debug.Log ("Colloded");
			anim.Play ("onAttack");

		}
	}


	/*void OnTriggerEnter2D(Collider2D col) {
		if (col.gameObject.tag == "Player") {
			//Debug.Log ("Colloded");
			anim.Play ("onAttack");

		}
	}*/

}
