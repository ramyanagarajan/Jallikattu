using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldingTime : MonoBehaviour {

	// Use this for initialization
	public float currLength = 200f;
	public float maxLength = 200f;
	public float delay = 1f;
	public float timer;
	Player playerCS;

	GameObject arrowMove;
	public ArrowMovement arrowMoveScript; 


	void Start () {
		timer = delay;
		playerCS = (Player)GameObject.Find ("Level1/Player").GetComponent (typeof(Player));

		arrowMove = GameObject.FindGameObjectWithTag ("arrow");
//		arrowMoveScript = arrowMove.GetComponent<ArrowMovement>();
	}
	
	// Update is called once per frame
	void Update () {
		
		if (playerCS.holding == true) {
			timer -= Time.deltaTime;
			if (timer <= 0) {
				currLength -= 10f;
				transform.localScale = new Vector3 ((currLength / maxLength), 1, 1);
				timer = delay;
				if (currLength <= 0) {
					//playerCS.stop ("YouWin");
					Debug.Log("do something");
					arrowMoveScript.callArrowFun ();
					playerCS.callPlayerFun ();
				}
			}
		} else {
			timer = delay;
			currLength = 200f;
			transform.localScale = new Vector3 (1, 1, 1);
		}
	}

}
