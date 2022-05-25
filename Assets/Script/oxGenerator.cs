using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oxGenerator : MonoBehaviour {

	// Use this for initialization
	public GameObject[] ox;
	GameObject obj;
	public float delay = 5;
	float timer;
	GameObject p;
	Player pScript;
//	public Animator anim;

	void Start () {		

		timer = delay;
		p = GameObject.Find ("Player");
		pScript = p.GetComponent<Player> ();

	}

	// Update is called once per frame
	void Update () {
		timer -= Time.deltaTime;

		if (timer <= 0 && pScript.holding != true) {
			Instantiate (ox[Random.Range(0,4)], transform.position, Quaternion.identity);	
			timer = delay;
		}
		//make 5 sec delay after player fall
		if (pScript.holding == true) {
			timer = delay;
		}
	}


}
