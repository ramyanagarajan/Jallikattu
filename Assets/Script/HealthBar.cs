using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class HealthBar : MonoBehaviour {
	public Player playerCS;

	public float currLength = 100;
	public float maxLength = 100f;





	// Use this for initialization
	void Start () {
		playerCS = (Player)GameObject.Find ("Player").GetComponent (typeof(Player));

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void reducePlayerFun(string cat) {
		
		float reduceAmt = 0f;
		if (cat == "stone") {
			reduceAmt = 10f;
		}
		if (cat == "ox") {
			reduceAmt = 20f;
		}
		currLength -= reduceAmt;
		transform.localScale = new Vector3 ((currLength / maxLength), 1, 1);

		if (currLength <= 0) {
			StartCoroutine ("callGameOver", 1);
		}
	}
	IEnumerator callGameOver() {
		yield return new WaitForSeconds (1.5f);
		playerCS.stop ("GameOver");
	}
}
